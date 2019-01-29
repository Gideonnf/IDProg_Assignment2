using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SceneTransition : MonoBehaviour {

    public enum Scenes
    {
        Main_Menu,
        Game_Scene,
        Map_Scene,
        JournalScene,
        InventoryScene,
        SkillsScene,
        CharacterScene,
        TotalScenes
    }

    public Scenes currentScene;
    public GameObject LeftScene;
    public GameObject RightScene;
    public GameObject GameScene;
    public GameObject[] InventoryRectObjects = new GameObject[2];
    private RectTransform[] InventoryRectTransform = new RectTransform[2];
	// Use this for initialization
	void Start () {
        if (currentScene == Scenes.InventoryScene)
        {
            // Only inventory screen has the need to scroll
            // So for now i check if it was tapped within this boxes
            for (int i = 0; i < InventoryRectObjects.Length; ++i)
            {
                InventoryRectTransform[i] = InventoryRectObjects[i].GetComponent<RectTransform>();
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		if (Swipe.GetInstance().GetSwipeRight())
        {
            LeftScene.gameObject.SetActive(true);
            LeftScene.GetComponent<RectTransform>().DOAnchorPosX(0, 0.4f, true);

            if (currentScene == Scenes.JournalScene)
            { // All the way to the left
                GetComponent<GoToNewScene>().GoToNewScene_INT_Timer((int)Scenes.CharacterScene, 0.4f);
            }
            else
            {

                GetComponent<GoToNewScene>().GoToNewScene_INT_Timer((int)currentScene - 1, 0.4f);

            }
        }
        else if (Swipe.GetInstance().GetSwipeLeft())
        {
            RightScene.gameObject.SetActive(true);
            RightScene.GetComponent<RectTransform>().DOAnchorPosX(0, 0.4f, true);

            if (currentScene == Scenes.CharacterScene)
            { // All the way to the left
                GetComponent<GoToNewScene>().GoToNewScene_INT_Timer((int)Scenes.JournalScene, 0.4f);
            }
            else
            {
                GetComponent<GoToNewScene>().GoToNewScene_INT_Timer((int)currentScene + 1, 0.4f);
            }
        }
        else if (Swipe.GetInstance().GetSwipeUp())
        {
            if (currentScene == Scenes.InventoryScene)
            {
                for (int i = 0; i < InventoryRectTransform.Length; ++i)
                {
                    if (RectTransformUtility.RectangleContainsScreenPoint(InventoryRectTransform[i], Swipe.GetInstance().GetLastTouchedPosition()))
                    {
                        return;
                    }
                }
                // Hard coded here for now because not enough time to change all the scenes to haev a collider box
                // for checking if they are going to swipe up
                // Only inventory has this issue
            }
            GameScene.gameObject.SetActive(true);
            GameScene.GetComponent<RectTransform>().DOAnchorPosY(0, 0.4f, true);

            GetComponent<GoToNewScene>().GoToNewScene_INT_Timer((int)Scenes.Game_Scene, 0.4f);
        }
    }
}
