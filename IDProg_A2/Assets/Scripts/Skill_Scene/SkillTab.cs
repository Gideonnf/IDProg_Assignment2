using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class SkillTab : MonoBehaviour {

    public Text SkillPointNumber;

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

    Sprite SkillSlot1;
    Sprite SkillSlot2;
    Sprite SkillSlot3;
    Sprite SkillSlot4;
    Sprite SkillSlot5;
    Sprite SkillSlot6;
    Sprite SkillSlot7;
    Sprite SkillSlot8;
    Sprite SkillSlot9;
    public List<Sprite> SkillSlotsTotal;
    int CurrentSkillPage;

    int CurrentSlotNumber;

    public Image SkillIconLeft;
    public Image SkillIconCentre;
    public Image SkillIconRight;
    public List<Image> SkillIcons;

    public Sprite EmptySkillIcon;

    public Sprite CurrPage1;
    public Sprite CurrPage2;
    public Sprite CurrPage3;
    public Sprite NextPage2;
    public Sprite NextPage3;
    public Sprite PrevPage1;
    public Sprite PrevPage2;

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
   int CurrentButtonNumber;

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

        SkillSlotsTotal.Add(SkillSlot1);
        SkillSlotsTotal.Add(SkillSlot2);
        SkillSlotsTotal.Add(SkillSlot3);
        SkillSlotsTotal.Add(SkillSlot4);
        SkillSlotsTotal.Add(SkillSlot5);
        SkillSlotsTotal.Add(SkillSlot6);
        SkillSlotsTotal.Add(SkillSlot7);
        SkillSlotsTotal.Add(SkillSlot8);
        SkillSlotsTotal.Add(SkillSlot9);

        SkillIcons.Add(SkillIconLeft);
        SkillIcons.Add(SkillIconRight);
        SkillIcons.Add(SkillIconCentre);

        SkillSlotLeft.GetComponent<SkillSlot>().SetSelected(true);
        CurrentSkillSlot = SkillSlotLeft;
        CurrentSlotNumber = 0;

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
        SkillIconLeft.enabled = false;
        SkillIconRight.enabled = false;
        SkillIconCentre.enabled = false;

        CurrentSkillPage = 2;

        SkillSlot1 = EmptySkillIcon;
        SkillSlot2 = EmptySkillIcon;
        SkillSlot3 = EmptySkillIcon;
        SkillSlot4 = EmptySkillIcon;
        SkillSlot5 = EmptySkillIcon;
        SkillSlot6 = EmptySkillIcon;
        SkillSlot7 = EmptySkillIcon;
        SkillSlot8 = EmptySkillIcon;
        SkillSlot9 = EmptySkillIcon;
    }

    // Update is called once per frame
    void Update()
    {
        if (NextSkillSlots.GetComponent<SkillPage>().GetSendNext())
        {
            if (CurrentSkillPage == 1)
            {
                SkillSlot1 = SkillIcons[0].sprite;
                SkillSlot2 = SkillIcons[2].sprite;
                SkillSlot3 = SkillIcons[1].sprite;
            }
            else if (CurrentSkillPage == 2)
            {
                SkillSlot4 = SkillIcons[0].sprite;
                SkillSlot5 = SkillIcons[2].sprite;
                SkillSlot6 = SkillIcons[1].sprite;
            }

            CurrentSkillPage++;
            NextSkillSlots.GetComponent<SkillPage>().SendNextPage(false);

            if (CurrentSkillPage == 2)
            {
                PrevSkillSlots.enabled = true;
                PrevSkillSlots.sprite = PrevPage1;
                CurrSkillSlot.sprite = CurrPage2;
                NextSkillSlots.sprite = NextPage3;

                SkillIcons[0].sprite = SkillSlot4;
                SkillIcons[2].sprite = SkillSlot5;
                SkillIcons[1].sprite = SkillSlot6;
            }
            else if (CurrentSkillPage == 3)
            {
                PrevSkillSlots.sprite = PrevPage2;
                CurrSkillSlot.sprite = CurrPage3;
                NextSkillSlots.enabled = false;

                SkillIcons[0].sprite = SkillSlot7;
                SkillIcons[2].sprite = SkillSlot8;
                SkillIcons[1].sprite = SkillSlot9;
            }
        }
        else if (PrevSkillSlots.GetComponent<SkillPage>().GetSendPrev())
        {
            if (CurrentSkillPage == 2)
            {
                SkillSlot4 = SkillIcons[0].sprite;
                SkillSlot5 = SkillIcons[2].sprite;
                SkillSlot6 = SkillIcons[1].sprite;
            }
            else if (CurrentSkillPage == 3)
            {
                SkillSlot7 = SkillIcons[0].sprite;
                SkillSlot8 = SkillIcons[2].sprite;
                SkillSlot9 = SkillIcons[1].sprite;
            }

            CurrentSkillPage--;
            PrevSkillSlots.GetComponent<SkillPage>().SendPrevPage(false);

            if (CurrentSkillPage == 1)
            {
                PrevSkillSlots.enabled = false;
                CurrSkillSlot.sprite = CurrPage1;
                NextSkillSlots.sprite = NextPage2;

                SkillIcons[0].sprite = SkillSlot1;
                SkillIcons[2].sprite = SkillSlot2;
                SkillIcons[1].sprite = SkillSlot3;
            }
            else if (CurrentSkillPage == 2)
            {
                NextSkillSlots.enabled = true;
                PrevSkillSlots.sprite = PrevPage1;
                CurrSkillSlot.sprite = CurrPage2;
                NextSkillSlots.sprite = NextPage3;

                SkillIcons[0].sprite = SkillSlot4;
                SkillIcons[2].sprite = SkillSlot5;
                SkillIcons[1].sprite = SkillSlot6;
            }
        }
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
                if (i == 0)
                    CurrentSlotNumber = i;
                else if (i == 1)
                    CurrentSlotNumber = 2;
                else if (i == 2)
                    CurrentSlotNumber = 1;

                SetSelected();
                SkillSlots[i].GetComponent<SkillSlot>().SetSendSelected(false);
                ButtonMove();
            }
        }

        //Handles add skill button
        if (myButton.GetComponent<AddSkillButton>().GetSendClick() == true)
        {
            if (CurrentButton.GetComponent<ButtonHandlerOrigin>() != null)
            {
                if (myButton.GetComponent<AddSkillButton>().GetState() != 2)
                {
                    if (CurrentButton.GetComponent<ButtonHandlerOrigin>().GetActive())
                    {
                        SkillPointNumber.GetComponent<AvalibleSkillPoints>().SetAvalibleSkillPoints(SkillPointNumber.GetComponent<AvalibleSkillPoints>().GetAvalibleSkillPoints() + 1);
                        CurrentButton.GetComponent<ButtonHandlerOrigin>().ToggleActive();
                    }
                    else
                    {
                        if (SkillPointNumber.GetComponent<AvalibleSkillPoints>().GetAvalibleSkillPoints() > 0)
                        {
                            SkillPointNumber.GetComponent<AvalibleSkillPoints>().SetAvalibleSkillPoints(SkillPointNumber.GetComponent<AvalibleSkillPoints>().GetAvalibleSkillPoints() - 1);
                            CurrentButton.GetComponent<ButtonHandlerOrigin>().ToggleActive();
                        }
                    }
                   
                    if (CurrentButton.GetComponent<ButtonHandlerOrigin>().GetActive() == true)
                        myButton.GetComponent<AddSkillButton>().SetState(1);
                    if (CurrentButton.GetComponent<ButtonHandlerOrigin>().GetActive() == false)
                        myButton.GetComponent<AddSkillButton>().SetState(0);
                }
            }
            else if (CurrentButton.GetComponent<ButtonHandlerSolo>() != null)
            {
                if (myButton.GetComponent<AddSkillButton>().GetState() != 2)
                {
                    CurrentButton.GetComponent<ButtonHandlerSolo>().ToggleActive();

                    if (CurrentButton.GetComponent<ButtonHandlerSolo>().GetActive() == true)
                    {
                        ChangeSkillIcon(0);
                        myButton.GetComponent<AddSkillButton>().SetState(1);
                    }
                    if (CurrentButton.GetComponent<ButtonHandlerSolo>().GetActive() == false)
                    {
                        SkillIcons[CurrentSlotNumber].sprite = EmptySkillIcon;
                        myButton.GetComponent<AddSkillButton>().SetState(0);
                    }
                }
                else
                {
                    ChangeSkillIcon(0);
                }
            }
            else if (CurrentButton.GetComponent<ButtonHandlerDuo>() != null)
            {
                if (myButton.GetComponent<AddSkillButton>().GetState() != 2)
                {
                    CurrentButton.GetComponent<ButtonHandlerDuo>().ToggleActive();

                    if (CurrentButton.GetComponent<ButtonHandlerDuo>().GetActive() == true)
                    {
                        ChangeSkillIcon(1);
                        myButton.GetComponent<AddSkillButton>().SetState(1);
                    }
                    if (CurrentButton.GetComponent<ButtonHandlerDuo>().GetActive() == false)
                    {
                        SkillIcons[CurrentSlotNumber].sprite = EmptySkillIcon;
                        myButton.GetComponent<AddSkillButton>().SetState(0);
                    }
                }
                else
                {
                    ChangeSkillIcon(1);
                }
            }
            else if (CurrentButton.GetComponent<ButtonHandlerTrio>() != null)
            {
                if (myButton.GetComponent<AddSkillButton>().GetState() != 2)
                {
                    CurrentButton.GetComponent<ButtonHandlerTrio>().ToggleActive();

                    if (CurrentButton.GetComponent<ButtonHandlerTrio>().GetActive() == true)
                    {
                        ChangeSkillIcon(2);
                        myButton.GetComponent<AddSkillButton>().SetState(1);
                    }
                    if (CurrentButton.GetComponent<ButtonHandlerTrio>().GetActive() == false)
                    {
                        SkillIcons[CurrentSlotNumber].sprite = EmptySkillIcon;
                        myButton.GetComponent<AddSkillButton>().SetState(0);
                    }
                }
                else
                {
                    ChangeSkillIcon(2);
                }                
            }       
            myButton.GetComponent<AddSkillButton>().SetSendClick(false);
        }

        //Handles some skill switching
        for (int i = 0; i < Buttons.Count; ++i)
        {
         if (Buttons[i].GetComponent<ButtonHandlerSolo>() != null)
            {
                for (int j = 0; j < SkillIcons.Count; ++j)
                {
                    if (SkillIcons[j].sprite == Buttons[i].GetComponent<ButtonHandlerSolo>().GetSpriteInactive())
                    {
                        if (Buttons[i].interactable == false || Buttons[i].GetComponent<ButtonHandlerSolo>().GetActive() == false)
                        {
                            SkillIcons[j].sprite = EmptySkillIcon;
                        }
                    }
                }
            }
            else if (Buttons[i].GetComponent<ButtonHandlerDuo>() != null)
            {
                for (int j = 0; j < SkillIcons.Count; ++j)
                {
                    if (SkillIcons[j].sprite == Buttons[i].GetComponent<ButtonHandlerDuo>().GetSpriteInactive())
                    {
                        if (Buttons[i].interactable == false || Buttons[i].GetComponent<ButtonHandlerDuo>().GetActive() == false)
                        {
                            SkillIcons[j].sprite = EmptySkillIcon;
                        }
                    }
                }
            }
            else if (Buttons[i].GetComponent<ButtonHandlerTrio>() != null)
            {
                for (int j = 0; j < SkillIcons.Count; ++j)
                {
                    if (SkillIcons[j].sprite == Buttons[i].GetComponent<ButtonHandlerTrio>().GetSpriteInactive())
                    {
                        if (Buttons[i].interactable == false || Buttons[i].GetComponent<ButtonHandlerTrio>().GetActive() == false)
                        {
                            SkillIcons[j].sprite = EmptySkillIcon;
                        }
                    }
                }
            }
        }
    }

    void ToggleMenu()
    {
        if (CurrentButton.GetComponent<ButtonHandlerOrigin>() != null)
        {
            CurrentButton.GetComponent<ButtonHandlerOrigin>().SetSendSelected(false);

            if (CurrentButton.GetComponent<ButtonHandlerOrigin>().GetActive() == true)
                myButton.GetComponent<AddSkillButton>().SetState(1);
            if (CurrentButton.GetComponent<ButtonHandlerOrigin>().GetActive() == false)
                myButton.GetComponent<AddSkillButton>().SetState(0);
            
        }
        else if (CurrentButton.GetComponent<ButtonHandlerSolo>() != null)
        {
            CurrentButton.GetComponent<ButtonHandlerSolo>().SetSendSelected(false);

            if (SkillIcons[CurrentSlotNumber].sprite == CurrentButton.GetComponent<ButtonHandlerSolo>().GetSpriteInactive() && CurrentButton.GetComponent<ButtonHandlerSolo>().GetActive() == true)
            {
                myButton.GetComponent<AddSkillButton>().SetState(1);
            }
            else if (SkillIcons[CurrentSlotNumber].sprite != CurrentButton.GetComponent<ButtonHandlerSolo>().GetSpriteInactive() && CurrentButton.GetComponent<ButtonHandlerSolo>().GetActive() == true)
            {
                myButton.GetComponent<AddSkillButton>().SetState(2);
            }
            else if (CurrentButton.GetComponent<ButtonHandlerSolo>().GetActive() == false)
            {
                myButton.GetComponent<AddSkillButton>().SetState(0);
            }

        }
        else if (CurrentButton.GetComponent<ButtonHandlerDuo>() != null)
        {
            CurrentButton.GetComponent<ButtonHandlerDuo>().SetSendSelected(false);

            if (SkillIcons[CurrentSlotNumber].sprite == CurrentButton.GetComponent<ButtonHandlerDuo>().GetSpriteInactive() && CurrentButton.GetComponent<ButtonHandlerDuo>().GetActive() == true)
            {
                myButton.GetComponent<AddSkillButton>().SetState(1);
            }
            else if (SkillIcons[CurrentSlotNumber].sprite != CurrentButton.GetComponent<ButtonHandlerDuo>().GetSpriteInactive() && CurrentButton.GetComponent<ButtonHandlerDuo>().GetActive() == true)
            {
                myButton.GetComponent<AddSkillButton>().SetState(2);
            }
            else if (CurrentButton.GetComponent<ButtonHandlerDuo>().GetActive() == false)
            {
                myButton.GetComponent<AddSkillButton>().SetState(0);
            }
        }
        else if (CurrentButton.GetComponent<ButtonHandlerTrio>() != null)
        {
            CurrentButton.GetComponent<ButtonHandlerTrio>().SetSendSelected(false);


            if (SkillIcons[CurrentSlotNumber].sprite == CurrentButton.GetComponent<ButtonHandlerTrio>().GetSpriteInactive() && CurrentButton.GetComponent<ButtonHandlerTrio>().GetActive() == true)
            {
                myButton.GetComponent<AddSkillButton>().SetState(1);
            }
            else if (SkillIcons[CurrentSlotNumber].sprite != CurrentButton.GetComponent<ButtonHandlerTrio>().GetSpriteInactive() && CurrentButton.GetComponent<ButtonHandlerTrio>().GetActive() == true)
            {
                myButton.GetComponent<AddSkillButton>().SetState(2);
            }
            else if (CurrentButton.GetComponent<ButtonHandlerTrio>().GetActive() == false)
            {
                myButton.GetComponent<AddSkillButton>().SetState(0);
            }
                     
        }
        myImage.enabled = !myImage.enabled;
        myButton.enabled = !myButton.enabled;
        mySkillImage.enabled = !mySkillImage.enabled;
        mySkillName.enabled = !mySkillName.enabled;
        mySkillDescription.enabled = !mySkillDescription.enabled;

        if (CurrentSkillPage == 1)
        {
            NextSkillSlots.enabled = !NextSkillSlots.enabled;
        }
        else if (CurrentSkillPage == 2)
        {
            NextSkillSlots.enabled = !NextSkillSlots.enabled;
            PrevSkillSlots.enabled = !PrevSkillSlots.enabled;
        }
        else if (CurrentSkillPage == 3)
        {
            PrevSkillSlots.enabled = !PrevSkillSlots.enabled;
        }

        CurrSkillSlot.enabled = !CurrSkillSlot.enabled;


        SkillSlotLeft.enabled = !SkillSlotLeft.enabled;
        SkillSlotCentre.enabled = !SkillSlotCentre.enabled;
        SkillSlotRight.enabled = !SkillSlotRight.enabled;
        SkillIconLeft.enabled = !SkillIconLeft.enabled;
        SkillIconRight.enabled = !SkillIconRight.enabled;
        SkillIconCentre.enabled = !SkillIconCentre.enabled;
    }

    public void SetSelected()
    {
        for (int i = 0; i < SkillSlots.Count; ++i)
        {
            SkillSlots[i].GetComponent<SkillSlot>().SetSelected(false);
        }
        CurrentSkillSlot.GetComponent<SkillSlot>().SetSelected(true);
    }

    void ChangeSkillIcon(int Case)
    {
        if (SkillIcons[CurrentSlotNumber].sprite != EmptySkillIcon)
        {
            for (int j = 0; j < Buttons.Count; ++j)
            {
                if (Buttons[j] != CurrentButton)
                {
                    if (Buttons[j].GetComponent<ButtonHandlerSolo>() != null)
                    {
                        if (Buttons[j].GetComponent<ButtonHandlerSolo>().GetSpriteInactive() == SkillIcons[CurrentSlotNumber].sprite)
                        {
                            Buttons[j].GetComponent<ButtonHandlerSolo>().ToggleActive();
                        }
                    }
                    else if (Buttons[j].GetComponent<ButtonHandlerDuo>() != null)
                    {
                        if (Buttons[j].GetComponent<ButtonHandlerDuo>().GetSpriteInactive() == SkillIcons[CurrentSlotNumber].sprite)
                        {
                            Buttons[j].GetComponent<ButtonHandlerDuo>().ToggleActive();
                        }
                    }
                    else if (Buttons[j].GetComponent<ButtonHandlerTrio>() != null)
                    {
                        if (Buttons[j].GetComponent<ButtonHandlerTrio>().GetSpriteInactive() == SkillIcons[CurrentSlotNumber].sprite)
                        {
                           Buttons[j].GetComponent<ButtonHandlerTrio>().ToggleActive();                            
                        }
                    }
                }
            }
        }

        switch (Case)
        {
            case 0:
                for (int i = 0; i < SkillIcons.Count; ++i)
                {
                    if (SkillIcons[i].sprite == CurrentButton.GetComponent<ButtonHandlerSolo>().GetSpriteInactive())
                    { 
                        SkillIcons[i].sprite = EmptySkillIcon;
                    }
                }
                SkillIcons[CurrentSlotNumber].sprite = CurrentButton.GetComponent<ButtonHandlerSolo>().GetSpriteInactive();
                break;
            case 1:
                for (int i = 0; i < SkillIcons.Count; ++i)
                {
                    if (SkillIcons[i].sprite == CurrentButton.GetComponent<ButtonHandlerDuo>().GetSpriteInactive())
                        SkillIcons[i].sprite = EmptySkillIcon;
                }
                SkillIcons[CurrentSlotNumber].sprite = CurrentButton.GetComponent<ButtonHandlerDuo>().GetSpriteInactive();
                break;
            case 2:
                for (int i = 0; i < SkillIcons.Count; ++i)
                {
                    if (SkillIcons[i].sprite == CurrentButton.GetComponent<ButtonHandlerTrio>().GetSpriteInactive())
                        SkillIcons[i].sprite = EmptySkillIcon;
                }
                SkillIcons[CurrentSlotNumber].sprite = CurrentButton.GetComponent<ButtonHandlerTrio>().GetSpriteInactive();
                break;
        }
    }

    void ButtonMove()
    {
        if (CurrentButton.GetComponent<ButtonHandlerSolo>() != null)
        {
            if (CurrentButton.GetComponent<ButtonHandlerSolo>().GetActive())
            {
                if (CurrentButton.GetComponent<ButtonHandlerSolo>().GetSpriteInactive() != SkillIcons[CurrentSlotNumber].sprite)
                    myButton.GetComponent<AddSkillButton>().SetState(2);
                else if (CurrentButton.GetComponent<ButtonHandlerSolo>().GetSpriteInactive() == SkillIcons[CurrentSlotNumber].sprite)
                    myButton.GetComponent<AddSkillButton>().SetState(1);
            }
        }
        else if (CurrentButton.GetComponent<ButtonHandlerDuo>() != null)
        {
            if (CurrentButton.GetComponent<ButtonHandlerDuo>().GetActive())
            {
                if (CurrentButton.GetComponent<ButtonHandlerDuo>().GetSpriteInactive() != SkillIcons[CurrentSlotNumber].sprite)
                    myButton.GetComponent<AddSkillButton>().SetState(2);
                else if (CurrentButton.GetComponent<ButtonHandlerDuo>().GetSpriteInactive() == SkillIcons[CurrentSlotNumber].sprite)
                    myButton.GetComponent<AddSkillButton>().SetState(1);
            }
        }
        else if (CurrentButton.GetComponent<ButtonHandlerTrio>() != null)
        {
            if (CurrentButton.GetComponent<ButtonHandlerTrio>().GetActive())
            {
                if (CurrentButton.GetComponent<ButtonHandlerTrio>().GetSpriteInactive() != SkillIcons[CurrentSlotNumber].sprite)
                    myButton.GetComponent<AddSkillButton>().SetState(2);
                else if (CurrentButton.GetComponent<ButtonHandlerTrio>().GetSpriteInactive() == SkillIcons[CurrentSlotNumber].sprite)
                    myButton.GetComponent<AddSkillButton>().SetState(1);
            }
        }
    }
}
