using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemEvents : MonoBehaviour {

	public bool _closeOnItemChange = true;
	public Item[] _allItems;

	private Notification _notification;
	private InfoPanel _infoPanel;
	private Money _money;
	private ResearchCenter _researchCenter;
	private Inventory[] _allInventories;
	private string _inventoryName;
	private int _slotIndex;
	private Item _curItem;

	private void Start() {
		_allInventories = GameObject.FindObjectsOfType<Inventory>();
		_infoPanel = GameObject.FindObjectOfType<InfoPanel>();
		_money = GameObject.FindObjectOfType<Money>();
		_researchCenter = GameObject.FindObjectOfType<ResearchCenter>();
		_notification = GameObject.FindObjectOfType<Notification>();
	}

	private Item GetItem(string name) {
		foreach (Item item in _allItems)
			if (item.name.ToLower() == name.ToLower()) return item;
		Debug.LogError("No item with name: " + name);
		return null;
	}

	private Inventory GetInventory(string name) {
		for (int i = 0; i < _allInventories.Length; i++) {
			if (_allInventories[i]._name == name) return _allInventories[i];
		}
		Debug.LogError("No inventory with name: " + name);
		return null;
	}

	private void CloseOnItemChange() {
		if (!_closeOnItemChange) return;
		if (GetInventory(_inventoryName)._slots[_slotIndex].item != _curItem)
			_infoPanel.Close();
	}

	public void SetData (string inventoryName, int slotIndex, Item curItem) {
		_inventoryName = inventoryName;
		_slotIndex = slotIndex;
		_curItem = curItem;
	}

	//EVENTS --------------------------------------------------------------------------------------

	public void HatchEgg() {
		Inventory curInventory = GetInventory(_inventoryName);
		curInventory.RemoveItemsInSlot(_slotIndex, 1);
		if (Random.Range(0, 100) <= 20)
			curInventory.AddItems(GetItem("Chicken"), 1);
		CloseOnItemChange();
	}

	public void HatchEggGolden() {
		Inventory curInventory = GetInventory(_inventoryName);
		curInventory.RemoveItemsInSlot(_slotIndex, 1);
		curInventory.AddItems(GetItem("Chicken"), 1);
		CloseOnItemChange();
	}

	public void SqueezeChicken() {
		if (Random.Range(0, 100) == 0) {
			Inventory curInventory = GetInventory(_inventoryName);
			curInventory.AddItems(GetItem("Egg"), 1);
		}
	}

	public void UpdateProfession(string profession) {
		Inventory curInventory = GetInventory("MAIN");
		curInventory.RemoveItemsInSlot(_slotIndex, -1);
		if (profession == "Woodcutter")
			curInventory.AddItems(GetItem("ChickenWoodcutter"), 1);
		else if (profession == "Miner")
			curInventory.AddItems(GetItem("ChickenMiner"), 1);
		else if (profession == "Builder")
			curInventory.AddItems(GetItem("ChickenBuilder"), 1);
		else if (profession == "Explorer")
			curInventory.AddItems(GetItem("ChickenExplorer"), 1);
		CloseOnItemChange();
	}

	public void OpenResearchMenu() {
		_researchCenter.Open();
	}

	public void SellItem() {
		Inventory curInventory = GetInventory("MAIN");
		_money.ManipulateMoney(curInventory._slots[_slotIndex].item.value);
		curInventory.RemoveItemsInSlot(_slotIndex, 1);
		CloseOnItemChange();
	}
}
