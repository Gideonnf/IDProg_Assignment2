using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapButton : MonoBehaviour {

    // For Storing of Images
    [SerializeField]
    private Sprite[] buttonState;
    // current state
    bool pressed;
    // Current Texture
    Image ownImage;

    // Use this for initialization
    void Start () {
        pressed = false;
        ownImage = GetComponent<Image>();
    }
	

    public void SwitchPressedState()
    {
        pressed = !pressed;

        // Change Texture
        if (!pressed)
            ownImage.sprite = buttonState[0];
        else
            ownImage.sprite = buttonState[1];

    }
}
