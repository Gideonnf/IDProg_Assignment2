using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Equipment_Manager : MonoBehaviour {
    class Character
    {
       //public ItemSelectionHandler.Weapons Head;
       //public ItemSelectionHandler.Weapons Chest;
       //public ItemSelectionHandler.Weapons Weapon;
       //public ItemSelectionHandler.Weapons Leggings;
       //public ItemSelectionHandler.Weapons Boots;
        //int 
        public ItemSelectionHandler.Weapons[] Slots = new ItemSelectionHandler.Weapons[5];
        public Character()
        {
            for (int i = 0; i < Slots.Length; ++i)
            {
                Slots[i] = new ItemSelectionHandler.Weapons(i + 1);
            }

            //Head = new ItemSelectionHandler.Weapons((int)ItemSelectionHandler.ItemType.Head);
            //Chest = new ItemSelectionHandler.Weapons((int)ItemSelectionHandler.ItemType.Chest);
            //Weapon = new ItemSelectionHandler.Weapons((int)ItemSelectionHandler.ItemType.Weapons);
            //Leggings = new ItemSelectionHandler.Weapons((int)ItemSelectionHandler.ItemType.Leggings);
            //Boots = new ItemSelectionHandler.Weapons((int)ItemSelectionHandler.ItemType.Boots);
        }

    }
    Character playerTemp;
    public bool isShown;
    public GameObject[] EquipmentSlots;
    [System.NonSerialized]
    public GameObject ActiveEquipped;
    [System.NonSerialized]
    public bool Equipped;

    // Use this for initialization
    void Start () {
        playerTemp = new Character();
        isShown = false;
        Equipped = false;
        for (int i = 0; i < EquipmentSlots.Length; ++i)
        {
            EquipmentSlots[i].GetComponent<ItemPress>().currentItem = playerTemp.Slots[i];
        }

        
        //EquipmentSlots[0].GetComponentInChildren<ItemPress>().currentItem = playerTemp.Head;
        //EquipmentSlots[1].GetComponentInChildren<ItemPress>().currentItem = playerTemp.Chest;
        //EquipmentSlots[2].GetComponentInChildren<ItemPress>().currentItem = playerTemp.Weapon;
        //EquipmentSlots[3].GetComponentInChildren<ItemPress>().currentItem = playerTemp.Leggings;
        //EquipmentSlots[4].GetComponentInChildren<ItemPress>().currentItem = playerTemp.Boots;

    }

    void Update()
    {
        for (int i = 0; i < EquipmentSlots.Length; ++i)
        {
            //switch()
            EquipmentSlots[i].GetComponentInChildren<Text>().text = EquipmentSlots[i].GetComponent<ItemPress>().currentItem.WeaponName;
        }
    }

    public bool EquipItems(GameObject ItemToSwap, GameObject EquipmentSlot_)
    {
        if (ItemToSwap.GetComponent<ItemPress>().currentItem.type == EquipmentSlot_.GetComponent<ItemPress>().currentItem.type)
        {// Same type

            ItemSelectionHandler.Weapons temp = EquipmentSlot_.GetComponent<ItemPress>().currentItem;
            EquipmentSlot_.GetComponent<ItemPress>().currentItem = ItemToSwap.GetComponent<ItemPress>().currentItem;
            ItemToSwap.GetComponent<ItemPress>().currentItem = temp;

            string ItemDescription = "Weapon Stats \n" +
                            "Attack Power (+" + ItemToSwap.GetComponent<ItemPress>().currentItem.AttPower + ")\n" +
                            "Critical Power (+" + ItemToSwap.GetComponent<ItemPress>().currentItem.CritPower + ")\n";
            ItemToSwap.GetComponentInChildren<TextMeshProUGUI>().text = ItemDescription;


            Equipped = true;
            return true;
        }
        return false;
    }

    public void ShowItem(int index)
    {
        bool SameButton = false;
        if (EquipmentSlots[index].transform.parent.gameObject.GetComponent<Image>().enabled == true)
        { // Checking if the button clicked is enabled alr
            SameButton = true;
        }

        if (isShown == true)
        { // if theres already an item on display
            for(int i = 0; i < EquipmentSlots.Length; ++i)
            {
                EquipmentSlots[i].transform.parent.gameObject.GetComponent<Image>().enabled = false;
                EquipmentSlots[i].GetComponentInChildren<TextMeshProUGUI>().text = "";
            }
            isShown = false;
            //GameObjec
            //ActiveEquipped.GetComponent<>
        }
        
        if(isShown == false && SameButton == false)
        {
            if (EquipmentSlots[index].GetComponent<ItemPress>().currentItem.WeaponName != "")
            {
                EquipmentSlots[index].transform.parent.gameObject.GetComponent<Image>().enabled = true;
                string ItemDescription = "Weapon Stats \n" +
                                            "Attack Power (+" + EquipmentSlots[index].GetComponent<ItemPress>().currentItem.AttPower + ")\n" +
                                            "Critical Power (+" + EquipmentSlots[index].GetComponent<ItemPress>().currentItem.CritPower + ")\n";
                EquipmentSlots[index].GetComponentInChildren<TextMeshProUGUI>().text = ItemDescription;
                ActiveEquipped = EquipmentSlots[index];
                isShown = true;
            }
            else
            { // t is empty, so it will still be set as the current active
              // but nothing will be displayed
                EquipmentSlots[index].transform.parent.gameObject.GetComponent<Image>().enabled = true;
                isShown = true;
                ActiveEquipped = EquipmentSlots[index];
            }
        }
    }
}


