using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionPannel : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
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

                Debug.Log("UP SWIPE!!");
            }
            // Detect Down Swipe
            else if (Swipe.GetInstance().GetSwipeDown())
            {
                Debug.Log("DOWN SWIPE!!");
            }


        }

    }
}
