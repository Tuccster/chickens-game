using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

	public string _name;
	public Slot[] _slots;

	private Notification _notification;
	private InfoPanel _infoPanel;
	private int _secondsElapsed = 0;

	public struct Slot {
		public GameObject slotObject;
		public Image icon;
		public Text amountText;
		public int amount;
		public Item item;
		public byte level;
		public bool hasProfession;
		public string profession;
	}

	private void Start() {
		_notification = GameObject.FindObjectOfType<Notification>();
		_infoPanel = GameObject.FindObjectOfType<InfoPanel>();
		_slots = new Slot[transform.childCount];
		for (int i = 0; i < _slots.Length; i++) {
			int j = i; //VEGCONV
			_slots[i].slotObject = transform.GetChild(i).gameObject;
			_slots[i].slotObject.GetComponent<Button>().onClick.AddListener(() => _infoPanel.CheckForDoubleClick(_name, j));
			_slots[i].icon = transform.GetChild(i).GetChild(0).GetComponent<Image>();
			_slots[i].amountText = transform.GetChild(i).GetChild(1).GetComponent<Text>();
		}
		StartCoroutine(ProductDistributionTimer());
	}

	private IEnumerator ProductDistributionTimer() {
		while (true) {
			yield return new WaitForSeconds(1);
			_secondsElapsed++;
			for (int i = 0; i < _slots.Length; i++) {
				if (_slots[i].item && _slots[i].item.type == Item.Type.CHICKEN) {
					if (_secondsElapsed % _slots[i].item.rate == 0) {
						AddItems(_slots[i].item.product, 1);
						_notification.AddNotification(_slots[i].item.itemName + " added 1 " + _slots[i].item.product, 0);
					}
				}
			}
		}
	}

	public void UpdateSlotUI(int index) {
		Slot curSlot = _slots[index];
		if (!curSlot.item) {
			curSlot.icon.color = new Color(0, 0, 0, 0);
			curSlot.icon.sprite = null;
			curSlot.amountText.text = string.Empty;
		}
		else {
			curSlot.icon.color = new Color(1, 1, 1, 1);
			curSlot.icon.sprite = curSlot.item.icon;
			if (curSlot.amount > 1)
				curSlot.amountText.text = curSlot.amount.ToString();
		}
	}

	public void UpdateInventoryUI() {
		for (int i = 0; i < _slots.Length; i++)
			UpdateSlotUI(i);
	}

	public void AddItems(Item item, int amount) {
		StartCoroutine(AddItemsEnumerator(item, amount));
	}

	public IEnumerator AddItemsEnumerator(Item item, int amount) {
		bool availableSlot = false;
		for (int a = 0; a < amount; a++) {
			for (int i = 0; i < _slots.Length; i++) {
				if (_slots[i].item == item && _slots[i].amount < _slots[i].item.maxStack) {
					_slots[i].amount++;
					if (_slots[i].amount < _slots[i].item.maxStack) availableSlot = true;
					UpdateSlotUI(i);
					break;
				} else if (i == _slots.Length - 1)
					availableSlot = false;
			}
			if (!availableSlot) {
				for (int i = 0; i < _slots.Length; i++) {
					if (!_slots[i].item) {
						_slots[i].item = item;
						_slots[i].amount++;
						UpdateSlotUI(i);
						break;
					}
				}
			}
		}
		yield return null;
	}

	public void RemoveAllItems() {
		for (int i = 0; i < _slots.Length; i++) {
			_slots[i].amount = 0;
			_slots[i].item = null;
			_slots[i].level = 0;
			UpdateSlotUI(i);
		}
	}

	public void RemoveItemsInSlot(int slotIndex, int amount) {
		if (amount < 0 || amount >= _slots[slotIndex].amount) {
			_slots[slotIndex].amount = 0;
			_slots[slotIndex].item = null;
			_slots[slotIndex].level = 0;
		} else _slots[slotIndex].amount -= amount;
		UpdateSlotUI(slotIndex);
	}
}
