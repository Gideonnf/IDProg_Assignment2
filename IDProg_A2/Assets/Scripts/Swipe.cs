using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;
// DOTween
using DG.Tweening;

public class Swipe : MonoBehaviour
{
    // Static Instance
    private static Swipe m_Instance;
    public static Swipe GetInstance()
    {
        return m_Instance;
    }

    // Storing the game object we collided with
    private GameObject m_currentSelectedGO;

    // Graphics Raycasting
    GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    [SerializeField]
    EventSystem m_EventSystem;

    // Input Related
    private bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
    private bool isDragging = false;
    private Vector2 startTouch, swipeDelta, lastTouchedPos;


    // Awake is called before all Starts..
    private void Awake()
    {
        m_Instance = this;
        // Init DOTween for Other Classes
        DOTween.Init();
    }

    // Start is called after all Awakes
    private void Start()
    {
        //Fetch the Raycaster from the GameObject (the Canvas)
        m_Raycaster = GetComponent<GraphicRaycaster>();
        //Fetch the Event System from the Scene
        //m_EventSystem = GetComponent<EventSystem>();
    }

    private void Update()
    {
        tap = swipeLeft = swipeRight = swipeUp = swipeDown = false;
        //tap = false;

        #region Standalone Inputs
        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            isDragging = true;
            startTouch = Input.mousePosition;
            lastTouchedPos = startTouch;
            //Debug.Log("TAPPP");
            CheckCollidedWithGO(startTouch);
        }
        else if(Input.GetMouseButtonUp(0))
        {
            Reset();
            isDragging = false;
            // Reset Selected GO
            m_currentSelectedGO = null;
        }
        #endregion

        #region Mobile Inputs
        // Any touches on the screen
        if (Input.touches.Length > 0)
        {
            // take the first touch, 
            // check if we touched on this frame
            if(Input.touches[0].phase == TouchPhase.Began)
            {
                tap = true;
                isDragging = true;
                startTouch = Input.touches[0].position;
                lastTouchedPos = startTouch;
                // Get Collided GO
                CheckCollidedWithGO(startTouch);
            }
            else if(Input.touches[0].phase == TouchPhase.Ended ||
                Input.touches[0].phase == TouchPhase.Canceled)
            {
                Reset();
                isDragging = false;
                // Reset Selected GO
                m_currentSelectedGO = null;
            }
        }
        #endregion


        #region Swiping
        // Calculate the Distance
        swipeDelta = Vector2.zero;
        if(isDragging)
        {
            if (Input.touches.Length > 0)
                swipeDelta = Input.touches[0].position - startTouch;
            else if (Input.GetMouseButton(0))
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
        }

        // Check if we crossed the deadZone
        if(swipeDelta.magnitude > 50)
        {
            // Check which direction was the swipe
            float x = swipeDelta.x;
            float y = swipeDelta.y;

            // Check which direction was the largest
            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                // Left or Right
                if (x < 0)
                {
                    swipeLeft = true;
                    //Debug.Log("LEFTT");
                }
                else
                {
                    swipeRight = true;
                    //Debug.Log("RIGHTTT");
                }
            }
            else
            {
                // Up or Down
                if (y < 0)
                {
                    swipeDown = true;
                    //Debug.Log("DOOWN");
                }
                else
                {
                    swipeUp = true;
                    //Debug.Log("UPP");
                }
            }

            Reset();
        }
        #endregion
    }

    private void Reset()
    {
        startTouch /*= swipeDelta*/ = Vector2.zero;
        isDragging = false;
    }

    private GameObject CheckCollidedWithGO(Vector3 touchedPosition)
    {
        // reset selectedGO
        m_currentSelectedGO = null;
        //Set up the new Pointer Event
        m_PointerEventData = new PointerEventData(m_EventSystem);
        //Set the Pointer Event Position to that of the mouse position
        m_PointerEventData.position = touchedPosition;//Input.mousePosition;

        //Create a list of Raycast Results
        List<RaycastResult> results = new List<RaycastResult>();

        //Raycast using the Graphics Raycaster and mouse click position
        m_Raycaster.Raycast(m_PointerEventData, results);

        //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
        foreach (RaycastResult result in results)
        {
            //Debug.Log("Hit " + result.gameObject.name);

            // Attach the collided GO
            m_currentSelectedGO = result.gameObject;
            // To make sure only detect the first UI Hit
            break;
        }

        // return result
        return m_currentSelectedGO;
    }

    
    public Vector2 GetSwipeDelta() { return swipeDelta; }
    public GameObject GetCurrentSelectedGO() { return m_currentSelectedGO; }
    public Vector2 GetLastTouchedPosition() { return lastTouchedPos; }
    public bool GetTap() { return tap; }
    public bool GetSwipeLeft() { return swipeLeft; }
    public bool GetSwipeRight() { return swipeRight; }
    public bool GetSwipeUp() { return swipeUp; }
    public bool GetSwipeDown() { return swipeDown; }

}
