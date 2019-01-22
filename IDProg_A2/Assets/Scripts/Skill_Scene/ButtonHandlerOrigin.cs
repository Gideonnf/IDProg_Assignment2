﻿using System.Collections;
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

    public Sprite ActiveSprite;
    public Sprite InactiveSprite;

    bool Active;

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

    public void ToggleActive()
    {
        Active = !Active;
        if (Active == true)
            myButton.GetComponent<Image>().sprite = ActiveSprite;
        else
            myButton.GetComponent<Image>().sprite = InactiveSprite;
    }

    public bool GetActive()
    {
        return Active;
    }
}
