using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // required when using UI elements in scripts

public class AddSkillButton : MonoBehaviour {

    public Button myButton;

    public Sprite Added;
    public Sprite Unadded;

    bool Click;
    bool IsAdded;

	// Use this for initialization
	void Start () {
        Click = false;
        IsAdded = false;
    }
	
	// Update is called once per frame
	void Update () {	
	}

    public void SetSendClick(bool Input)
    {
        Click = Input;
    }

    public bool GetSendClick()
    {
        return Click;
    }

    public void SetAdded(bool Input)
    {
        IsAdded = Input;

        if (IsAdded == true)
            myButton.GetComponent<Image>().sprite = Unadded;
        else
            myButton.GetComponent<Image>().sprite = Added;
    }

    public bool GetAdded()
    {
        return IsAdded;
    }
}
