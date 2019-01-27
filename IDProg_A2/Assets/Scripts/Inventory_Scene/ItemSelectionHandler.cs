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

        public Weapons(string WeaponName_, int AttPower_, int CritPower_, int type_, int rarity_)
        {
            WeaponName = WeaponName_;
            AttPower = AttPower_;
            CritPower = CritPower_;
            type =  (WeaponTypes)type_;
            rarity = (Rarity)rarity_;
        }
    }

    public List<Weapons> WeaponList = new List<Weapons>();
    public List<Weapons> ApparelList = new List<Weapons>(); // Using weapons cause its just for showcasing
    public GameObject[] ItemSlots = new GameObject[5];
    private Inventory_Manager.EquiptmentTypes ActiveType;
    private Inventory_Manager InventoryManager;
	// Use this for initialization
	void Start () {
        //Initalize weapons
        InventoryManager = GetComponentInParent<Inventory_Manager>();

        Weapons newWeapon = new Weapons("Pew Rifle", 29, 20, 0, 2); // Rifle
        WeaponList.Add(newWeapon);
        newWeapon = new Weapons("Laser Sword", 35, 15, 2, 2); // Sword
        WeaponList.Add(newWeapon);
        newWeapon = new Weapons("Shield", 10, 5, 1, 1); // Shield
        WeaponList.Add(newWeapon);
        newWeapon = new Weapons("Strong Rifle", 45, 29, 0, 3);
        WeaponList.Add(newWeapon); // Legendary rifle
        newWeapon = new Weapons("OP Sword", 60, 35, 2, 3);
        WeaponList.Add(newWeapon);

        newWeapon = new Weapons("Helmet", 29, 20, 0, 2); // Rifle
        ApparelList.Add(newWeapon);
        newWeapon = new Weapons("Chest Piece", 35, 15, 2, 2); // Sword
        ApparelList.Add(newWeapon);
        newWeapon = new Weapons("Leggings", 10, 5, 1, 1); // Shield
        ApparelList.Add(newWeapon);
        newWeapon = new Weapons("Boots", 45, 29, 0, 3);
        ApparelList.Add(newWeapon); // Legendary rifle
        newWeapon = new Weapons("Gloves", 60, 35, 2, 3);
        ApparelList.Add(newWeapon);

    }

    // Update is called once per frame
    void Update () {
		if (InventoryManager.isChanged == true) // There is a change
        {
            ChangeEquipmentType();
            InventoryManager.isChanged = false;
        }
	}

    public void ChangeEquipmentType()
    { // For changing between weapons, apparel, etc
        ActiveType = InventoryManager.ActiveEquiptmentType; // Set active to this
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

    public void ShiftUp()
    {
        
    }
}
