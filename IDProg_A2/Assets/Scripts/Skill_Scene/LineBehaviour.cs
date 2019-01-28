using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineBehaviour : MonoBehaviour {

    public Image MyLine;
    public Button To;
    public Button From;
    public Image Glow;
    public Image NoGlow;

	// Use this for initialization
	void Start () {		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //if (To.GetComponent<ButtonHandlerTrio>() != null && From.GetComponent<ButtonHandlerOrigin>() != null)
        //{
        //    if (To.GetComponent<ButtonHandlerTrio>().GetActive() && From.GetComponent<ButtonHandlerOrigin>().GetActive())
        //    {
        //        MyLine = Glow;
        //    }
        //    else
        //    {
        //        MyLine = NoGlow;
        //    }
        //
        //}
    }
}
