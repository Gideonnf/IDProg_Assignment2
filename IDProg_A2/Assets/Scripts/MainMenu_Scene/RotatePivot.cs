using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    private bool rotating;
    private float rotateTime;
    private float rotatingTimer;
    float originalAlpha, transparentAlpha;
    // Option Page
    [SerializeField]
    private GameObject specialCase;
    private bool optionSide;
    private Vector2 startingPos, oppositePos;

    // Attach the Instance
    private void Awake()
    {
        m_Instance = this;
        optionSide = false;
        startingPos = new Vector2(2059.0f, 385.0f);
        oppositePos = new Vector2(-2036.0f, 385.0f);
        rotating = false;
        rotatingTimer = 0.0f;
        rotateTime = 0.6f;
    }

    // Use this for initialization
    void Start () {
        RotateAmount.Set(0, 45, 0);
        pannelIndex = 0;
        // Get the Alphas to be used later
        // when rotating
        originalAlpha = 1.0f;
        transparentAlpha = 0.3f;
        // Set beside pannels to transparent
        pannels[GetNextPannelIndex(pannelIndex)].GetComponent<CanvasGroup>().alpha = transparentAlpha;
        pannels[GetPreviousPannelIndex(pannelIndex)].GetComponent<CanvasGroup>().alpha = transparentAlpha;

    }

    // Update is called once per frame
    void Update () {

        DoneRotate();

        // if currently rotating, don't 
        // get new input
        if (rotating)
            return;

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
        transform.DORotate(-RotateAmount, rotateTime, RotateMode.LocalAxisAdd);
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
        transform.DORotate(RotateAmount, rotateTime, RotateMode.LocalAxisAdd);
        //Debug.Log("LEFT");
        // Do any necessary actions AFTER rotating
        AfterRotateAction();
    }
    private void DoneRotate()
    {
        // if still rotating,
        // reduce timer
        if(rotating)
        {
            rotatingTimer -= Time.deltaTime;
        }

        // Check if done rotating
        if(rotatingTimer < 0.0f)
        {
            // Can get new swipe input again
            rotating = false;
            rotatingTimer = 0.0f;
        }
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
        // Set beside pannels to opaque first
        pannels[GetNextPannelIndex(pannelIndex)].GetComponent<CanvasGroup>().alpha = originalAlpha;
        pannels[GetPreviousPannelIndex(pannelIndex)].GetComponent<CanvasGroup>().alpha = originalAlpha;
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
        // Set beside pannels to transparent
        pannels[GetNextPannelIndex(pannelIndex)].GetComponent<CanvasGroup>().alpha = transparentAlpha;
        pannels[GetPreviousPannelIndex(pannelIndex)].GetComponent<CanvasGroup>().alpha = transparentAlpha;

        // Check if we need to reposition the option page
        // as we only have one option page, in order to log down the users's settings
        if (optionSide)
        {
            // Only check for other side's pannels
            if (pannelIndex == 0 ||
                pannelIndex == 6)
            {
                specialCase.SetActive(true);
                specialCase.GetComponent<RectTransform>().anchoredPosition = startingPos;
                specialCase.GetComponent<RectTransform>().Rotate(new Vector3(0, 1, 0), 180);

                optionSide = false;
            }       
        }
        else
        {
            // Only check for other side's pannels
            if (pannelIndex == 2 ||
           pannelIndex == 4)
            {
                specialCase.SetActive(true);
                specialCase.GetComponent<RectTransform>().anchoredPosition = oppositePos;
                specialCase.GetComponent<RectTransform>().Rotate(new Vector3(0, 1, 0), -180);
                optionSide = true;
            }
        }
        // always set active as it will never be on the opposite 
        // side anymore as we are always moving it's position
        specialCase.SetActive(true);
        //specialCase.GetComponent<CanvasGroup>().alpha = originalAlpha;


        // Start rotating timer
        // to prevent mutliple rotations by player
        rotatingTimer = rotateTime;
        rotating = true;
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
