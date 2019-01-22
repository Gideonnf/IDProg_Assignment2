using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// DOTween
using DG.Tweening;

public class OptionPannel : MonoBehaviour {

    private float minHeight = -2237.0f;
    private float maxHeight = -585.0f;
    private RectTransform rectTransform;

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

            // Detect Up Swipe
            if (Swipe.GetInstance().GetSwipeUp())
            {
                float finalHeight = rectTransform.anchoredPosition.y + (Swipe.GetInstance().GetSwipeDelta().y * 0.25f);
                if (finalHeight > maxHeight)
                    rectTransform.DOAnchorPosY(finalHeight, 0.5f, true);
                else
                    rectTransform.DOAnchorPosY(maxHeight, 0.5f, true);

                Debug.Log("UP SWIPE!!");
            }
            // Detect Down Swipe
            else if (Swipe.GetInstance().GetSwipeDown())
            {
                float finalHeight = rectTransform.anchoredPosition.y - (Swipe.GetInstance().GetSwipeDelta().y * 0.25f);
                if (finalHeight < minHeight)
                    rectTransform.DOAnchorPosY(finalHeight, 0.5f, true);
                else
                    rectTransform.DOAnchorPosY(minHeight, 0.5f, true);

                Debug.Log("DOWN SWIPE!!");
            }


        }

    }
}
