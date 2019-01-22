using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// DOTween
using DG.Tweening;

public class RotatePivot : MonoBehaviour {

    private Vector3 RotateAmount;

	// Use this for initialization
	void Start () {
        RotateAmount.Set(0, 45, 0);
    }
	
	// Update is called once per frame
	void Update () {
		
        // Detect Right Swipe
        if(Swipe.GetInstance().GetSwipeRight())
        {
            // Rotate
            transform.DORotate(RotateAmount, 0.6f, RotateMode.LocalAxisAdd);
            Debug.Log("ROTATING!!!!!");
        }
        // Detect Left Swipe
        else if(Swipe.GetInstance().GetSwipeLeft())
        {
            // Rotate
            transform.DORotate(-RotateAmount, 0.6f, RotateMode.LocalAxisAdd);
            Debug.Log("ROTATING!!!!!");
        }



	}


}
