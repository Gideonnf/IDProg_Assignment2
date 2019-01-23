using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestDescriptionHandler : MonoBehaviour {

    public Image myImage;
    public Sprite Quest1Descrption;
    public Sprite Quest2Descrption;
    public Sprite Quest3Descrption;
    public Sprite Quest4Descrption;
    public Sprite Quest5Descrption;
    public Sprite Quest6Descrption;

    // Use this for initialization
    void Start () {	
	}
	
	// Update is called once per frame
	void Update () {	
	}

    public void SetImage(int QuestionNum)
    {
        if (QuestionNum == 1)
        {
            myImage.GetComponent<Image>().sprite = Quest1Descrption;
        }
        else if (QuestionNum == 2)
        {
            myImage.GetComponent<Image>().sprite = Quest2Descrption;
        }
        else if (QuestionNum == 3)
        {
            myImage.GetComponent<Image>().sprite = Quest3Descrption;
        }
        else if (QuestionNum == 4)
        {
            myImage.GetComponent<Image>().sprite = Quest4Descrption;
        }
        else if (QuestionNum == 5)
        {
            myImage.GetComponent<Image>().sprite = Quest5Descrption;
        }
        else if (QuestionNum == 6)
        {
            myImage.GetComponent<Image>().sprite = Quest6Descrption;
        }
    }
}
