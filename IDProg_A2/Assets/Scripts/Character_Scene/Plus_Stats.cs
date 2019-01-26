using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Plus_Stats : MonoBehaviour {
    public GameObject Stats;
    private TextMeshProUGUI StatText;
    private Attribute_Manager AttributeManager;
    public Attribute_Manager.Stats Stat;

    // Use this for initialization
    void Awake () {
        StatText = Stats.GetComponent<TextMeshProUGUI>();
        AttributeManager = GetComponentInParent<Attribute_Manager>();
        //AttributeManager.Modifier[(int)Stat] = 0;
	}


    public void IncreaseStats()
    {
        if (AttributeManager.AttributePoints - 1 >= 0)
        {
            AttributeManager.Modifier[(int)Stat]++;
            //AttributeManager.Attributes[(int)Stat]++;
            AttributeManager.AttributePoints--;
        }
    }
}
