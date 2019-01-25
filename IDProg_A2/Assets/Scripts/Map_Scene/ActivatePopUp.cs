using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePopUp : MonoBehaviour {

    [SerializeField]
    private GameObject[] popUps;
    bool popActive;


	// Use this for initialization
	void Start () {
        popActive = false;
    }


    // Activate the GameObejct in the array Index
    public void OpenPopUp(int newIndex)
    {
        popUps[newIndex].SetActive(true);
        popActive = true;
    }
    // Deactivate the GameObejct in the array Index
    public void ClosePopUp(int newIndex)
    {
        popUps[newIndex].SetActive(false);
        popActive = false;
    }
    // Returns popActive Bool
    public bool GetPopActive()
    {
        return popActive;
    }

}
