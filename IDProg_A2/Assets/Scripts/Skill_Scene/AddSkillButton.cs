using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // required when using UI elements in scripts

public class AddSkillButton : MonoBehaviour {

    public Button myButton;

    public Sprite Added;
    public Sprite Unadded;
    public Sprite Move;

    bool Click;
    int State;

	// Use this for initialization
	void Start () {
        Click = false;
        State = 0;
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

    public void SetState(int Input)
    {
        State = Input;

        if (State == 1)
            myButton.GetComponent<Image>().sprite = Unadded;
        else if (State == 0)
            myButton.GetComponent<Image>().sprite = Added;
        else if (State == 2)
            myButton.GetComponent<Image>().sprite = Move;
    }

    public int GetState()
    {
        return State;
    }
}
