using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillPage : MonoBehaviour {

    public Button myButton;
    bool SendNext;
    bool SendPrev;

    // Use this for initialization
    void Start ()
    {
        SendNext = false;
        SendPrev = false;
    }
	
	// Update is called once per frame
	void Update () {		
	}

    public void SendNextPage(bool Input)
    {
        SendNext = Input;
    }

    public bool GetSendNext()
    {
        return SendNext;
    }

    public void SendPrevPage(bool Input)
    {
        SendPrev = Input;
    }

    public bool GetSendPrev()
    {
        return SendPrev;
    }

}
