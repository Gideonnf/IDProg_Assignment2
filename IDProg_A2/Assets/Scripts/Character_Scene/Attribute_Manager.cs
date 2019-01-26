using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Attribute_Manager : MonoBehaviour {
    public GameObject Points;
    public enum Stats
    {
        Strength,
        Dexterity,
        Charisma,
        Constitution,
        Wisdom,
        Intelligence,
        Total_Stats
    }
    public int AttributePoints;
    public int[] Attributes = new int[(int)Stats.Total_Stats];
    public GameObject[] Attribute_Stats = new GameObject[(int)Stats.Total_Stats];

    [System.NonSerialized]
    public int[] Modifier = new int[(int)Stats.Total_Stats];


    // Use this for initialization
    void Awake () {
        // Set the attribute points to a init value
        Points.GetComponent<TextMeshProUGUI>().text = AttributePoints.ToString();
        for (int i = 0; i < (int)Stats.Total_Stats; i++)
        {
            Attribute_Stats[i].GetComponent<TextMeshProUGUI>().text = Attributes[i].ToString();
            Modifier[i] = 0;
        }

	}
	
	// Update is called once per frame
	void Update () {
        Points.GetComponent<TextMeshProUGUI>().text = AttributePoints.ToString();
    }

    public void UpdateStats()
    { // Only for updating stats
        for (int i = 0; i < (int)Stats.Total_Stats; i++)
        {
            Attributes[i] += Modifier[i]; // Add modifer to attributes
            Modifier[i] = 0; // Reset the modifier to 0
            Attribute_Stats[i].GetComponent<TextMeshProUGUI>().text = Attributes[i].ToString(); // Change the test
        }

    }
}
