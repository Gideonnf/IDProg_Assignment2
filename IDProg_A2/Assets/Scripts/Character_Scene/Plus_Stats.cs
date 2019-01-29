using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class Plus_Stats : MonoBehaviour {
    public GameObject Stats;
    private TextMeshProUGUI StatText;
    private Attribute_Manager AttributeManager;
    public Attribute_Manager.Stats Stat;
    //private Image

    // Use this for initialization
    void Awake () {
        StatText = Stats.GetComponent<TextMeshProUGUI>();
        AttributeManager = GetComponentInParent<Attribute_Manager>();
        //AttributeManager.Modifier[(int)Stat] = 0;
	}

    private void Update()
    {
        if(AttributeManager.AttributePoints <= 0)
        { // If no points
            transform.GetComponent<Button>().enabled = false;
            Color color;
            color = transform.GetComponent<Image>().color;

            color.a = 0.5f;
            transform.GetComponent<Image>().color = color;
        }
        else
        { // There is attribute points
            transform.GetComponent<Button>().enabled = true;
            Color color;
            color = transform.GetComponent<Image>().color;

            color.a = 1.0f;
            transform.GetComponent<Image>().color = color;
        }
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
