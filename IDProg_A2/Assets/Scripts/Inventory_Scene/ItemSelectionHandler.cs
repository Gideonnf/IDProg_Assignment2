using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemSelectionHandler : MonoBehaviour {
    public enum Rarity
    {
        Common,
        Uncommon,
        Rare,
        Legendary,
        TotalRarity
    }
    public enum WeaponTypes
    {
        Rifles,
        Shield,
        LaserSwords,
        TotalWeaponTypes
    }

    public class Weapons    
    {
        
        public string WeaponName;
        public int AttPower;
        public int CritPower;
        public WeaponTypes type;
        public Rarity rarity;
        public int id;

        public Weapons(string WeaponName_, int AttPower_, int CritPower_, int type_, int rarity_, int id_)
        {
            WeaponName = WeaponName_;
            AttPower = AttPower_;
            CritPower = CritPower_;
            type =  (WeaponTypes)type_;
            rarity = (Rarity)rarity_;
            id = id_;
        }
    }

    public List<Weapons> WeaponList = new List<Weapons>();
    public List<Weapons> ApparelList = new List<Weapons>(); // Using weapons cause its just for showcasing
    public GameObject[] ItemSlots = new GameObject[5];
    private Inventory_Manager.EquiptmentTypes ActiveType;
    private Inventory_Manager InventoryManager;
    private int offSet;
	// Use this for initialization
	void Start () {
        //Initalize weapons
        InventoryManager = GetComponentInParent<Inventory_Manager>();
        offSet = 0;
        Weapons newWeapon = new Weapons("Pew Rifle", 29, 20, 0, 2, 1); // Rifle
        WeaponList.Add(newWeapon);
        newWeapon = new Weapons("Laser Sword", 35, 15, 2, 2, 2); // Sword
        WeaponList.Add(newWeapon);
        newWeapon = new Weapons("Shield", 10, 5, 1, 1, 3); // Shield
        WeaponList.Add(newWeapon);
        newWeapon = new Weapons("Strong Rifle", 45, 29, 0, 3, 4);
        WeaponList.Add(newWeapon); // Legendary rifle
        newWeapon = new Weapons("OP Sword", 60, 35, 2, 3, 5);
        WeaponList.Add(newWeapon);
        newWeapon = new Weapons("Test Sword", 30, 15, 2, 3, 6);
        WeaponList.Add(newWeapon);
        newWeapon = new Weapons("Final Sword", 43, 12, 2, 3, 7);
        WeaponList.Add(newWeapon);
        newWeapon = new Weapons("Filler Rifle", 43, 12, 0, 3, 8);
        WeaponList.Add(newWeapon);


        newWeapon = new Weapons("Helmet", 29, 20, 0, 2, 9); // Rifle
        ApparelList.Add(newWeapon);
        newWeapon = new Weapons("Chest Piece", 35, 15, 2, 2, 10); // Sword
        ApparelList.Add(newWeapon);
        newWeapon = new Weapons("Leggings", 10, 5, 1, 1, 11); // Shield
        ApparelList.Add(newWeapon);
        newWeapon = new Weapons("Boots", 45, 29, 0, 3, 12);
        ApparelList.Add(newWeapon); // Legendary rifle
        newWeapon = new Weapons("Gloves", 60, 35, 2, 3, 13);
        ApparelList.Add(newWeapon);
        newWeapon = new Weapons("Testing Gloves", 30, 15, 2, 3, 13);
        ApparelList.Add(newWeapon);
        newWeapon = new Weapons("Testing Again", 10, 15, 2, 3, 13);
        ApparelList.Add(newWeapon);
        newWeapon = new Weapons("Testing Again2", 5, 5, 2, 3, 13);
        ApparelList.Add(newWeapon);

    }

    // Update is called once per frame
    void Update () {
		if (InventoryManager.isChanged == true) // There is a change
        {
            ChangeEquipmentType();
            InventoryManager.isChanged = false;
        }

        if (Input.GetKeyUp("3"))
        {
            ShiftDown();
        }
        if (Input.GetKeyUp("4"))
        {
            ShiftUp();
        }
	}

    public void ChangeEquipmentType()
    { // For changing between weapons, apparel, etc
        ActiveType = InventoryManager.ActiveEquiptmentType; // Set active to this
        offSet = 0;
        for(int i = 0; i < ItemSlots.Length; ++i)
        {
            // Changing all 5 slots to the first 5 elements in weaponlist
            // If therea rem ore in the future, it will only be changed to the first five.
            // For now there is only 5
            switch(ActiveType)
            {
                
                case Inventory_Manager.EquiptmentTypes.Weapons:
                    {
                        ItemSlots[i].GetComponentInChildren<Text>().text = WeaponList[i].WeaponName;
                        ItemSlots[i].GetComponent<ItemPress>().currentItem = WeaponList[i];
                        ItemSlots[i].GetComponent<ItemPress>().buttonType = ActiveType;
                    }
                    break;
                case Inventory_Manager.EquiptmentTypes.Apparel:
                    {
                        ItemSlots[i].GetComponentInChildren<Text>().text = ApparelList[i].WeaponName;
                        ItemSlots[i].GetComponent<ItemPress>().currentItem = ApparelList[i];
                        ItemSlots[i].GetComponent<ItemPress>().buttonType = ActiveType;
                    }
                    break;
                default:
                    {
                        ItemSlots[i].GetComponentInChildren<Text>().text = WeaponList[i].WeaponName;
                        ItemSlots[i].GetComponent<ItemPress>().currentItem = WeaponList[i];
                        ItemSlots[i].GetComponent<ItemPress>().buttonType = ActiveType;
                    }
                    break;
            }
        }
    }

    public void ShiftDown()
    {
        if (offSet > 0)
        {
            switch (ActiveType)
            {
                case Inventory_Manager.EquiptmentTypes.Weapons:
                    {
                        // Offset represents the current number that ItemSlot[0] represent
                        // in the weapon lsit
                        // Im not sure of another way to do this
                        int i;

                        for (i = ItemSlots.Length - 1; i >= 0; --i)
                        {
                            ItemSlots[i].GetComponent<ItemPress>().currentItem = WeaponList[offSet + (i - 1)];
                            ItemSlots[i].GetComponentInChildren<Text>().text = WeaponList[offSet + (i - 1)].WeaponName;
                        }

                        // ItemSlots[i].GetComponentInChildren<Text>().text = WeaponList[offSet].WeaponName;
                        // ItemSlots[i].GetComponent<ItemPress>().currentItem = WeaponList[offSet];
                        offSet--;

                    }
                    break;
                case Inventory_Manager.EquiptmentTypes.Apparel:
                    {
                        // Offset represents the current number that ItemSlot[0] represent
                        // in the weapon lsit
                        // Im not sure of another way to do this
                        int i;

                        for (i = ItemSlots.Length - 1; i >= 0; --i)
                        {
                            ItemSlots[i].GetComponent<ItemPress>().currentItem = ApparelList[offSet + (i - 1)];
                            ItemSlots[i].GetComponentInChildren<Text>().text = ApparelList[offSet + (i - 1)].WeaponName;
                        }

                        // ItemSlots[i].GetComponentInChildren<Text>().text = ApparelList[offSet].WeaponName;
                        // ItemSlots[i].GetComponent<ItemPress>().currentItem = ApparelList[offSet];
                        offSet--;

                    }
                    break;
                default:
                    {
                        // Offset represents the current number that ItemSlot[0] represent
                        // in the weapon lsit
                        // Im not sure of another way to do this
                        int i;

                        for (i = ItemSlots.Length - 1; i >= 0; --i)
                        {
                            ItemSlots[i].GetComponent<ItemPress>().currentItem = WeaponList[offSet + (i - 1)];
                            ItemSlots[i].GetComponentInChildren<Text>().text = WeaponList[offSet + (i - 1)].WeaponName;
                        }

                        // ItemSlots[i].GetComponentInChildren<Text>().text = WeaponList[offSet].WeaponName;
                        // ItemSlots[i].GetComponent<ItemPress>().currentItem = WeaponList[offSet];
                        offSet--;

                    }
                    break;
            }

        }
    }

    public void ShiftUp()
    {
        switch(ActiveType)
        {
            case Inventory_Manager.EquiptmentTypes.Weapons:
                {
                    if (ItemSlots.Length + offSet < WeaponList.Count)
                    { // If it isnt at teh end of hte list let them shift up
                        int i = 0;
                        for (i = 0; i <= ItemSlots.Length - 1; ++i)
                        { // Less than equal to because the 4th element(last in array)
                          // can still swap with the next element in the weapon list
                            ItemSlots[i].GetComponent<ItemPress>().currentItem = WeaponList[offSet + (i + 1)];
                            ItemSlots[i].GetComponentInChildren<Text>().text = WeaponList[offSet + (i + 1)].WeaponName;
                        }
                        offSet++; // increase offset

                    }

                }
                break;
            case Inventory_Manager.EquiptmentTypes.Apparel:
                {
                    if (ItemSlots.Length + offSet < ApparelList.Count)
                    { // If it isnt at teh end of hte list let them shift up
                        int i = 0;
                        for (i = 0; i <= ItemSlots.Length - 1; ++i)
                        { // Less than equal to because the 4th element(last in array)
                          // can still swap with the next element in the weapon list
                            ItemSlots[i].GetComponent<ItemPress>().currentItem = ApparelList[offSet + (i + 1)];
                            ItemSlots[i].GetComponentInChildren<Text>().text = ApparelList[offSet + (i + 1)].WeaponName;
                        }
                        offSet++; // increase offset

                    }

                }
                break;
            default:
                {
                    if (ItemSlots.Length + offSet < WeaponList.Count)
                    { // If it isnt at teh end of hte list let them shift up
                        int i = 0;
                        for (i = 0; i <= ItemSlots.Length - 1; ++i)
                        { // Less than equal to because the 4th element(last in array)
                          // can still swap with the next element in the weapon list
                            ItemSlots[i].GetComponent<ItemPress>().currentItem = WeaponList[offSet + (i + 1)];
                            ItemSlots[i].GetComponentInChildren<Text>().text = WeaponList[offSet + (i + 1)].WeaponName;
                        }
                        offSet++; // increase offset

                    }

                }
                break;

        }
    }
}
