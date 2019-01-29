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

    private void Update()
    {
        if (AttributeManager.Modifier[(int)Stat] <= 0)
        { // No modifier in that stat so button is greyed out
            transform.GetComponent<Button>().enabled = false;
            Color color = transform.GetComponent<Image>().color;
            color.a = 0.5f;
            transform.GetComponent<Image>().color = color;
        }
        else
        { // The stats are modified
            transform.GetComponent<Button>().enabled = true;
            Color color = transform.GetComponent<Image>().color;
            color.a = 1.0f;
            transform.GetComponent<Image>().color = color;
        }
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
