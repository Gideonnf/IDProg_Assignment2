using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// DOTween
using DG.Tweening;

public class Hotbar : MonoBehaviour {

    private bool hiding = true;
    private float hideYpos = 319.0f;
    private float showYpos = 228.0f;
    private RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void Move()
    {
        if (hiding)
            Show();
        else
            Hide();
    }


    // Funcion to Hide the Hotbar
    private void Hide()
    {
        rectTransform.DOAnchorPosY(hideYpos, 0.3f, true);
        hiding = true;
    }
    // Function to Show the Hotbar
    private void Show()
    {
        rectTransform.DOAnchorPosY(showYpos, 0.3f, true);
        hiding = false;
    }
}
