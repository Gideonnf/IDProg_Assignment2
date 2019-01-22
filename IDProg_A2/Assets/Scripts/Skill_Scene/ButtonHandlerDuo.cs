using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // required when using UI elements in scripts

public class ButtonHandlerDuo : MonoBehaviour {
    public Button myButton;

    public Button ButtonAdjacent1;
    public Button ButtonAdjacent2;

    // Use this for initialization
    void Start()
    {
        myButton.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
