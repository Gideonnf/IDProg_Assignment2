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

    public Sprite ActiveSprite;
    public Sprite InactiveSprite;

    bool Active;
    bool Selected;
    bool Send;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SetSendSelected(bool Input)
    {
        Send = Input;
    }

    public bool GetSendSelected()
    {
        return Send;
    }

    public void SetSelected(bool Input)
    {
        Selected = Input;
    }

    public bool GetSelected()
    {
        return Selected;
    }

    public void SetAllAdjacentButtonActive(bool Input)
    {
        ButtonUp.interactable = Input;
        ButtonBottom.interactable = Input;
        ButtonRight.interactable = Input;
        ButtonLeft.interactable = Input;
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

    public Sprite GetSpriteActive()
    {
        return ActiveSprite;
    }

    public Sprite GetSpriteInactive()
    {
        return InactiveSprite;
    }
}
