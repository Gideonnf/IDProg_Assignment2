using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // required when using UI elements in scripts

public class SkillTab : MonoBehaviour {

    public Image myImage;
    public Image myButton;

    public Button centre;
   //public Button up;
   //public Button right;
   //public Button left;
   //public Button bottom;
   //public Button upRight;
   //public Button upLeft;
   //public Button bottomRight;
   //public Button bottomLeft;
   //public Button upWCentre;
   //public Button upWRight;
   //public Button upWLeft;
   //public Button upWUp;
   //public Button rightWCentre;
   //public Button rightWUp;
   //public Button rightWBottom;
   //public Button rightWRight;
   //public Button leftWCentre;
   //public Button leftWLeft;
   //public Button leftWUp;
   //public Button leftWBottom;
   //public Button bottomWCentre;
   //public Button bottomWBottom;
   //public Button bottomWRight;
   //public Button bottomWLeft;

   public List<Button> Buttons;
   public Button CurrentButton;

    // Use this for initialization
    void Start ()
    {
        Buttons.Add(centre);
        //Buttons.Add(up);
        //Buttons.Add(right);
        //Buttons.Add(left);
        //Buttons.Add(bottom);
        //Buttons.Add(upRight);
        //Buttons.Add(upLeft);
        //Buttons.Add(bottomRight);
        //Buttons.Add(bottomLeft);
        //Buttons.Add(upWCentre);
        //Buttons.Add(upWRight);
        //Buttons.Add(upWLeft);
        //Buttons.Add(upWUp);
        //Buttons.Add(rightWCentre);
        //Buttons.Add(rightWUp);
        //Buttons.Add(rightWBottom);
        //Buttons.Add(rightWRight);
        //Buttons.Add(leftWCentre);
        //Buttons.Add(leftWLeft);
        //Buttons.Add(leftWUp);
        //Buttons.Add(leftWBottom);
        //Buttons.Add(bottomWCentre);
        //Buttons.Add(bottomWBottom);
        //Buttons.Add(bottomWRight);
        //Buttons.Add(bottomWLeft);

        myImage.enabled = false;
        myButton.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Buttons.Count; ++i)
        {
            if (Buttons[i].GetComponent<ButtonHandlerOrigin>() != null)
            {
                if (Buttons[i].GetComponent<ButtonHandlerOrigin>().GetSendSelected() == true)
                {
                    CurrentButton = Buttons[i];
                    ToggleMenu();
                }
            }
        }

        if (myButton.GetComponent<AddSkillButton>().GetSendClick() == true)
        {
            CurrentButton.GetComponent<ButtonHandlerOrigin>().ToggleActive();
            myButton.GetComponent<AddSkillButton>().SetAdded(!myButton.GetComponent<AddSkillButton>().GetAdded());
            myButton.GetComponent<AddSkillButton>().SetSendClick(false);
        }
	}

    void ToggleMenu()
    {
        CurrentButton.GetComponent<ButtonHandlerOrigin>().SetSendSelected(false);
        myImage.enabled = !myImage.enabled;
        myButton.enabled = !myButton.enabled;
    }
}
