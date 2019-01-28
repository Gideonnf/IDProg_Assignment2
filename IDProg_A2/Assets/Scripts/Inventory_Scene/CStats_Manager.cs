using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CStats_Manager : MonoBehaviour {
    public GameObject EquipmentManager;
    public GameObject DescriptionBox;
    public GameObject DescriptionBoxButton;
    private Equipment_Manager Equipment;
    public enum Stats
    {
        Health,
        Magicka,
        Stamina,
        AttackPower,
        DefensePower,
        CriticalPower,
        TotalStats
    }

    public int[] Character = new int[(int)Stats.TotalStats];
    public GameObject[] Character_Stats = new GameObject[(int)Stats.TotalStats];
    public Sprite[] SpriteDescriptionList = new Sprite[(int)Stats.TotalStats];

    private int[] CharacterStatModifiers = new int[(int)Stats.TotalStats];

	// Use this for initialization
	void Start () {
        Equipment = EquipmentManager.GetComponent<Equipment_Manager>();

        for (int i = 0; i < CharacterStatModifiers.Length; ++i)
        { // Initalize everything to 0
            CharacterStatModifiers[i] = 0;
        }


        
	}
	
	// Update is called once per frame
	void Update () {
        //for(int i = 0; i < Equipment.EquipmentSlots.Length; ++i)
        //{
        //    CharacterStatModifiers[(int)Stats.AttackPower] += 
        //}
        if (Equipment.Equipped == true)
        {
            // There is a change in equipment
            ResetModifiers(); // Reset tne current modifier ot get the updated ones
             for (int i = 0; i < Equipment.EquipmentSlots.Length; ++i)
            {  //Add the data into the modifiers from the equipment
                CharacterStatModifiers[(int)Stats.AttackPower] += Equipment.EquipmentSlots[i].GetComponent<ItemPress>().currentItem.AttPower;
                CharacterStatModifiers[(int)Stats.CriticalPower] += Equipment.EquipmentSlots[i].GetComponent<ItemPress>().currentItem.CritPower;
            }
             // Set to false
            Equipment.Equipped = false;
        }


		for(int i = (int)Stats.AttackPower; i < (int)Stats.TotalStats; ++i)
        {
            Character_Stats[i].GetComponentInChildren<Text>().text = (Character[i] + CharacterStatModifiers[i]).ToString();
        }
	}

    private void ResetModifiers()
    {
        for (int i = 0; i < CharacterStatModifiers.Length; ++i)
        {
            CharacterStatModifiers[i] = 0;
        }
    }

    public void CloseDescription()
    {
        DescriptionBox.GetComponent<Image>().enabled = false;
        DescriptionBoxButton.GetComponent<Image>().enabled = false;
        DescriptionBoxButton.GetComponent<Button>().enabled = false;
    }

    public void StatDescription(int Stat)
    {
        DescriptionBox.GetComponent<Image>().enabled = true;
        DescriptionBox.GetComponent<Image>().sprite = SpriteDescriptionList[(int)Stat];
        DescriptionBoxButton.GetComponent<Image>().enabled = true;
        DescriptionBoxButton.GetComponent<Button>().enabled = true;
    }


}
