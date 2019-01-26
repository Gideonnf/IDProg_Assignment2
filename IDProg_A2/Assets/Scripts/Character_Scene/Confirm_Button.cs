using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Confirm_Button : MonoBehaviour {
    private Attribute_Manager AttributeManager;

    // Use this for initialization
    void Start () {
        AttributeManager = GetComponentInParent<Attribute_Manager>();

    }

    // Update is called once per frame
    void Update () {
		
	}

    public void ConfirmStats()
    {
        AttributeManager.UpdateStats();
    }
}
