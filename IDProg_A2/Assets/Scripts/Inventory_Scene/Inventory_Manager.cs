using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory_Manager : MonoBehaviour {
    public enum EquiptmentTypes
    {
        Weapons,
        Apparel,
        Potions,
        Misc,
        TotalTypes
    }
    public EquiptmentTypes[] InventorySlots = new EquiptmentTypes[(int)EquiptmentTypes.TotalTypes];
    public GameObject[] Containers = new GameObject[(int)EquiptmentTypes.TotalTypes];

    [System.NonSerialized]
    public EquiptmentTypes ActiveEquiptmentType;

    // An array to hold the number of active slots
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp("1"))
        {
            ShiftUp();
        }
        else if (Input.GetKeyUp("2"))
        {
            ShiftDown();
        }
	}

    // IF I CHANGE TEH CONTAINERS INTO BUTTONS
    // ADD A SCRIPT FOR THE BUTTONS WITH AN ATTACHED EQUIPMENT TYPE
    // AND JUST CHANGE THAT TYPE SO THAT HTE BUTTON CAN WORK WHEN U SCROLL

    public void ShiftUp()
    {
        EquiptmentTypes temp = InventorySlots[0]; // Store the top element
        string tempGO = Containers[0].GetComponent<TextMeshProUGUI>().text;

        int i;
        for (i = 0; i < ((int)EquiptmentTypes.TotalTypes - 1); ++i)
        {
            // Swap the current element with the next one
            InventorySlots[i] = InventorySlots[i + 1];
            Containers[i].GetComponent<TextMeshProUGUI>().text = Containers[i + 1].GetComponent<TextMeshProUGUI>().text;
        }
        InventorySlots[i] = temp; // Change the last element to the first one
        Containers[i].GetComponent<TextMeshProUGUI>().text = tempGO;
        ActiveEquiptmentType = InventorySlots[0];
    }

    public void ShiftDown()
    {
        EquiptmentTypes temp = InventorySlots[(int)EquiptmentTypes.TotalTypes - 1]; // Store the last element into a temp
        string tempGO = Containers[(int)EquiptmentTypes.TotalTypes - 1].GetComponent<TextMeshProUGUI>().text;

        int i;
        for (i = (int)EquiptmentTypes.TotalTypes - 1; i > 0; --i)
        {
            InventorySlots[i] = InventorySlots[i - 1];
            Containers[i].GetComponent<TextMeshProUGUI>().text = Containers[i - 1].GetComponent<TextMeshProUGUI>().text;
        }
        InventorySlots[i] = temp;
        Containers[i].GetComponent<TextMeshProUGUI>().text = tempGO;
        ActiveEquiptmentType = InventorySlots[0];
    }
}
