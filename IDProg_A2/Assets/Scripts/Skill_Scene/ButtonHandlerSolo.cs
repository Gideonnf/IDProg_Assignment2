using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // required when using UI elements in scripts

public class ButtonHandlerSolo : MonoBehaviour {

    public Button myButton;
    public Button ButtonPrev;

    public Sprite ActiveSprite;
    public Sprite InactiveSprite;

    public bool Active;

    // Use this for initialization
    void Start()
    {
        myButton.interactable = false;
        Active = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (ButtonPrev.GetComponent<ButtonHandlerTrio>().GetActive() == true)
        {
            myButton.interactable = true;
        }
        else
        {
            myButton.interactable = false;
            SetActive(false);
        }
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
