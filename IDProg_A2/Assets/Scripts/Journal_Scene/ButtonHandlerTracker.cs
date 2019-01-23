using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandlerTracker : MonoBehaviour {

    public Button MyButton;

    public Sprite Track;
    public Sprite Untrack;

    bool IsAdded;
    bool MakeAdded;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
	}

    public void SendMakeAdded(bool Input)
    {
        MakeAdded = Input;
    }

    public bool GetMakeAdded()
    {
        return MakeAdded;
    }

    public void SetAdded(bool Input)
    {
        IsAdded = Input;
        SetImage();
    }

    public void GetAdded(bool Input)
    {
        IsAdded = Input;
    }

    void SetImage()
    {
        if (IsAdded == true)
        {
            MyButton.GetComponent<Image>().sprite = Untrack;
        }
        else if (IsAdded == false)
        {
            MyButton.GetComponent<Image>().sprite = Track;
        }
    }
}
