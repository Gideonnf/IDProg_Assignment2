using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageChange : MonoBehaviour {

    // For Storing of Images
    [SerializeField]
    private Sprite[] notSelected;
    [SerializeField]
    private Sprite[] Selected;
    // For Storing of which Language was selected
    [SerializeField]
    private GameObject[] languages;
    private int languageIndex;

    // Use this for initialization
    void Start () {
        // set new index
        languageIndex = 0;
        // set new sprite
        languages[languageIndex].GetComponent<Image>().sprite = Selected[languageIndex];
    }
	
	// Update is called once per frame
	void Update () {
		
	}



    public void ChangeLanguage(string newName)
    {
        for(int x = 0; x < languages.Length; ++x)
        {
            if(languages[x].name == newName)
            {
                // reset old sprite
                languages[languageIndex].GetComponent<Image>().sprite = notSelected[languageIndex];
                // set new sprite
                languages[x].GetComponent<Image>().sprite = Selected[x];
                // set new index
                languageIndex = x;
                break;
            }
        }


    }
}
