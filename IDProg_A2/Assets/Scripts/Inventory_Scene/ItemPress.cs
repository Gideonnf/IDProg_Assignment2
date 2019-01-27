using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemPress : MonoBehaviour {
    [System.NonSerialized]
    public Inventory_Manager.EquiptmentTypes buttonType;
    [System.NonSerialized]
    public ItemSelectionHandler.Weapons currentItem;

    public GameObject Descriptionbox;
    private bool isShown = false;
    //private GameObject DescriptionBox;
	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowDetails()
    {
        if (isShown == false)
        { // If it isn't showing
            //GetComponentInParent<>
            Descriptionbox.GetComponentInParent<Image>().enabled = true;
            string ItemDescription = "Weapon Stats \n" +
                                        "Attack Power (+" + currentItem.AttPower + ")\n" +
                                        "Critical Power (+" + currentItem.CritPower + ")\n";
            Descriptionbox.GetComponent<TextMeshProUGUI>().text = ItemDescription;
            isShown = true;
        }
        else if (isShown == true)
        {
            Descriptionbox.GetComponentInParent<Image>().enabled = false;
            Descriptionbox.GetComponent<TextMeshProUGUI>().text = "";
            isShown = false; // remove the black background and clear text
        }
    }
}
