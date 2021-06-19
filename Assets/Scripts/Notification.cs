using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notification : MonoBehaviour {

	public NotificationStyle[] _notificationStyles;
	public GameObject _container;
	public GameObject _parent;
	public GameObject _notification;
	public Text _count;
	public Text _emptyText;

	[System.Serializable]
	public struct NotificationStyle {
		public Color textColor;
		public Color backColor;
	}

	private void Start() {
		_container.SetActive(false);
		UpdateNotificationCount();
	}

	public void UpdateNotificationCount() {
		if (_parent.transform.childCount > 0) {
			_count.text = _parent.transform.childCount.ToString();
			_emptyText.text = string.Empty;
		} else {
			_count.text = string.Empty;
			_emptyText.text = "This is where notifications would be, if you had any of course.";
		}
	}

	public void AddNotification(string notification, byte style) {
		GameObject newNoti = Instantiate(_notification, Vector3.zero, Quaternion.identity, _parent.GetComponent<RectTransform>());
		newNoti.transform.GetChild(0).GetComponent<Text>().text = notification;
		newNoti.transform.GetChild(0).GetComponent<Text>().color =  _notificationStyles[style].textColor;
		newNoti.GetComponent<Image>().color = _notificationStyles[style].backColor;
		UpdateNotificationCount();
	}

	public void ToggleState() {
		if (_container.activeSelf)
			_container.SetActive(false);
		else _container.SetActive(true);
	}
}
