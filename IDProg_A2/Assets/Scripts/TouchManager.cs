using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour {
    private GameObject[] InteractableUI; // Storing the game objects for scene changing

    // Use this for initialization
    void Start () {
        InteractableUI = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        { // Store into an array
            InteractableUI[i] = transform.GetChild(i).gameObject;
        }


    }

    // Update is called once per frame
    void Update () {
#if UNITY_ANDROID
        Touch myTouch = Input.GetTouch(0);
        Vector3 newpos = new Vector3(myTouch.position.x, myTouch.position.y, 1);
#else
        Vector3 newpos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1);
#endif

        Touch tch;
        Vector3 worldPoint;
        bool collided = false;

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (Application.platform == RuntimePlatform.Android)
                Application.Quit();
        }

        if (Input.touchCount == 1)
        {
            tch = Input.GetTouch(0);
            if (tch.phase == TouchPhase.Began)
            {
                for (int i = 0; i < InteractableUI.Length; ++i)
                {
                    Collider2D ColliderBox = InteractableUI[i].GetComponent<Collider2D>();
                    if (ColliderBox.bounds.Contains(tch.position))
                    {// Collided
                        //OnCollisionEnter2D(InteractableUI[i]);
                    }
                }
            }

        }

    }

    //private void OnCollisionEnter2D(GameObject collision)
    //{
    //    {

    //    }
    //    else if (collision.name == "Right")
    //    {

    //    }
    //    else if (collision.name == "Down")
    //    {

    //    }
    //}

}
