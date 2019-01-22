using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // required when using UI elements in scripts

public class ButtonHandlerOrigin : MonoBehaviour
{
    public Button myButton;

    public Button ButtonUp;
    public Button ButtonRight;
    public Button ButtonBottom;
    public Button ButtonLeft;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SetAllAdjacentButtonActive()
    {
        ButtonUp.interactable = true;
        ButtonBottom.interactable = true;
        ButtonRight.interactable = true;
        ButtonLeft.interactable = true;       
    }
}
