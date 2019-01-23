using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// DOTween
using DG.Tweening;

public class OptionPannel : MonoBehaviour {

    private float minHeight = -2237.0f;
    private float maxHeight = -585.0f;
    private float minShortcutX = 459.0f;
    private float maxShortcutX = -33.0f;

    // For Storing of Own Position
    private RectTransform rectTransform;
    // For Storing of where the ShortCut Section is
    [SerializeField]
    private RectTransform shortCutSectionTransform;

    // Use this for initialization
    void Start () {
        rectTransform = GetComponent<RectTransform>();
    }
	
	// Update is called once per frame
	void Update () {

        // If at option Pannel...
        if (RotatePivot.GetInstance().GetPannelIndex() == 3 ||
            RotatePivot.GetInstance().GetPannelIndex() == 7)
        {
            // If a GO was Clicked
            if (Swipe.GetInstance().GetCurrentSelectedGO() != null)
            {
                // Detect Language Clicking
                DetectLanguageChange();
            }

            // Detect Up Swipe
            if (Swipe.GetInstance().GetSwipeUp())
            {
                float finalHeight = rectTransform.anchoredPosition.y + (Swipe.GetInstance().GetSwipeDelta().y * 9.0f);
                if (finalHeight > maxHeight)
                    rectTransform.DOAnchorPosY(maxHeight, 0.5f, true);
                else
                    rectTransform.DOAnchorPosY(finalHeight, 0.5f, true);

                Debug.Log("UP SWIPE!!");
            }
            // Detect Down Swipe
            else if (Swipe.GetInstance().GetSwipeDown())
            {
                float finalHeight = rectTransform.anchoredPosition.y - (Swipe.GetInstance().GetSwipeDelta().y * 9.0f);
                if (finalHeight < minHeight)
                    rectTransform.DOAnchorPosY(minHeight, 0.5f, true);
                else
                    rectTransform.DOAnchorPosY(finalHeight, 0.5f, true);

                Debug.Log("DOWN SWIPE!!");
            }


            // Detect Right Swipe
            if (Swipe.GetInstance().GetSwipeRight())
            {
                // if within the shortcut section and swiped
                if(RectTransformUtility.RectangleContainsScreenPoint(shortCutSectionTransform, Swipe.GetInstance().GetLastTouchedPosition()))
                {
                    shortCutSectionTransform.DOAnchorPosX(minShortcutX, 0.4f, true);
                }
            }
            // Detect Left Swipe
            else if (Swipe.GetInstance().GetSwipeLeft())
            {
                // if within the shortcut section and swiped
                if (RectTransformUtility.RectangleContainsScreenPoint(shortCutSectionTransform, Swipe.GetInstance().GetLastTouchedPosition()))
                {
                    shortCutSectionTransform.DOAnchorPosX(maxShortcutX, 0.4f, true);
                }
            }


        }   // End of Panel Checking

    }


    // Function to Check if 
    // A Language Flag was Selected
    private void DetectLanguageChange()
    {
        // check tapped which flag
        // 9 = Language Layer
        if (Swipe.GetInstance().GetCurrentSelectedGO().layer == 9)
        {
            // Find the Child with the script LanguageChange
            GameObject.Find("Language_IMG").GetComponent<LanguageChange>().ChangeLanguage(Swipe.GetInstance().GetCurrentSelectedGO().name);
        }

    }


    /*****************************************************************
    *       MOVING FUNCTIONS
    *****************************************************************/
    public void MoveToVolume()
    {
        rectTransform.DOAnchorPosY(minHeight, 0.5f, true);
    }
    public void MoveToNotifications()
    {
        rectTransform.DOAnchorPosY(-1520, 0.5f, true);
    }
    public void MoveToLanguage()
    {
        rectTransform.DOAnchorPosY(maxHeight, 0.5f, true);
    }

}
