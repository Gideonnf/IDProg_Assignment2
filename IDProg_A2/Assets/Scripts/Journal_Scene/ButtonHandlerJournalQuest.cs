using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandlerJournalQuest : MonoBehaviour {

    public Button MyButton;

    public Sprite Highlighted_Added;
    public Sprite Highlighted_Unadded;
    public Sprite Unhighlighted_Added;
    public Sprite Unhighlighted_Unadded;

    bool IsHightlighted;
    bool IsAdded;
    bool MakeHighlighted;

	// Use this for initialization
	void Start () {
        MakeHighlighted = false;
    }
	
	// Update is called once per frame
	void Update () {  
    }

    public void SetHighlighted(bool Input)
    {
        IsHightlighted = Input;
        SetImage();
    }

    public bool GetHighlighted()
    {
        return IsHightlighted;
    }

    public void SetAdded(bool Input)
    {
        IsAdded = Input;
        SetImage();
    }

    public void ToggleAdded()
    {
        IsAdded = !IsAdded;
        SetImage();
    }

    public bool GetAdded()
    {
        return IsAdded;
    }

    public void SendMakeHighlighted(bool Input)
    {
        MakeHighlighted = Input;
    }

    public bool GetMakeHighlighted()
    {
        return MakeHighlighted;
    }

   void SetImage()
    {
        if (IsHightlighted && IsAdded)
        {
            MyButton.GetComponent<Image>().sprite = Highlighted_Added;
        }
        else if (IsHightlighted && !IsAdded)
        {
            MyButton.GetComponent<Image>().sprite = Highlighted_Unadded;
        }
        else if (!IsHightlighted && IsAdded)
        {
            MyButton.GetComponent<Image>().sprite = Unhighlighted_Added;
        }
        else if (!IsHightlighted && !IsAdded)
        {
            MyButton.GetComponent<Image>().sprite = Unhighlighted_Unadded;
        }
    }


}
