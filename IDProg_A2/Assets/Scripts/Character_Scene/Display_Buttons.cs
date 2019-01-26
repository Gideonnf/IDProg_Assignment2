using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Display_Buttons : MonoBehaviour {
    public Attribute_Manager.Stats stat;
    private Display_Manager DisplayManager;
	// Use this for initialization
	void Start () {
        DisplayManager = GetComponentInParent<Display_Manager>();
	}
	// This can be done without using a separate script
    // But just having a button with an int pass in and call that
    // on the button press but I might need to use this in the future
    // so im doing this here incase

	// Update is called once per frame
	void Update () {

	}

    public void Show()
    {
        DisplayManager.ShowDescription(stat);
    }
}
