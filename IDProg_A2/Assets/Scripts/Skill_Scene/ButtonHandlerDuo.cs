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
    bool Selected;

    // Use this for initialization
    void Start()
    {
        myButton.interactable = false;
        Active = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (ButtonAdjacent1.GetComponent<ButtonHandlerTrio>().GetActive() == false 
            && ButtonAdjacent2.GetComponent<ButtonHandlerTrio>().GetActive() == false)
        {
            myButton.interactable = false;
            SetActive(false);
        }
        else
        {
            myButton.interactable = true;
        }
    }

    public void SetSelected(bool Input)
    {
        Selected = Input;
    }

    public bool GetSelected()
    {
        return Selected;
    }

    public void ToggleActive()
    {
        Active = !Active;
        if (Active == true)
            myButton.GetComponent<Image>().sprite = ActiveSprite;
        else
            myButton.GetComponent<Image>().sprite = InactiveSprite;
    }

    void SetActive(bool _Active)
    {
        if (Active != _Active)
        {
            Active = _Active;
            if (Active == true)
                myButton.GetComponent<Image>().sprite = ActiveSprite;
            else
                myButton.GetComponent<Image>().sprite = InactiveSprite;
        }
    }

    public bool GetActive()
    {
        return Active;
    }
}
