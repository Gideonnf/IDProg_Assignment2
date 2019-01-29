using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemSelectionHandler : MonoBehaviour {
    public enum Rarity
    {
        None,
        Common,
        Uncommon,
        Rare,
        Legendary,
        TotalRarity
    }
    public enum ItemType
    {
        None,
        Head,
        Chest,
        Weapons,
        Leggings,
        Boots,
        TotalItemTypes
    }

    // I Realized i should have made this polymorphsim
    // Have a generic Equiptment class
    // And have weapons inherit
    // But editing now might require a lot of changes

    public class Weapons    
    {
        
        public string WeaponName;
        public int AttPower;
        public int CritPower;
        public ItemType type;
        public Rarity rarity;
        public int id;

        public Weapons(string WeaponName_, int AttPower_, int CritPower_, int type_, int rarity_, int id_)
        {
            WeaponName = WeaponName_;
            AttPower = AttPower_;
            CritPower = CritPower_;
            type =  (ItemType)type_;
            rarity = (Rarity)rarity_;
            id = id_;
        }
        public Weapons(int type_)
        {
            // Default value
            // Represents empty objects
            WeaponName = "";
            AttPower = 0;
            CritPower = 0;
            type = (ItemType)type_;
            rarity = Rarity.None;
            id = 0;
        }
    }

    public List<Weapons> WeaponList = new List<Weapons>();
    public List<Weapons> ApparelList = new List<Weapons>(); // Using weapons cause its just for showcasing
    public GameObject[] ItemSlots = new GameObject[5];
    public GameObject EquipmentManager;
    public GameObject EquipButton;
    public GameObject ItemSelectionBox;
    private RectTransform ItemSelectionTransform;
    private Equipment_Manager EMScript;

    [System.NonSerialized]
    private GameObject ActiveEquipment;


    private Inventory_Manager.EquiptmentTypes ActiveType;
    private Inventory_Manager InventoryManager;
    private bool isShown;
    private int offSet;
	// Use this for initialization
	void Start () {
        //Initalize weapons
        InventoryManager = GetComponentInParent<Inventory_Manager>();
        offSet = 0;
        Weapons newWeapon = new Weapons("Pew Rifle", 29, 20, 3, 3, 1); // Rifle
        WeaponList.Add(newWeapon);
        newWeapon = new Weapons("Laser Sword", 35, 15, 3, 3, 2); // Sword
        WeaponList.Add(newWeapon);
        newWeapon = new Weapons("Shield", 10, 5, 3, 2, 3); // Shield
        WeaponList.Add(newWeapon);
        newWeapon = new Weapons("Strong Rifle", 45, 29, 3, 4, 4);
        WeaponList.Add(newWeapon); // Legendary rifle
        newWeapon = new Weapons("OP Sword", 60, 35, 3, 4, 5);
        WeaponList.Add(newWeapon);
        newWeapon = new Weapons("Test Sword", 30, 15, 3, 4, 6);
        WeaponList.Add(newWeapon);
        newWeapon = new Weapons("Final Sword", 43, 12, 3, 4, 7);
        WeaponList.Add(newWeapon);
        newWeapon = new Weapons("Filler Rifle", 43, 12, 3, 4, 8);
        WeaponList.Add(newWeapon);


        newWeapon = new Weapons("Helmet", 29, 20, 1, 3, 9); // Rifle
        ApparelList.Add(newWeapon);
        newWeapon = new Weapons("Chest Piece", 35, 15, 2, 3, 10); // Sword
        ApparelList.Add(newWeapon);
        newWeapon = new Weapons("Leggings", 10, 5, 4, 2, 11); // Shield
        ApparelList.Add(newWeapon);
        newWeapon = new Weapons("Boots", 45, 29, 5, 4, 12);
        ApparelList.Add(newWeapon); // Legendary rifle
        newWeapon = new Weapons("Testing Chest", 30, 15, 2, 4, 13);
        ApparelList.Add(newWeapon);
        newWeapon = new Weapons("Testing Leggings", 10, 15, 4, 4, 13);
        ApparelList.Add(newWeapon);
        newWeapon = new Weapons("Testing Helmet", 5, 5, 1, 4, 13);
        ApparelList.Add(newWeapon);

        for(int i = 0; i < ItemSlots.Length; ++i)
        {
            ItemSlots[i].transform.parent.gameObject.GetComponent<Image>().enabled = false; // works
           // ItemSlots[i].GetComponentInParent<Image>().enabled = false; // doesnt work
            // idk why lol
        }
        EMScript = EquipmentManager.GetComponent<Equipment_Manager>();
        ItemSelectionTransform = ItemSelectionBox.GetComponent<RectTransform>();
        isShown = false;
    }

    // Update is called once per frame
    void Update () {
		if (InventoryManager.isChanged == true) // There is a change
        {
            ChangeEquipmentType();
            InventoryManager.isChanged = false;
        }

        if (Swipe.GetInstance().GetSwipeUp())
        {
            if (RectTransformUtility.RectangleContainsScreenPoint(ItemSelectionTransform, Swipe.GetInstance().GetLastTouchedPosition()))
            {
                ShiftUp();
            }
        }
        else if (Swipe.GetInstance().GetSwipeDown())
        {
            if (RectTransformUtility.RectangleContainsScreenPoint(ItemSelectionTransform, Swipe.GetInstance().GetLastTouchedPosition()))
            {
                ShiftDown();
            }
        }
        if (EMScript.isShown && isShown)
        { // If both are showiing
            EquipButton.SetActive(true);

            //EquipButton.GetComponent<Image>().enabled = true;
            //EquipButton.GetComponent<Button>().enabled = true;
            //EquipButton.GetComponentInChildren<Text>().text = "";
        }
        else
        { // If both aren't showing
            EquipButton.SetActive(false);

            //EquipButton.GetComponent<Image>().enabled = false;
            //EquipButton.GetComponent<Button>().enabled = false;
            //EquipButton.GetComponentInChildren<Text>().text = "Equip";

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
                        if(i < WeaponList.Count)
                        {
                            ItemSlots[i].GetComponentInChildren<Text>().text = WeaponList[i].WeaponName;
                            ItemSlots[i].GetComponent<ItemPress>().currentItem = WeaponList[i];
                            ItemSlots[i].GetComponent<ItemPress>().buttonType = ActiveType;
                        }
                    }
                    break;
                case Inventory_Manager.EquiptmentTypes.Apparel:
                    {
                        if (i < ApparelList.Count)
                        {
                            ItemSlots[i].GetComponentInChildren<Text>().text = ApparelList[i].WeaponName;
                            ItemSlots[i].GetComponent<ItemPress>().currentItem = ApparelList[i];
                            ItemSlots[i].GetComponent<ItemPress>().buttonType = ActiveType;
                        }
                    }
                    break;
                default:
                    {
                        if (i < WeaponList.Count)
                        {
                            ItemSlots[i].GetComponentInChildren<Text>().text = WeaponList[i].WeaponName;
                            ItemSlots[i].GetComponent<ItemPress>().currentItem = WeaponList[i];
                            ItemSlots[i].GetComponent<ItemPress>().buttonType = ActiveType;
                        }
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
                           // if (offSet + (i - 1) > WeaponList.Count)
                          //  {
                                ItemSlots[i].GetComponent<ItemPress>().currentItem = WeaponList[offSet + (i - 1)];
                                ItemSlots[i].GetComponentInChildren<Text>().text = WeaponList[offSet + (i - 1)].WeaponName;
                          //  }
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
                           // if (offSet + (i - 1) > ApparelList.Count)
                           // {
                                ItemSlots[i].GetComponent<ItemPress>().currentItem = ApparelList[offSet + (i - 1)];
                                ItemSlots[i].GetComponentInChildren<Text>().text = ApparelList[offSet + (i - 1)].WeaponName;
                           // }
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
                          //  if (offSet + (i - 1) > WeaponList.Count)
                          //  {
                                ItemSlots[i].GetComponent<ItemPress>().currentItem = WeaponList[offSet + (i - 1)];
                                ItemSlots[i].GetComponentInChildren<Text>().text = WeaponList[offSet + (i - 1)].WeaponName;
                          //  }
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
                        for (int x = 0; x < ItemSlots.Length; ++x)
                        { // turn off any descriptions that are activated
                            ItemSlots[x].transform.parent.gameObject.GetComponent<Image>().enabled = false;
                            ItemSlots[x].GetComponentInChildren<TextMeshProUGUI>().text = "";

                        }

                        int i = 0;
                        for (i = 0; i <= ItemSlots.Length - 1; ++i)
                        { // Less than equal to because the 4th element(last in array)
                          // can still swap with the next element in the weapon list
                         //  if (offSet + (i + 1) > WeaponList.Count)
                         //  { // Make sure that it exist inside the weaponlist
                                ItemSlots[i].GetComponent<ItemPress>().currentItem = WeaponList[offSet + (i + 1)];
                                ItemSlots[i].GetComponentInChildren<Text>().text = WeaponList[offSet + (i + 1)].WeaponName;

                          //  }
                        }
                        offSet++; // increase offset
                        
                    }

                }
                break;
            case Inventory_Manager.EquiptmentTypes.Apparel:
                {
                    if (ItemSlots.Length + offSet < ApparelList.Count)
                    { // If it isnt at teh end of hte list let them shift up
                        for (int x = 0; x < ItemSlots.Length; ++x)
                        { // turn off any descriptions that are activated
                            ItemSlots[x].transform.parent.gameObject.GetComponent<Image>().enabled = false;
                            ItemSlots[x].GetComponentInChildren<TextMeshProUGUI>().text = "";

                        }
                        int i = 0;
                        for (i = 0; i <= ItemSlots.Length - 1; ++i)
                        { // Less than equal to because the 4th element(last in array)
                          // can still swap with the next element in the weapon list
                            //if (offSet + (i + 1) > ApparelList.Count)
                            //{
                                ItemSlots[i].GetComponent<ItemPress>().currentItem = ApparelList[offSet + (i + 1)];
                                ItemSlots[i].GetComponentInChildren<Text>().text = ApparelList[offSet + (i + 1)].WeaponName;
                           /// }
                        }
                        offSet++; // increase offset

                    }

                }
                break;
            default:
                {
                    if (ItemSlots.Length + offSet < WeaponList.Count)
                    { // If it isnt at teh end of hte list let them shift up
                        for (int x = 0; x < ItemSlots.Length; ++x)
                        { // turn off any descriptions that are activated
                            ItemSlots[x].transform.parent.gameObject.GetComponent<Image>().enabled = false;
                            ItemSlots[x].GetComponentInChildren<TextMeshProUGUI>().text = "";

                        }
                        int i = 0;
                        for (i = 0; i <= ItemSlots.Length - 1; ++i)
                        { // Less than equal to because the 4th element(last in array)
                          // can still swap with the next element in the weapon list
                           // if (offSet + (i + 1) > WeaponList.Count)
                           // {
                                ItemSlots[i].GetComponent<ItemPress>().currentItem = WeaponList[offSet + (i + 1)];
                                ItemSlots[i].GetComponentInChildren<Text>().text = WeaponList[offSet + (i + 1)].WeaponName;
                           // }
                        }
                        offSet++; // increase offset

                    }

                }
                break;

        }
    }

    public void ShowItem(int index)
    {
        bool SameButton = false;
       // Image indexImage = ;
        if (ItemSlots[index].transform.parent.gameObject.GetComponent<Image>().enabled == true)
        {
            SameButton = true;
        }
        if(isShown == true)
        { // There is currently an item on display
            for(int i = 0; i < ItemSlots.Length; ++i)
            { // turn off any tthat is activated
                ItemSlots[i].transform.parent.gameObject.GetComponent<Image>().enabled = false;
                ItemSlots[i].GetComponentInChildren<TextMeshProUGUI>().text = "";

            }
            isShown = false;
        }

        if (isShown == false && SameButton == false)
        { // theyarenot pressing the same button again

            ItemSlots[index].transform.parent.gameObject.GetComponent<Image>().enabled = true;

            string type = "";
            switch (ItemSlots[index].GetComponent<ItemPress>().currentItem.type)
            {
                case ItemSelectionHandler.ItemType.Head:
                    {
                        type = "Type: Head";
                    }
                    break;
                case ItemSelectionHandler.ItemType.Chest:
                    {
                        type = "Type: Chest";
                    }
                    break;
                case ItemSelectionHandler.ItemType.Weapons:
                    {
                        type = "Type: Weapons";
                    }
                    break;
                case ItemSelectionHandler.ItemType.Leggings:
                    {
                        type = "Type: Leggings";
                    }
                    break;
                case ItemSelectionHandler.ItemType.Boots:
                    {
                        type = "Type: Boots";
                    }
                    break;

            }

            string ItemDescription = "Weapon Stats \n" +
                                        "Attack Power (+" + ItemSlots[index].GetComponent<ItemPress>().currentItem.AttPower + ")\n" +
                                        "Critical Power (+" + ItemSlots[index].GetComponent<ItemPress>().currentItem.CritPower + ")\n" +
                                        type;


            ItemSlots[index].GetComponentInChildren<TextMeshProUGUI>().text = ItemDescription;
            ActiveEquipment = ItemSlots[index];
            isShown = true;
        }
    }

    public void EquipItems()
    {
        
        Weapons SelectedEquipment = ActiveEquipment.GetComponent<ItemPress>().currentItem;
        Weapons EquippedEquipment = EMScript.ActiveEquipped.GetComponent<ItemPress>().currentItem;


        if (EMScript.EquipItems(EMScript.ActiveEquipped, ActiveEquipment) == true)
        {
            switch (ActiveType)
            {
                case Inventory_Manager.EquiptmentTypes.Weapons:
                {
                    for (int i = 0; i < WeaponList.Count; ++i)
                    {
                        if (SelectedEquipment.id == WeaponList[i].id)
                        { // Foudn the item that was swapped
                            // remove it
                            WeaponList.RemoveAt(i);
                            ItemSlots[i - (offSet)].transform.parent.gameObject.GetComponent<Image>().enabled = false;
                            ItemSlots[i - (offSet)].GetComponentInChildren<TextMeshProUGUI>().text = "";

                            //WeaponList.Add(EMScript.ActiveEquipped)
                            break;
                        }
                    }

                    if (EquippedEquipment.WeaponName != "")
                    { // If the equipped slot is not empty
                        // Add it into the list
                        WeaponList.Add(EquippedEquipment);
                    }

                }
                    break;
            case Inventory_Manager.EquiptmentTypes.Apparel:
                {
                    for (int i = 0; i < ApparelList.Count; ++i)
                    {
                        if (SelectedEquipment.id == ApparelList[i].id)
                        { // found the item that was swapped
                            // Remove it
                            ApparelList.RemoveAt(i);
                            ItemSlots[i].transform.parent.gameObject.GetComponent<Image>().enabled = false;
                            ItemSlots[i].GetComponentInChildren<TextMeshProUGUI>().text = "";

                            //WeaponList.Add(EMScript.ActiveEquipped)
                            break;
                        }
                    }

                    if (EquippedEquipment.WeaponName != "")
                    { // If the equipped slot is not empty
                        //Add it into the list
                        ApparelList.Add(EquippedEquipment);
                    }

                }
                    break;
            default:
                {

                    for (int i = 0; i < WeaponList.Count; ++i)
                    {
                        if (SelectedEquipment.id == WeaponList[i].id)
                        { // Foudn the item that was swapped
                            // remove it
                            WeaponList.RemoveAt(i);
                            ItemSlots[i].transform.parent.gameObject.GetComponent<Image>().enabled = false;
                            ItemSlots[i].GetComponentInChildren<TextMeshProUGUI>().text = "";

                            //WeaponList.Add(EMScript.ActiveEquipped)
                            break;
                        }
                    }

                    if (EquippedEquipment.WeaponName != "")
                    { // If the equipped slot is not empty
                        // Add it into the list
                        WeaponList.Add(EquippedEquipment);
                    }


                }
                    break;
            }
        }
        ChangeEquipmentType();
    }
}
