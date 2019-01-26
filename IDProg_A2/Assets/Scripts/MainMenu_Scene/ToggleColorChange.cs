using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ToggleColorChange : MonoBehaviour {

    [SerializeField]
    private ColorBlock selected, notSelected;
	
    public void ChangeColor()
    {
        if (GetComponent<Toggle>().isOn)
            GetComponent<Toggle>().colors = selected;
        else
            GetComponent<Toggle>().colors = notSelected;
    }
}
