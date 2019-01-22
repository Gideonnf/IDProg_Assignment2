using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // required when using UI elements in scripts

public class ButtonHandlerTrio : MonoBehaviour {

    public Button myButton;

    public Button ButtonAdjacent1;
    public Button ButtonAdjacent2;
    public Button ButtonAdjacent3;

    // Use this for initialization
    void Start()
    {
        myButton.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SetAllAdjacentButtonActive()
    {
        ButtonAdjacent1.interactable = true;
        ButtonAdjacent2.interactable = true;
        ButtonAdjacent3.interactable = true;
    }
}
