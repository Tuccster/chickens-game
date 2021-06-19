using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResearchCenter : MonoBehaviour {

	[Header("Tabs")]
	public Tab[] _tabs;

	[Header("Resources")]
	public GameObject _masterContainer;
	public RectTransform _tabContainer;
	public GameObject _tab;
	public RectTransform _listingContainer;
	public GameObject _listing;
	public GameObject _descContainter;
	public Text _desc;

	[System.Serializable]
	public struct Tab {
		public byte id;
		public Sprite icon;
		public Listing[] listings;
	}

	[System.Serializable]
	public struct Listing {
		public string name;
		public string namebtn;
		public int price;
		[TextArea]
		public string desc;
		public bool bought;
	}

	private void Start() {
		foreach (Tab tab in _tabs) {
			GameObject curtab = Instantiate(_tab, Vector3.zero, Quaternion.identity, _tabContainer);
			curtab.transform.GetChild(0).GetComponent<Image>().sprite = tab.icon;
			curtab.GetComponent<Button>().onClick.AddListener(() => ChangeActiveTab(tab.id));
		}
	}

	public void ChangeActiveTab(byte id) {
		
	}

	public void Open() {
		_masterContainer.SetActive(true);
	}

	public void Close() {
		_masterContainer.SetActive(false);
	}
}
