using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventorySelectionHandler : MonoBehaviour {
    Inventory_Manager InventoryManager;
    public GameObject[] EquiptmentSlots = new GameObject[(int)Inventory_Manager.EquiptmentTypes.TotalTypes];
	// Use this for initialization
	void Start () {
        InventoryManager.GetComponentInParent<Inventory_Manager>();

	}
	
	// Update is called once per frame
	void Update () {
		for(int i = 0; i < (int)Inventory_Manager.EquiptmentTypes.TotalTypes; ++i)
        {
            //InventoryArray[i] = (int)InventoryManager.InventorySlots[i];
            //switch(InventoryArray[i])
            switch(InventoryManager.InventorySlots[i])
            { // This is for changing the text based on the swiping up or down in the inventory manager
                case Inventory_Manager.EquiptmentTypes.Weapons:
                    {
                        EquiptmentSlots[i].GetComponent<TextMeshProUGUI>().text = "Weapons";
                    }
                    break;
                case Inventory_Manager.EquiptmentTypes.Apparel:
                    {
                        EquiptmentSlots[i].GetComponent<TextMeshProUGUI>().text = "Apparel";
                    }
                    break;

                case Inventory_Manager.EquiptmentTypes.Potions:
                    {
                        EquiptmentSlots[i].GetComponent<TextMeshProUGUI>().text = "Potions";
                    }
                    break;

                case Inventory_Manager.EquiptmentTypes.Misc:
                    {
                        EquiptmentSlots[i].GetComponent<TextMeshProUGUI>().text = "Misc";
                    }
                    break;

            }
        }
	}
}
