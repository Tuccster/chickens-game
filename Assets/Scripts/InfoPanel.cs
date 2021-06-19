using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoPanel : MonoBehaviour {

	public float _clickSpeed = 0.25f;

	public GameObject _parent;
	public Text _itemName;
	public Image _itemIcon;
	public Text _itemLevel;
	public Image _itemLevelColor;
	public Text _itemDescText;

	public GameObject _scrollParent;
	public GameObject _ipcompButton;
	public GameObject _ipcompDropdown;
	private Game _game;
	private ItemEvents _itemEvents;
	private bool _dcInProgress = false;

	private void Start() {
		_game = GameObject.FindObjectOfType<Game>();
		_itemEvents = GameObject.FindObjectOfType<ItemEvents>();
		_parent.SetActive(false);
	}

	public void CheckForDoubleClick(string inventoryName, int slotIndex) {
		if (!_dcInProgress) StartCoroutine(CheckForDoubleClickTimer());
		else Open(inventoryName, slotIndex);
	}

	private IEnumerator CheckForDoubleClickTimer() {
		_dcInProgress = true;
		yield return new WaitForSeconds(_clickSpeed);
		_dcInProgress = false;
	}

	public void Open(string inventoryName, int slotIndex) {
		Inventory curInventory = new Inventory(); // : THROWS WARNING : 
		foreach (Inventory inventory in GameObject.FindObjectsOfType<Inventory>())
			if (inventory._name == inventoryName) curInventory = inventory;
		if (!curInventory._slots[slotIndex].item) return;

		_itemName.text = curInventory._slots[slotIndex].item.itemName;
		_itemIcon.sprite = curInventory._slots[slotIndex].item.icon;
		_itemLevel.text = curInventory._slots[slotIndex].level.ToString();
		_itemLevelColor.color = _game._levelColors[curInventory._slots[slotIndex].level];
		_itemDescText.text = curInventory._slots[slotIndex].item.desc;

		_itemEvents.SetData(inventoryName, slotIndex, curInventory._slots[slotIndex].item);

		if (curInventory._slots[slotIndex].item.value > 0) {
			GameObject sellipcompButton = Instantiate(_ipcompButton, Vector3.zero, Quaternion.identity, _scrollParent.GetComponent<RectTransform>());
			sellipcompButton.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(() => _itemEvents.SendMessage("SellItem"));
			sellipcompButton.transform.GetChild(1).GetComponent<Text>().text = "Sell";
			sellipcompButton.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = curInventory._slots[slotIndex].item.value.ToString();
		}

		foreach (Item.InfoPanelComponent component in curInventory._slots[slotIndex].item.infoPanelComponents) {
			if (component.type == Item.InfoPanelComponent.Type.BUTTON) {
				GameObject curipcompButton = Instantiate(_ipcompButton, Vector3.zero, Quaternion.identity, _scrollParent.GetComponent<RectTransform>());
				curipcompButton.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(() => _itemEvents.SendMessage(component.method));
				curipcompButton.transform.GetChild(1).GetComponent<Text>().text = component.text;
				curipcompButton.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = component.textButton[0];
			} else if (component.type == Item.InfoPanelComponent.Type.DROPDOWN) {
				GameObject curipcompDropdown = Instantiate(_ipcompDropdown, Vector3.zero, Quaternion.identity, _scrollParent.GetComponent<RectTransform>());
				Dropdown curDropdown = curipcompDropdown.GetComponent<Dropdown>();
				curDropdown.ClearOptions();
				curDropdown.AddOptions(component.textButton.OfType<string>().ToList());
				curDropdown.onValueChanged.AddListener(delegate {_itemEvents.SendMessage(component.method, curDropdown.options[curDropdown.value].text);});
				curipcompDropdown.transform.GetChild(0).GetComponent<Text>().text = component.text;
			}
		}
		_parent.SetActive(true);
	}

	public void Close() {
		for (int i = 0; i < _scrollParent.transform.childCount; i++)
			Destroy(_scrollParent.transform.GetChild(i).gameObject);
		_parent.SetActive(false);
	}
}
