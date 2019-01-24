using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// DOTween
using DG.Tweening;
using UnityEngine.UI;

public class AttackButton : MonoBehaviour {

    private float opaqueTimer, maxOpaqueTimer;
    [SerializeField]
    private GameObject button;

	// Use this for initialization
	void Start () {
        opaqueTimer = 0.0f;
        maxOpaqueTimer = 4.0f;
        BeTransparent();
    }
	
	// Update is called once per frame
	void Update () {

        // already opaque, so no need check
        if (opaqueTimer <= 0.0f)
            return;


        // When timer is up, go back to transparent
        opaqueTimer -= Time.deltaTime;
        if (opaqueTimer < 0.0f)
            BeTransparent();
	}



    public void BeOpaque()
    {
        button.GetComponent<CanvasGroup>().DOFade(1.0f, 0.2f);
        // Set Opaque Timer 
        opaqueTimer = maxOpaqueTimer;
    }

    public void BeTransparent()
    {
        button.GetComponent<CanvasGroup>().DOFade(0.5f, 0.6f);
        // Reset Opaque Timer
        opaqueTimer = 0.0f;
    }
}
