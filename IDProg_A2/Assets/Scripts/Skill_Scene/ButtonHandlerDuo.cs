using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // required when using UI elements in scripts

public class ButtonHandlerDuo : MonoBehaviour {
    public Button myButton;

    public Button ButtonAdjacent1;
    public Button ButtonAdjacent2;

    public Sprite ActiveSprite;
    public Sprite InactiveSprite;

    bool Active;

    // Use this for initialization
    void Start()
    {
        myButton.interactable = false;
        Active = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ToggleActive()
    {
        Active = !Active;
        if (Active == true)
            myButton.GetComponent<Image>().sprite = ActiveSprite;
        else
            myButton.GetComponent<Image>().sprite = InactiveSprite;
    }
}
