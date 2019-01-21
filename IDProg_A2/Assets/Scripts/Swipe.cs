using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour {

    private bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
    private bool isDragging = false;
    private Vector2 startTouch, swipeDelta;

    private void Update()
    {
        tap = swipeLeft = swipeRight = swipeUp = swipeDown = false;

        #region Standalone Inputs
        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            isDragging = true;
            startTouch = Input.mousePosition;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            Reset();
            isDragging = false;
        }
        #endregion

        #region Mobile Inputs
        // Any touches on the screen
        if(Input.touches.Length > 0)
        {
            // take the first touch, 
            // check if we touched on this frame
            if(Input.touches[0].phase == TouchPhase.Began)
            {
                tap = true;
                isDragging = true;
                startTouch = Input.touches[0].position;
            }
            else if(Input.touches[0].phase == TouchPhase.Ended ||
                Input.touches[0].phase == TouchPhase.Canceled)
            {
                Reset();
                isDragging = false;
            }
        }
        #endregion

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
                    Debug.Log("LEFTT");
                }
                else
                {
                    swipeRight = true;
                    Debug.Log("RIGHTTT");
                }
            }
            else
            {
                // Up or Down
                if (y < 0)
                {
                    swipeDown = true;
                    Debug.Log("DOOWN");
                }
                else
                {
                    swipeUp = true;
                    Debug.Log("UPP");
                }
            }

            Reset();
        }
    }

    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDragging = false;
    }




    public Vector2 GetSwipeDelta { get { return swipeDelta; } }
    public bool GetSwipeLeft { get { return swipeLeft; } }
    public bool GetSwipeRight { get { return swipeRight; } }
    public bool GetSwipeUp { get { return swipeUp; } }
    public bool GetSwipeDown { get { return swipeDown; } }

}
