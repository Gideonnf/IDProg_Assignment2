using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpdateAttributes : MonoBehaviour {
    private Attribute_Manager AttributeManager;
    public Attribute_Manager.Stats Stat;
    private TextMeshProUGUI StatText;

    [System.NonSerialized]
    //public int StatModifier = 0;
    private string newString;

    // Use this for initialization
    void Awake () {
        StatText = GetComponent<TextMeshProUGUI>();
        AttributeManager = GetComponentInParent<Attribute_Manager>();

    }

    // Update is called once per frame
    void Update () {
        if (AttributeManager.Modifier[(int)Stat] > 0)
        { // If there is positive stat modifier
            newString = (AttributeManager.Attributes[(int)Stat]).ToString() + " (+" + AttributeManager.Modifier[(int)Stat].ToString() + ")";
            StatText.text = newString;
        }
        else if (AttributeManager.Modifier[(int)Stat] == 0)
        {// No modifier
            newString = AttributeManager.Attributes[(int)Stat].ToString();
            StatText.text = newString;
        }
       

    }
}
