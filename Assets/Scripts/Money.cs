using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour {

	public int _money;
	public Text _moneyDisplay;
	public List<int> _moneyEntries = new List<int>();

	public void ManipulateMoney(int amount) {
		_money += amount;
		_moneyEntries.Add(amount);
		_moneyDisplay.text = _money.ToString("N0");
	}
}
