using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// DOTween
using DG.Tweening;

public class RotatePivot : MonoBehaviour {

    private Vector3 RotateAmount;
    private int pannelIndex;
    [SerializeField]
    private GameObject[] pannels;

	// Use this for initialization
	void Start () {
        RotateAmount.Set(0, 45, 0);
        pannelIndex = 0;
    }
	
	// Update is called once per frame
	void Update () {
		
        // Detect Right Swipe
        if(Swipe.GetInstance().GetSwipeRight())
        {
            // Do any necessary actions BEFORE rotating
            BeforeSwipeAction();
            // Go to next Pannel Index
            pannelIndex = GetNextPannelIndex(pannelIndex);
            // Rotate
            transform.DORotate(-RotateAmount, 0.6f, RotateMode.LocalAxisAdd);
            Debug.Log("RIGHT");

            // Do any necessary actions AFTER rotating
            AfterSwipeAction();
        }
        // Detect Left Swipe
        else if(Swipe.GetInstance().GetSwipeLeft())
        {
            // Do any necessary actions BEFORE rotating
            BeforeSwipeAction();
            // Go to previous Pannel Index
            pannelIndex = GetPreviousPannelIndex(pannelIndex);
            // Rotate
            transform.DORotate(RotateAmount, 0.6f, RotateMode.LocalAxisAdd);
            Debug.Log("LEFT");

            // Do any necessary actions AFTER rotating
            AfterSwipeAction();
        }



	}

    private void BeforeSwipeAction()
    {
        int oppositeIndex = GetOppositePannel();
        // Set opposite and beside pannels to true first
        pannels[oppositeIndex].SetActive(true);
        pannels[GetNextPannelIndex(oppositeIndex)].SetActive(true);
        pannels[GetPreviousPannelIndex(oppositeIndex)].SetActive(true);
    }
    private void AfterSwipeAction()
    {
        int oppositeIndex = GetOppositePannel();
        // Set opposite and beside pannels to false
        // so won't render
        pannels[oppositeIndex].SetActive(false);
        pannels[GetNextPannelIndex(oppositeIndex)].SetActive(false);
        pannels[GetPreviousPannelIndex(oppositeIndex)].SetActive(false);
    }




    private int GetNextPannelIndex(int currentIndex)
    {
        currentIndex++;
        if (currentIndex >= pannels.Length)
            currentIndex = 0;
        // return new Index
        return currentIndex;
    }
    private int GetPreviousPannelIndex(int currentIndex)
    {
        currentIndex--;
        if (currentIndex < 0)
            currentIndex = pannels.Length - 1;
        // return new Index
        return currentIndex;
    }
    private int GetOppositePannel()
    {
        int oppositeIndex = pannelIndex;
        // If OverFlow
        if(oppositeIndex + 4 >= pannels.Length)
        {
            oppositeIndex = 4 - (pannels.Length - pannelIndex);
        }
        else
        {
            oppositeIndex += 4;
        }

        return oppositeIndex;
    }
}
