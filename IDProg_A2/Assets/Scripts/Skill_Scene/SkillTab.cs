using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class SkillTab : MonoBehaviour {

    public Image myImage;
    public Image myButton;
    public Image mySkillImage;
    public Text mySkillName;
    public Text mySkillDescription;

    public Image CurrSkillSlot;
    public Image NextSkillSlots;
    public Image PrevSkillSlots;

    public Image SkillSlotLeft;
    public Image SkillSlotCentre;
    public Image SkillSlotRight;
    public List<Image> SkillSlots;
    Image CurrentSkillSlot;
 
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

        SkillSlots.Add(SkillSlotLeft);
        SkillSlots.Add(SkillSlotCentre);
        SkillSlots.Add(SkillSlotRight);

        SkillSlotLeft.GetComponent<SkillSlot>().SetSelected(true);
        CurrentSkillSlot = SkillSlotLeft;

        myImage.enabled = false;
        myButton.enabled = false;
        mySkillImage.enabled = false;
        mySkillName.enabled = false;
        mySkillDescription.enabled = false;

        CurrSkillSlot.enabled = false;
        NextSkillSlots.enabled = false;
        PrevSkillSlots.enabled = false;
        SkillSlotLeft.enabled = false;
        SkillSlotCentre.enabled = false;
        SkillSlotRight.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        //Handles open and close of skill tab menu
        for (int i = 0; i < Buttons.Count; ++i)
        {
            if (Buttons[i].GetComponent<ButtonHandlerOrigin>() != null)
            {
                if (Buttons[i].GetComponent<ButtonHandlerOrigin>().GetSendSelected() == true)
                {
                    CurrentButton = Buttons[i];
                    ToggleMenu();
                    mySkillImage.sprite = Buttons[i].GetComponent<ButtonHandlerOrigin>().GetSpriteActive();
                }
            }
            else if (Buttons[i].GetComponent<ButtonHandlerSolo>() != null)
            {
                if (Buttons[i].GetComponent<ButtonHandlerSolo>().GetSendSelected() == true)
                {
                    CurrentButton = Buttons[i];
                    ToggleMenu();
                    mySkillImage.sprite = Buttons[i].GetComponent<ButtonHandlerSolo>().GetSpriteActive();
                }
            }
            else if (Buttons[i].GetComponent<ButtonHandlerDuo>() != null)
            {
                if (Buttons[i].GetComponent<ButtonHandlerDuo>().GetSendSelected() == true)
                {
                    CurrentButton = Buttons[i];
                    ToggleMenu();
                    mySkillImage.sprite = Buttons[i].GetComponent<ButtonHandlerDuo>().GetSpriteActive();
                }
            }
            else if (Buttons[i].GetComponent<ButtonHandlerTrio>() != null)
            {
                if (Buttons[i].GetComponent<ButtonHandlerTrio>().GetSendSelected() == true)
                {
                    CurrentButton = Buttons[i];
                    ToggleMenu();
                    mySkillImage.sprite = Buttons[i].GetComponent<ButtonHandlerTrio>().GetSpriteActive();
                }
            }
        }

        //Handles Skill Slot
        for (int i = 0; i < SkillSlots.Count; ++i)
        {
            if (SkillSlots[i].GetComponent<SkillSlot>().GetSendSelected() == true)
            {
                CurrentSkillSlot = SkillSlots[i];
                SetSelected();
                SkillSlots[i].GetComponent<SkillSlot>().SetSendSelected(false);
            }
        }

        //Handles add skill button
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

                //CurrentSkillSlot.sprite = CurrentButton.GetComponent<ButtonHandlerSolo>().GetSpriteInactive();
            }
            else if (CurrentButton.GetComponent<ButtonHandlerDuo>() != null)
            {
                CurrentButton.GetComponent<ButtonHandlerDuo>().ToggleActive();
                myButton.GetComponent<AddSkillButton>().SetAdded(CurrentButton.GetComponent<ButtonHandlerDuo>().GetActive());

                //CurrentSkillSlot.sprite = CurrentButton.GetComponent<ButtonHandlerDuo>().GetSpriteInactive();
            }
            else if (CurrentButton.GetComponent<ButtonHandlerTrio>() != null)
            {
                CurrentButton.GetComponent<ButtonHandlerTrio>().ToggleActive();
                myButton.GetComponent<AddSkillButton>().SetAdded(CurrentButton.GetComponent<ButtonHandlerTrio>().GetActive());

               // CurrentSkillSlot.sprite = CurrentButton.GetComponent<ButtonHandlerTrio>().GetSpriteInactive();
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

        CurrSkillSlot.enabled = !CurrSkillSlot.enabled;
        NextSkillSlots.enabled = !NextSkillSlots.enabled;
        PrevSkillSlots.enabled = !PrevSkillSlots.enabled;
        SkillSlotLeft.enabled = !SkillSlotLeft.enabled;
        SkillSlotCentre.enabled = !SkillSlotCentre.enabled;
        SkillSlotRight.enabled = !SkillSlotRight.enabled; 
    }

    public void SetSelected()
    {
        for (int i = 0; i < SkillSlots.Count; ++i)
        {
            SkillSlots[i].GetComponent<SkillSlot>().SetSelected(false);
        }
        CurrentSkillSlot.GetComponent<SkillSlot>().SetSelected(true);
    }
}
