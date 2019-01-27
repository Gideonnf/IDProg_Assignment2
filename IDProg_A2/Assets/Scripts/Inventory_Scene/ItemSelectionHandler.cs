using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        int AttPower;
        int CritPower;
        WeaponTypes type;
        Rarity rarity;

        public Weapons(int AttPower_, int CritPower_, int type_, int rarity_)
        {
            AttPower = AttPower_;
            CritPower = CritPower_;
            type =  (WeaponTypes)type_;
            rarity = (Rarity)rarity_;
        }
    }

    public List<Weapons> WeaponList = new List<Weapons>();


	// Use this for initialization
	void Start () {
        //Initalize weapons
        Weapons newWeapon = new Weapons(29, 20, 0, 2); // Rifle
        WeaponList.Add(newWeapon);
        newWeapon = new Weapons(35, 15, 2, 2); // Sword
        WeaponList.Add(newWeapon);
        newWeapon = new Weapons(10, 5, 1, 1); // Shield
        WeaponList.Add(newWeapon);
        newWeapon = new Weapons(45, 29, 0, 3);
        WeaponList.Add(newWeapon); // Legendary rifle
        newWeapon = new Weapons(60, 35, 2, 3);
        WeaponList.Add(newWeapon);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
