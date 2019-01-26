using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_Manager : MonoBehaviour {
    public enum EquiptmentTypes
    {
        Weapons,
        Apparel,
        Potions,
        Misc,
        TotalTypes
    }
    public GameObject Arrow;
    // An array to hold the number of active slots
    public EquiptmentTypes[] InventorySlots = new EquiptmentTypes[(int)EquiptmentTypes.TotalTypes];
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShiftUp()
    {
        EquiptmentTypes temp = InventorySlots[0]; // Store the top element
        int i;
        for (i = 0; i < ((int)EquiptmentTypes.TotalTypes - 1); ++i)
        {
            // Swap the current element with the next one
            InventorySlots[i] = InventorySlots[i + 1];
        }
        InventorySlots[i] = temp; // Change the last element to the first one
    }

    public void ShiftDown()
    {
        EquiptmentTypes temp = InventorySlots[(int)EquiptmentTypes.TotalTypes - 1]; // Store the last element into a temp
        int i;
        for (i = (int)EquiptmentTypes.TotalTypes - 1; i > 0; --i)
        {
            InventorySlots[i] = InventorySlots[i - 1];
        }
        InventorySlots[i] = temp;
    }
}
