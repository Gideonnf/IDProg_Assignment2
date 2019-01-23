using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandlerJournalQuests : MonoBehaviour {

    public Button Quest1;
    public Button Quest2;
    public Button Quest3;
    public Button Quest4;
    public Button Quest5;
    public Button Quest6;

    public Button Tracking;
    public Image QuestDescription;

    // Use this for initialization
    void Start () {
        Quest1.GetComponent<ButtonHandlerJournalQuest>().SetHighlighted(true);
        Quest2.GetComponent<ButtonHandlerJournalQuest>().SetHighlighted(false);
        Quest3.GetComponent<ButtonHandlerJournalQuest>().SetHighlighted(false);
        Quest4.GetComponent<ButtonHandlerJournalQuest>().SetHighlighted(false);
        Quest5.GetComponent<ButtonHandlerJournalQuest>().SetHighlighted(false);
        Quest6.GetComponent<ButtonHandlerJournalQuest>().SetHighlighted(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Quest1.GetComponent<ButtonHandlerJournalQuest>().GetMakeHighlighted() == true
            || Quest2.GetComponent<ButtonHandlerJournalQuest>().GetMakeHighlighted() == true
            || Quest3.GetComponent<ButtonHandlerJournalQuest>().GetMakeHighlighted() == true
            || Quest4.GetComponent<ButtonHandlerJournalQuest>().GetMakeHighlighted() == true
            || Quest5.GetComponent<ButtonHandlerJournalQuest>().GetMakeHighlighted() == true
            || Quest6.GetComponent<ButtonHandlerJournalQuest>().GetMakeHighlighted() == true)
        {
            UpdateHighlightedQuest();
        }

        if (Tracking.GetComponent<ButtonHandlerTracker>().GetMakeAdded() == true)
        {
            UpdateAddedQuest();
        }
    }

    void UpdateHighlightedQuest()
    {
        if (Quest1.GetComponent<ButtonHandlerJournalQuest>().GetMakeHighlighted() == true)
        {
            Quest1.GetComponent<ButtonHandlerJournalQuest>().SetHighlighted(true);
            Quest2.GetComponent<ButtonHandlerJournalQuest>().SetHighlighted(false);
            Quest3.GetComponent<ButtonHandlerJournalQuest>().SetHighlighted(false);
            Quest4.GetComponent<ButtonHandlerJournalQuest>().SetHighlighted(false);
            Quest5.GetComponent<ButtonHandlerJournalQuest>().SetHighlighted(false);
            Quest6.GetComponent<ButtonHandlerJournalQuest>().SetHighlighted(false);

            QuestDescription.GetComponent<QuestDescriptionHandler>().SetImage(1);
            Quest1.GetComponent<ButtonHandlerJournalQuest>().SendMakeHighlighted(false);
        }
        else if (Quest2.GetComponent<ButtonHandlerJournalQuest>().GetMakeHighlighted() == true)
        {
            Quest1.GetComponent<ButtonHandlerJournalQuest>().SetHighlighted(false);
            Quest2.GetComponent<ButtonHandlerJournalQuest>().SetHighlighted(true);
            Quest3.GetComponent<ButtonHandlerJournalQuest>().SetHighlighted(false);
            Quest4.GetComponent<ButtonHandlerJournalQuest>().SetHighlighted(false);
            Quest5.GetComponent<ButtonHandlerJournalQuest>().SetHighlighted(false);
            Quest6.GetComponent<ButtonHandlerJournalQuest>().SetHighlighted(false);

            QuestDescription.GetComponent<QuestDescriptionHandler>().SetImage(2);
            Quest2.GetComponent<ButtonHandlerJournalQuest>().SendMakeHighlighted(false);
        }
        else if (Quest3.GetComponent<ButtonHandlerJournalQuest>().GetMakeHighlighted() == true)
        {
            Quest1.GetComponent<ButtonHandlerJournalQuest>().SetHighlighted(false);
            Quest2.GetComponent<ButtonHandlerJournalQuest>().SetHighlighted(false);
            Quest3.GetComponent<ButtonHandlerJournalQuest>().SetHighlighted(true);
            Quest4.GetComponent<ButtonHandlerJournalQuest>().SetHighlighted(false);
            Quest5.GetComponent<ButtonHandlerJournalQuest>().SetHighlighted(false);
            Quest6.GetComponent<ButtonHandlerJournalQuest>().SetHighlighted(false);

            QuestDescription.GetComponent<QuestDescriptionHandler>().SetImage(3);
            Quest3.GetComponent<ButtonHandlerJournalQuest>().SendMakeHighlighted(false);
        }
        else if (Quest4.GetComponent<ButtonHandlerJournalQuest>().GetMakeHighlighted() == true)
        {
            Quest1.GetComponent<ButtonHandlerJournalQuest>().SetHighlighted(false);
            Quest2.GetComponent<ButtonHandlerJournalQuest>().SetHighlighted(false);
            Quest3.GetComponent<ButtonHandlerJournalQuest>().SetHighlighted(false);
            Quest4.GetComponent<ButtonHandlerJournalQuest>().SetHighlighted(true);
            Quest5.GetComponent<ButtonHandlerJournalQuest>().SetHighlighted(false);
            Quest6.GetComponent<ButtonHandlerJournalQuest>().SetHighlighted(false);


            QuestDescription.GetComponent<QuestDescriptionHandler>().SetImage(4);
            Quest4.GetComponent<ButtonHandlerJournalQuest>().SendMakeHighlighted(false);
        }
        else if (Quest5.GetComponent<ButtonHandlerJournalQuest>().GetMakeHighlighted() == true)
        {
            Quest1.GetComponent<ButtonHandlerJournalQuest>().SetHighlighted(false);
            Quest2.GetComponent<ButtonHandlerJournalQuest>().SetHighlighted(false);
            Quest3.GetComponent<ButtonHandlerJournalQuest>().SetHighlighted(false);
            Quest4.GetComponent<ButtonHandlerJournalQuest>().SetHighlighted(false);
            Quest5.GetComponent<ButtonHandlerJournalQuest>().SetHighlighted(true);
            Quest6.GetComponent<ButtonHandlerJournalQuest>().SetHighlighted(false);

            QuestDescription.GetComponent<QuestDescriptionHandler>().SetImage(5);
            Quest5.GetComponent<ButtonHandlerJournalQuest>().SendMakeHighlighted(false);
        }
        else if (Quest6.GetComponent<ButtonHandlerJournalQuest>().GetMakeHighlighted() == true)
        {
            Quest1.GetComponent<ButtonHandlerJournalQuest>().SetHighlighted(false);
            Quest2.GetComponent<ButtonHandlerJournalQuest>().SetHighlighted(false);
            Quest3.GetComponent<ButtonHandlerJournalQuest>().SetHighlighted(false);
            Quest4.GetComponent<ButtonHandlerJournalQuest>().SetHighlighted(false);
            Quest5.GetComponent<ButtonHandlerJournalQuest>().SetHighlighted(false);
            Quest6.GetComponent<ButtonHandlerJournalQuest>().SetHighlighted(true);

            QuestDescription.GetComponent<QuestDescriptionHandler>().SetImage(6);
            Quest6.GetComponent<ButtonHandlerJournalQuest>().SendMakeHighlighted(false);
        }
        UpdateTrackerImage();
    }

    void UpdateAddedQuest()
    {
        if (Quest1.GetComponent<ButtonHandlerJournalQuest>().GetHighlighted() == true)
        {
            Quest1.GetComponent<ButtonHandlerJournalQuest>().ToggleAdded();
            Quest2.GetComponent<ButtonHandlerJournalQuest>().SetAdded(false);
            Quest3.GetComponent<ButtonHandlerJournalQuest>().SetAdded(false);
            Quest4.GetComponent<ButtonHandlerJournalQuest>().SetAdded(false);
            Quest5.GetComponent<ButtonHandlerJournalQuest>().SetAdded(false);
            Quest6.GetComponent<ButtonHandlerJournalQuest>().SetAdded(false);
        }
        else if (Quest2.GetComponent<ButtonHandlerJournalQuest>().GetHighlighted() == true)
        {
            Quest1.GetComponent<ButtonHandlerJournalQuest>().SetAdded(false);
            Quest2.GetComponent<ButtonHandlerJournalQuest>().ToggleAdded();
            Quest3.GetComponent<ButtonHandlerJournalQuest>().SetAdded(false);
            Quest4.GetComponent<ButtonHandlerJournalQuest>().SetAdded(false);
            Quest5.GetComponent<ButtonHandlerJournalQuest>().SetAdded(false);
            Quest6.GetComponent<ButtonHandlerJournalQuest>().SetAdded(false);
        }
        else if (Quest3.GetComponent<ButtonHandlerJournalQuest>().GetHighlighted() == true)
        {
            Quest1.GetComponent<ButtonHandlerJournalQuest>().SetAdded(false);
            Quest2.GetComponent<ButtonHandlerJournalQuest>().SetAdded(false);
            Quest3.GetComponent<ButtonHandlerJournalQuest>().ToggleAdded();
            Quest4.GetComponent<ButtonHandlerJournalQuest>().SetAdded(false);
            Quest5.GetComponent<ButtonHandlerJournalQuest>().SetAdded(false);
            Quest6.GetComponent<ButtonHandlerJournalQuest>().SetAdded(false);
        }
        else if (Quest4.GetComponent<ButtonHandlerJournalQuest>().GetHighlighted() == true)
        {
            Quest1.GetComponent<ButtonHandlerJournalQuest>().SetAdded(false);
            Quest2.GetComponent<ButtonHandlerJournalQuest>().SetAdded(false);
            Quest3.GetComponent<ButtonHandlerJournalQuest>().SetAdded(false);
            Quest4.GetComponent<ButtonHandlerJournalQuest>().ToggleAdded();
            Quest5.GetComponent<ButtonHandlerJournalQuest>().SetAdded(false);
            Quest6.GetComponent<ButtonHandlerJournalQuest>().SetAdded(false);
        }
        else if (Quest5.GetComponent<ButtonHandlerJournalQuest>().GetHighlighted() == true)
        {
            Quest1.GetComponent<ButtonHandlerJournalQuest>().SetAdded(false);
            Quest2.GetComponent<ButtonHandlerJournalQuest>().SetAdded(false);
            Quest3.GetComponent<ButtonHandlerJournalQuest>().SetAdded(false);
            Quest4.GetComponent<ButtonHandlerJournalQuest>().SetAdded(false);
            Quest5.GetComponent<ButtonHandlerJournalQuest>().ToggleAdded();
            Quest6.GetComponent<ButtonHandlerJournalQuest>().SetAdded(false);
        }
        else if (Quest6.GetComponent<ButtonHandlerJournalQuest>().GetHighlighted() == true)
        {
            Quest1.GetComponent<ButtonHandlerJournalQuest>().SetAdded(false);
            Quest2.GetComponent<ButtonHandlerJournalQuest>().SetAdded(false);
            Quest3.GetComponent<ButtonHandlerJournalQuest>().SetAdded(false);
            Quest4.GetComponent<ButtonHandlerJournalQuest>().SetAdded(false);
            Quest5.GetComponent<ButtonHandlerJournalQuest>().SetAdded(false);
            Quest6.GetComponent<ButtonHandlerJournalQuest>().ToggleAdded();            
        }

        UpdateTrackerImage();
        Tracking.GetComponent<ButtonHandlerTracker>().SendMakeAdded(false);
    }

    void UpdateTrackerImage()
    {
        if (Quest1.GetComponent<ButtonHandlerJournalQuest>().GetHighlighted() == true)
        {
            if (Quest1.GetComponent<ButtonHandlerJournalQuest>().GetAdded() == true)
            {
                Tracking.GetComponent<ButtonHandlerTracker>().SetAdded(true);
            }
            else if (Quest1.GetComponent<ButtonHandlerJournalQuest>().GetAdded() == false)
            {
                Tracking.GetComponent<ButtonHandlerTracker>().SetAdded(false);
            }
        }
        else if (Quest2.GetComponent<ButtonHandlerJournalQuest>().GetHighlighted() == true)
        {
            if (Quest2.GetComponent<ButtonHandlerJournalQuest>().GetAdded() == true)
            {
                Tracking.GetComponent<ButtonHandlerTracker>().SetAdded(true);
            }
            else if (Quest2.GetComponent<ButtonHandlerJournalQuest>().GetAdded() == false)
            {
                Tracking.GetComponent<ButtonHandlerTracker>().SetAdded(false);
            }
        }
        else if (Quest3.GetComponent<ButtonHandlerJournalQuest>().GetHighlighted() == true)
        {
            if (Quest3.GetComponent<ButtonHandlerJournalQuest>().GetAdded() == true)
            {
                Tracking.GetComponent<ButtonHandlerTracker>().SetAdded(true);
            }
            else if (Quest3.GetComponent<ButtonHandlerJournalQuest>().GetAdded() == false)
            {
                Tracking.GetComponent<ButtonHandlerTracker>().SetAdded(false);
            }
        }
        else if (Quest4.GetComponent<ButtonHandlerJournalQuest>().GetHighlighted() == true)
        {
            if (Quest4.GetComponent<ButtonHandlerJournalQuest>().GetAdded() == true)
            {
                Tracking.GetComponent<ButtonHandlerTracker>().SetAdded(true);
            }
            else if (Quest4.GetComponent<ButtonHandlerJournalQuest>().GetAdded() == false)
            {
                Tracking.GetComponent<ButtonHandlerTracker>().SetAdded(false);
            }
        }
        else if (Quest5.GetComponent<ButtonHandlerJournalQuest>().GetHighlighted() == true)
        {
            if (Quest5.GetComponent<ButtonHandlerJournalQuest>().GetAdded() == true)
            {
                Tracking.GetComponent<ButtonHandlerTracker>().SetAdded(true);
            }
            else if (Quest5.GetComponent<ButtonHandlerJournalQuest>().GetAdded() == false)
            {
                Tracking.GetComponent<ButtonHandlerTracker>().SetAdded(false);
            }
        }
        else if (Quest6.GetComponent<ButtonHandlerJournalQuest>().GetHighlighted() == true)
        {
            if (Quest6.GetComponent<ButtonHandlerJournalQuest>().GetAdded() == true)
            {
                Tracking.GetComponent<ButtonHandlerTracker>().SetAdded(true);
            }
            else if (Quest6.GetComponent<ButtonHandlerJournalQuest>().GetAdded() == false)
            {
                Tracking.GetComponent<ButtonHandlerTracker>().SetAdded(false);
            }
        }
    }
}
