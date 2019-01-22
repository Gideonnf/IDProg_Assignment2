using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // required when using UI elements in scripts

public class ButtonHandler : MonoBehaviour
{

    public Button myButton;

    public Button ButtonUp;
    public Button ButtonBottom;
    public Button ButtonRight;
    public Button ButtonLeft;

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
        ButtonUp.interactable = !ButtonUp.interactable;
        ButtonBottom.interactable = !ButtonBottom.interactable;
        ButtonRight.interactable = !ButtonRight.interactable;
        ButtonLeft.interactable = !ButtonLeft.interactable;
    }

    public void SetUpButtonActive()
    {
        ButtonUp.interactable = !ButtonUp.interactable;
    }

    public void SetBottomButtonActive()
    {
        ButtonBottom.interactable = !ButtonBottom.interactable;
    }

    public void SetRightButtonActive()
    {
        ButtonRight.interactable = !ButtonRight.interactable;
    }

    public void SetLeftButtonActive()
    {
        ButtonLeft.interactable = !ButtonLeft.interactable;
    }
}
