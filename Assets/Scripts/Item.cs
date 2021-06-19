using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Item", menuName = "Item", order = 1)]
public class Item : ScriptableObject {

	public string itemName = "New Item";
	[TextArea]
	public string desc = "This is an item";
	public int value = 1;
	public TextAlignment itemDescAlignment;
	public Sprite icon;
	public int maxStack = 100;
	public enum Type { CHICKEN, INVENTORY, MATERIAL, BUILDING }
	public Type type = Type.MATERIAL;

	[Header("InfoPanel")]
	[Tooltip("Available methods: \nHatchEgg")]
	public InfoPanelComponent[] infoPanelComponents;

	[Header("CHICKEN")]
	public Item product;
	public int rate = 60;
	//public enum Profession { FACTORY, NONE, WOODCUTTER, MINER }
	//public Profession profession = Profession.NONE;

	[Header("INVENTORY")]
	public Item[] exclusive;
	public int slots = 6;

	[System.Serializable]
	public struct InfoPanelComponent {
		//public bool enabled;
		public Type type;
		public enum Type { TEXT, BUTTON, DROPDOWN }
		public string text;
		[Tooltip("textButton[0] used for BUTTON; longer method arrays are used in DROPDOWN")]
		public string[] textButton;
		[Tooltip("method[0] used for BUTTON; longer method arrays are used in DROPDOWN")]
		public string method;
	}
}
