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
	// Use this for initialization
	void Start () {
		
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
            GameScene.gameObject.SetActive(true);
            GameScene.GetComponent<RectTransform>().DOAnchorPosY(0, 0.4f, true);

            GetComponent<GoToNewScene>().GoToNewScene_INT_Timer((int)Scenes.Game_Scene, 0.4f);
        }
    }
}
