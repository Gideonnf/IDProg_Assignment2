using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // required when using UI elements in scripts

public class SkillTab : MonoBehaviour {

    public Image myImage;
    public Image myButton;
    public Image mySkillImage;
    public Text mySkillName;
    public Text mySkillDescription;

    public Button centre;
    public Button up;
    public Button right;
    public Button left;
    public Button bottom;
    public Button upRight;
    public Button upLeft;
    public Button bottomRight;
    public Button bottomLeft;
    public Button upWCentre;
    public Button upWRight;
    public Button upWLeft;
    public Button upWUp;
    public Button rightWCentre;
    public Button rightWUp;
    public Button rightWBottom;
    public Button rightWRight;
    public Button leftWCentre;
    public Button leftWLeft;
    public Button leftWUp;
    public Button leftWBottom;
    public Button bottomWCentre;
    public Button bottomWBottom;
    public Button bottomWRight;
    public Button bottomWLeft;

   public List<Button> Buttons;
   Button CurrentButton;

    // Use this for initialization
    void Start ()
    {
        Buttons.Add(centre);
        Buttons.Add(up);
        Buttons.Add(right);
        Buttons.Add(left);
        Buttons.Add(bottom);
        Buttons.Add(upRight);
        Buttons.Add(upLeft);
        Buttons.Add(bottomRight);
        Buttons.Add(bottomLeft);
        Buttons.Add(upWCentre);
        Buttons.Add(upWRight);
        Buttons.Add(upWLeft);
        Buttons.Add(upWUp);
        Buttons.Add(rightWCentre);
        Buttons.Add(rightWUp);
        Buttons.Add(rightWBottom);
        Buttons.Add(rightWRight);
        Buttons.Add(leftWCentre);
        Buttons.Add(leftWLeft);
        Buttons.Add(leftWUp);
        Buttons.Add(leftWBottom);
        Buttons.Add(bottomWCentre);
        Buttons.Add(bottomWBottom);
        Buttons.Add(bottomWRight);
        Buttons.Add(bottomWLeft);

        myImage.enabled = false;
        myButton.enabled = false;
        mySkillImage.enabled = false;
        mySkillName.enabled = false;
        mySkillDescription.enabled = false;
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
                    mySkillImage.sprite = Buttons[i].GetComponent<ButtonHandlerOrigin>().GetSprite();
                }
            }
            else if (Buttons[i].GetComponent<ButtonHandlerSolo>() != null)
            {
                if (Buttons[i].GetComponent<ButtonHandlerSolo>().GetSendSelected() == true)
                {
                    CurrentButton = Buttons[i];
                    ToggleMenu();
                    mySkillImage.sprite = Buttons[i].GetComponent<ButtonHandlerSolo>().GetSprite();
                }
            }
            else if (Buttons[i].GetComponent<ButtonHandlerDuo>() != null)
            {
                if (Buttons[i].GetComponent<ButtonHandlerDuo>().GetSendSelected() == true)
                {
                    CurrentButton = Buttons[i];
                    ToggleMenu();
                    mySkillImage.sprite = Buttons[i].GetComponent<ButtonHandlerDuo>().GetSprite();
                }
            }
            else if (Buttons[i].GetComponent<ButtonHandlerTrio>() != null)
            {
                if (Buttons[i].GetComponent<ButtonHandlerTrio>().GetSendSelected() == true)
                {
                    CurrentButton = Buttons[i];
                    ToggleMenu();
                    mySkillImage.sprite = Buttons[i].GetComponent<ButtonHandlerTrio>().GetSprite();
                }
            }
        }

        if (myButton.GetComponent<AddSkillButton>().GetSendClick() == true)
        {
            if (CurrentButton.GetComponent<ButtonHandlerOrigin>() != null)
            {
                CurrentButton.GetComponent<ButtonHandlerOrigin>().ToggleActive();
                myButton.GetComponent<AddSkillButton>().SetAdded(CurrentButton.GetComponent<ButtonHandlerOrigin>().GetActive());
            }
            else if (CurrentButton.GetComponent<ButtonHandlerSolo>() != null)
            {
                CurrentButton.GetComponent<ButtonHandlerSolo>().ToggleActive();
                myButton.GetComponent<AddSkillButton>().SetAdded(CurrentButton.GetComponent<ButtonHandlerSolo>().GetActive());
            }
            else if (CurrentButton.GetComponent<ButtonHandlerDuo>() != null)
            {
                CurrentButton.GetComponent<ButtonHandlerDuo>().ToggleActive();
                myButton.GetComponent<AddSkillButton>().SetAdded(CurrentButton.GetComponent<ButtonHandlerDuo>().GetActive());
            }
            else if (CurrentButton.GetComponent<ButtonHandlerTrio>() != null)
            {
                CurrentButton.GetComponent<ButtonHandlerTrio>().ToggleActive();
                myButton.GetComponent<AddSkillButton>().SetAdded(CurrentButton.GetComponent<ButtonHandlerTrio>().GetActive());
            }

            myButton.GetComponent<AddSkillButton>().SetSendClick(false);
        }
	}

    void ToggleMenu()
    {
        if (CurrentButton.GetComponent<ButtonHandlerOrigin>() != null)
        {
            CurrentButton.GetComponent<ButtonHandlerOrigin>().SetSendSelected(false);
            myButton.GetComponent<AddSkillButton>().SetAdded(CurrentButton.GetComponent<ButtonHandlerOrigin>().GetActive());
        }
        else if (CurrentButton.GetComponent<ButtonHandlerSolo>() != null)
        {
            CurrentButton.GetComponent<ButtonHandlerSolo>().SetSendSelected(false);
            myButton.GetComponent<AddSkillButton>().SetAdded(CurrentButton.GetComponent<ButtonHandlerSolo>().GetActive());
        }
        else if (CurrentButton.GetComponent<ButtonHandlerDuo>() != null)
        {
            CurrentButton.GetComponent<ButtonHandlerDuo>().SetSendSelected(false);
            myButton.GetComponent<AddSkillButton>().SetAdded(CurrentButton.GetComponent<ButtonHandlerDuo>().GetActive());
        }
        else if (CurrentButton.GetComponent<ButtonHandlerTrio>() != null)
        {
            CurrentButton.GetComponent<ButtonHandlerTrio>().SetSendSelected(false);
            myButton.GetComponent<AddSkillButton>().SetAdded(CurrentButton.GetComponent<ButtonHandlerTrio>().GetActive());
        }
        myImage.enabled = !myImage.enabled;
        myButton.enabled = !myButton.enabled;
        mySkillImage.enabled = !mySkillImage.enabled;
        mySkillName.enabled = !mySkillName.enabled;
        mySkillDescription.enabled = !mySkillDescription.enabled;
    }
}
