using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePopUp : MonoBehaviour {

    [SerializeField]
    private GameObject[] popUps;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void OpenPopUp(int newIndex)
    {
        popUps[newIndex].SetActive(true);
    }
    public void ClosePopUp(int newIndex)
    {
        popUps[newIndex].SetActive(false);
    }

}
