using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScreens : MonoBehaviour {

    // To Store all posibile screens
    [SerializeField]
    private GameObject[] screens;
    // current screen index
    int currentScreenIndex;


	// Use this for initialization
	void Start () {
        currentScreenIndex = 0;
        // Deactivate all screens first
        for(int index = 0; index < screens.Length; ++index)
        {
            screens[index].SetActive(false);
        }
        // only activate currentScreen
        screens[currentScreenIndex].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

       

    }



    public void ChangeScreen()
    {
        // Deactivate last Screen
        screens[currentScreenIndex].SetActive(false);

        // Set new Index
        currentScreenIndex = GetOtherIndex();
        // Activate current Screen
        screens[currentScreenIndex].SetActive(true);
    }



    private int GetOtherIndex()
    {
        if (currentScreenIndex == 0)
            return 1;
        else
            return 0;
    }
}
