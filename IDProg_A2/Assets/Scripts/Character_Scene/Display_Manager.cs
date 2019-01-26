using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Display_Manager : MonoBehaviour {
    private Attribute_Manager Attribute_Manager;
    private int childCount = 0;
    private GameObject[] Displayed_Attributes;
	// Use this for initialization
	void Start () {
        int offset = 0;  // for offsetting the array
        Attribute_Manager = GetComponentInParent<Attribute_Manager>();

        foreach(Transform child in transform)
        {//Get the number of children
            // its 6 but incase there is morein the future
            if (child.CompareTag("EditableUI"))
                childCount++;
            else
                offset++;
        }
        Displayed_Attributes = new GameObject[childCount];

        int arrayOffset = 0;
       for(int i = 0; i < childCount + offset; ++i)
        { // Filling in the data into the array of displayed attributes
            if (transform.GetChild(i).CompareTag("EditableUI"))
            {
                // minus from offset
                Displayed_Attributes[i - arrayOffset] = transform.GetChild(i).gameObject;
            }
            else
            { // If the child isnt a Attribute UI that is editable
                arrayOffset++;
            }
        }
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		for(int i = 0; i < (int)Attribute_Manager.Stats.Total_Stats; ++i)
        {
           if (Attribute_Manager.Modifier[i] > 0)
            {
                Displayed_Attributes[i].GetComponentInChildren<TextMeshProUGUI>().text = Attribute_Manager.Attributes[i].ToString() + " (+" + Attribute_Manager.Modifier[i] + ")";
            }
           else if (Attribute_Manager.Modifier[i] == 0)
            {
                Displayed_Attributes[i].GetComponentInChildren<TextMeshProUGUI>().text = Attribute_Manager.Attributes[i].ToString();
            }
        }
	}
}
