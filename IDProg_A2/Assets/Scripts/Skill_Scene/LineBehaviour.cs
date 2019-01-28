using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineBehaviour : MonoBehaviour {

    public Image MyLine;
    public Button To;
    public Button From;
    public Sprite Glow;
    public Sprite NoGlow;

	// Use this for initialization
	void Start () {

    }

    // Update is called once per frame
    void Update()
    {
        if (To.GetComponent<ButtonHandlerTrio>() != null && From.GetComponent<ButtonHandlerOrigin>() != null)
        {
            if (To.GetComponent<ButtonHandlerTrio>().GetActive() && From.GetComponent<ButtonHandlerOrigin>().GetActive())
            {
                MyLine.sprite = Glow;
            }
            else
            {
                MyLine.sprite = NoGlow;
            }
        }
        else if (To.GetComponent<ButtonHandlerTrio>() != null && From.GetComponent<ButtonHandlerTrio>() != null)
        {
            if (To.GetComponent<ButtonHandlerTrio>().GetActive() && From.GetComponent<ButtonHandlerTrio>().GetActive())
            {
                MyLine.sprite = Glow;
            }
            else
            {
                MyLine.sprite = NoGlow;
            }
        }
        else if (To.GetComponent<ButtonHandlerSolo>() != null && From.GetComponent<ButtonHandlerTrio>() != null)
        {
            if (To.GetComponent<ButtonHandlerSolo>().GetActive() && From.GetComponent<ButtonHandlerTrio>().GetActive())
            {
                MyLine.sprite = Glow;
            }
            else
            {
                MyLine.sprite = NoGlow;
            }
        }
        else if (To.GetComponent<ButtonHandlerDuo>() != null && From.GetComponent<ButtonHandlerTrio>() != null)
        {
            if (To.GetComponent<ButtonHandlerDuo>().GetActive() && From.GetComponent<ButtonHandlerTrio>().GetActive())
            {
                MyLine.sprite = Glow;
            }
            else
            {
                MyLine.sprite = NoGlow;
            }
        }
    }
}
