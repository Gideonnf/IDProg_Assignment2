using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvalibleSkillPoints : MonoBehaviour
{
    public Text myText;
    int AvalibleSkillPointsNumber;

    // Use this for initialization
    void Start () {
        AvalibleSkillPointsNumber = 5;
    }
	
	// Update is called once per frame
	void Update () {
        myText.text = AvalibleSkillPointsNumber.ToString();
    }

    public void SetAvalibleSkillPoints(int Input)
    {
        AvalibleSkillPointsNumber = Input;
    }

    public int GetAvalibleSkillPoints()
    {
        return AvalibleSkillPointsNumber;
    }
}
