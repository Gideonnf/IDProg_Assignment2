using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// DOTween
using DG.Tweening;


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
        // Check if there any popUps active now
        if (GetComponent<ActivatePopUp>().GetPopActive())
            return;

        // Detect Up Swipe
        if (Swipe.GetInstance().GetSwipeUp())
        {
            // NO active PopUps, so go to GameScene
            //// Activate FAKE GameScreen
            //screens[2].SetActive(true);

            //float slideUpTime = 0.4f;
            //// DOTween the screens up
            //GameObject.Find("MapStuff").GetComponent<RectTransform>().DOAnchorPosY(1682.0f, slideUpTime, true);
            //// Start Timer to Change Scene
            //GetComponent<GoToNewScene>().GoToNewScene_STRING_Timer("Game_Scene", slideUpTime);
            GoToFakeGameScene();
        }


    }



    // Called by other classes to change
    // the screen
    public void ChangeScreen()
    {
        // Deactivate last Screen
        screens[currentScreenIndex].SetActive(false);

        // Set new Index
        currentScreenIndex = GetOtherIndex();
        // Activate current Screen
        screens[currentScreenIndex].SetActive(true);
    }
    // Called by other classes to change
    // to GameScene
    public void GoToFakeGameScene()
    {
        // Activate FAKE GameScreen
        screens[2].SetActive(true);

        float slideUpTime = 0.4f;
        // DOTween the screens up
        GameObject.Find("MapStuff").GetComponent<RectTransform>().DOAnchorPosY(1682.0f, slideUpTime, true);
        // Start Timer to Change Scene
        GetComponent<GoToNewScene>().GoToNewScene_STRING_Timer("Game_Scene", slideUpTime);
    }


    // Get Possible Screens to traverse to
    // In this case, only 2 as we are not including
    // the GameSceneOBJ as part of the MapScene
    private int GetOtherIndex()
    {
        if (currentScreenIndex == 0)
            return 1;
        else
            return 0;
    }
}
