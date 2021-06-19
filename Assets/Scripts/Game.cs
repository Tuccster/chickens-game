using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour {

    public StartItem[] _startItems;
    public Color[] _levelColors = new Color[10];

    private Inventory _mainInventory;
    private Inventory[] _allInventories;

    [System.Serializable]
    public struct StartItem {
        public Item item;
        public int amount;
    }

    private void Start() {
        _allInventories = GameObject.FindObjectsOfType<Inventory>();
        foreach (Inventory inventory in _allInventories)
            if (inventory._name == "MAIN") _mainInventory = inventory;

        StartCoroutine(LateStart());
    }

    private IEnumerator LateStart() {
        yield return new WaitForEndOfFrame();
        foreach (StartItem startItem in _startItems)
            _mainInventory.AddItems(startItem.item, startItem.amount);
    }
}