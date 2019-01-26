using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Minus_Stats : MonoBehaviour {

    public Button MyButton;
    public GameObject Stats;
    private TextMeshProUGUI StatText;
    private Attribute_Manager AttributeManager;
    private Plus_Stats PlusStats;
    public Attribute_Manager.Stats Stat;
    [System.NonSerialized]
  //  public int StatModifier = 0;
    private string newString;

    // Use this for initialization
    void Awake()
    {
        StatText = Stats.GetComponent<TextMeshProUGUI>();
        AttributeManager = GetComponentInParent<Attribute_Manager>();
        PlusStats = transform.parent.gameObject.GetComponentInChildren<Plus_Stats>();
       // StatModifier = 0;
    }


    public void DecreaseStats()
    {
        //char[] temp = new char[100];
        if (AttributeManager.Modifier[(int)Stat] - 1 >= 0)
        {
            AttributeManager.Modifier[(int)Stat]--;
            //AttributeManager.Attributes[(int)Stat]--;
            AttributeManager.AttributePoints++;
        }
    }
}
