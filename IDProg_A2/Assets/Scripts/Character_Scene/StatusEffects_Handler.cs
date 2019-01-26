using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatusEffects_Handler : MonoBehaviour {
    private Character_Manager Character;
    public GameObject StatusText;
	// Use this for initialization
	void Start () {
        Character = GetComponentInParent<Character_Manager>();
	}
	
	// Update is called once per frame
	void Update () {
        string tempValue = "";
		foreach(int i in Character.StatusEffects)
        {
            switch((Character_Manager.StatusEffectTypes)i)
            {
                case Character_Manager.StatusEffectTypes.CrippledLeg:
                    {
                        tempValue = tempValue + "Crippled Leg\n";
                    }
                    break;
                case Character_Manager.StatusEffectTypes.Diarrhea:
                    {
                        tempValue = tempValue + "Diarrhea\n";
                    }
                    break;
                case Character_Manager.StatusEffectTypes.Flu:
                    {
                        tempValue = tempValue + "Flu\n";

                    }
                    break;
                case Character_Manager.StatusEffectTypes.CripplingDepression:
                    {
                        tempValue = tempValue + "Crippling Depression\n";
                    }
                    break;
            }
        }

        StatusText.GetComponent<TextMeshProUGUI>().text = tempValue;
	}
}
