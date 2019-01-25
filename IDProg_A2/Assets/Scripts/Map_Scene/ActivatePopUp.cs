using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// DOTween
using DG.Tweening;

public class ActivatePopUp : MonoBehaviour {

    [SerializeField]
    private GameObject[] popUps;
    bool popActive;
    float startCloseTimer;
    int closeIndex;

	// Use this for initialization
	void Start () {
        popActive = false;
        startCloseTimer = -1.0f;
        closeIndex = -1;
        // make all transparent first
        for(int index = 0; index  <popUps.Length; ++index)
        {
            popUps[index].GetComponent<CanvasGroup>().DOFade(0.0f, 0.1f);
        }
    }

    private void Update()
    {
        // If no timer started, don't update
        if (startCloseTimer == -1.0f)
            return;

        startCloseTimer -= Time.deltaTime;
        if (startCloseTimer < 0.0f)
        {
            startCloseTimer = 0.0f;
            DeactivatePopUp();
        }
    }


    // Activate the GameObejct in the array Index
    public void OpenPopUp(int newIndex)
    {
        // Deactivate PopUp regardless of timer 
        // to make way for new one
        DeactivatePopUp();

        // Activate new PopUp
        popUps[newIndex].SetActive(true);
        popUps[newIndex].GetComponent<CanvasGroup>().DOFade(1.0f, 0.3f);
        popActive = true;
    }
    // Deactivate the GameObejct in the array Index
    // after fading is done
    public void ClosePopUp(int newIndex)
    {
        float fadeTime = 0.3f;
        // Set the data
        closeIndex = newIndex;
        startCloseTimer = fadeTime;
        // Fade
        popUps[newIndex].GetComponent<CanvasGroup>().DOFade(0.0f, fadeTime);
    }
    // Returns popActive Bool
    public bool GetPopActive()
    {
        return popActive;
    }


    // Deactivate the last opened PopUp in the array Index
    private void DeactivatePopUp()
    {
        // if closed already
        if (startCloseTimer == -1.0f)
            return;

        popUps[closeIndex].SetActive(false);
        popActive = false;
        startCloseTimer = -1.0f;
    }
}
