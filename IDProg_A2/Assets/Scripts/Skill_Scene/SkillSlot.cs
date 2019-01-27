using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillSlot : MonoBehaviour {

    public Button myButton;
    public Sprite ImageSelected;
    public Sprite ImageUnselected;

    bool Selected;
    bool Active;
    bool send;

	// Use this for initialization
	void Start () {
        Selected = false;
    }
	
	// Update is called once per frame
	void Update () {
		
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
        SetImage();
    }

    //public bool GetActive()
    //{
    //    return Active;
    //}

    public void SetImage()
    {
        if (Selected == true)
            myButton.GetComponent<Image>().sprite = ImageSelected;
        else
            myButton.GetComponent<Image>().sprite = ImageUnselected;
    }
}
