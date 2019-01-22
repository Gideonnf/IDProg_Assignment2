using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// DOTween
using DG.Tweening;

public class RotatePivot : MonoBehaviour {

    // Static Instance
    private static RotatePivot m_Instance;
    public static RotatePivot GetInstance()
    {
        return m_Instance;
    }

    // Rotation Related
    private Vector3 RotateAmount;
    private int pannelIndex;
    [SerializeField]
    private GameObject[] pannels;
    [SerializeField]
    private GameObject specialCase;
    private bool optionSide;

    // Attach the Instance
    private void Awake()
    {
        m_Instance = this;
        optionSide = false;
    }

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
            GameObject lastHitGo = Swipe.GetInstance().GetCurrentSelectedGO();

            if (lastHitGo == null)
                RotateRight();
            else if (lastHitGo.tag != "EditableUI")
                RotateRight();

        }
        // Detect Left Swipe
        else if(Swipe.GetInstance().GetSwipeLeft())
        {
            GameObject lastHitGo = Swipe.GetInstance().GetCurrentSelectedGO();

            if (lastHitGo == null)
                RotateLeft();
            else if (lastHitGo.tag != "EditableUI")
                RotateLeft();
        }



	}



    private void RotateRight()
    {
        // Do any necessary actions BEFORE rotating
        BeforeRotateAction();
        // Go to next Pannel Index
        pannelIndex = GetNextPannelIndex(pannelIndex);
        // Rotate
        transform.DORotate(-RotateAmount, 0.6f, RotateMode.LocalAxisAdd);
        //Debug.Log("RIGHT");
        // Do any necessary actions AFTER rotating
        AfterRotateAction();
    }
    private void RotateLeft()
    {
        // Do any necessary actions BEFORE rotating
        BeforeRotateAction();
        // Go to previous Pannel Index
        pannelIndex = GetPreviousPannelIndex(pannelIndex);
        // Rotate
        transform.DORotate(RotateAmount, 0.6f, RotateMode.LocalAxisAdd);
        //Debug.Log("LEFT");
        // Do any necessary actions AFTER rotating
        AfterRotateAction();
    }




    /******************************************************************
    *      MISC FUNCTIONS
    ******************************************************************/
    // Any Actions to Take BEFORE rotating
    private void BeforeRotateAction()
    {
        int oppositeIndex = GetOppositePannel();
        // Set opposite and beside pannels to true first
        pannels[oppositeIndex].SetActive(true);
        pannels[GetNextPannelIndex(oppositeIndex)].SetActive(true);
        pannels[GetPreviousPannelIndex(oppositeIndex)].SetActive(true);
    }
    // Any Actions to Take AFTER rotating
    private void AfterRotateAction()
    {
        int oppositeIndex = GetOppositePannel();
        // Set opposite and beside pannels to false
        // so won't render
        pannels[oppositeIndex].SetActive(false);
        pannels[GetNextPannelIndex(oppositeIndex)].SetActive(false);
        pannels[GetPreviousPannelIndex(oppositeIndex)].SetActive(false);

        // Check if we need to reposition the option page
        // as we only have one option page, in order to log down the users's settings
        if (optionSide)
        {
            if (pannelIndex == 0 ||
                pannelIndex == 6)
            {
                specialCase.SetActive(true);
                specialCase.GetComponent<RectTransform>().anchoredPosition = new Vector2(2059.0f, 385.0f);
                specialCase.GetComponent<RectTransform>().Rotate(new Vector3(0, 1, 0), 180);

                optionSide = false;
            }       
        }
        else
        {
            if (pannelIndex == 2 ||
           pannelIndex == 4)
            {
                specialCase.SetActive(true);
                specialCase.GetComponent<RectTransform>().anchoredPosition = new Vector2(-2036.0f, 0.0f);
                specialCase.GetComponent<RectTransform>().Rotate(new Vector3(0, 1, 0), -180);
                optionSide = true;
            }
        }
        specialCase.SetActive(true);


    }
    // Travese to Next Pannel Index in Array
    private int GetNextPannelIndex(int currentIndex)
    {
        currentIndex++;
        if (currentIndex >= pannels.Length)
            currentIndex = 0;
        // return new Index
        return currentIndex;
    }
    // Travese to Previous Pannel Index in Array
    private int GetPreviousPannelIndex(int currentIndex)
    {
        currentIndex--;
        if (currentIndex < 0)
            currentIndex = pannels.Length - 1;
        // return new Index
        return currentIndex;
    }
    // Return the Opposite Array Index based on current pannelIndex
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


    // Get the Pannel Index
    public int GetPannelIndex()
    {
        return pannelIndex;
    }

    /******************************************************************/
}
