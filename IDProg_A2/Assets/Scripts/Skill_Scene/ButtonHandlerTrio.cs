using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // required when using UI elements in scripts

public class ButtonHandlerTrio : MonoBehaviour {

    public Button myButton;

    public Button ButtonAdjacent1;
    public Button ButtonAdjacent2;
    public Button ButtonAdjacent3;
    public Button ButtonPrev;

    public Sprite ActiveSprite;
    public Sprite InactiveSprite;

    bool Active;
    bool Selected;
    bool send;

    // Use this for initialization
    void Start()
    {
        Active = false;
        myButton.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (ButtonPrev.GetComponent<ButtonHandlerOrigin>() != null)
        {
            if (ButtonPrev.GetComponent<ButtonHandlerOrigin>().GetActive() == true)
            {
                myButton.interactable = true;
            }
            else
            {
                myButton.interactable = false;
                SetActive(false);
            }
        }
        else if (ButtonPrev.GetComponent<ButtonHandlerTrio>() != null)
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
    }

    public void SetSendSelected(bool Input)
    {
        send = Input;
    }

    public bool GetSendSelected()
    {
        return send;
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

    public Sprite GetSpriteActive()
    {
        return ActiveSprite;
    }

    public Sprite GetSpriteInactive()
    {
        return InactiveSprite;
    }
}
