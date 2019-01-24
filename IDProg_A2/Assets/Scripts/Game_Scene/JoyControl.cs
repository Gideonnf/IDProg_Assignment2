using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoyControl : MonoBehaviour {

    // To change the Alpha of Image
    private Color originalColor, transparentColor;

    // Get the FG and BG of Joystick
    [SerializeField]
    private Image imgFG;
    [SerializeField]
    private Image imgBG;


    private void Start()
    {
        // Set Alpha
        originalColor = imgFG.color;
        transparentColor = originalColor;
        transparentColor.a = 0.1f;
        // Readjust Alpha
        imgBG.color = imgFG.color = transparentColor;
    }

    public void Dragging()
    {
        Vector3 newPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y,1);
        // Set the Pos first
        imgFG.rectTransform.position = newPos;
        // Clamp pos
        float newX = Mathf.Clamp(imgFG.rectTransform.anchoredPosition.x, -50, 50);
        float newY = Mathf.Clamp(imgFG.rectTransform.anchoredPosition.y, -50, 50);
        // Set pos
        imgFG.rectTransform.anchoredPosition = new Vector3(newX, newY, 1);

        // send movement to player
        PlayerMovement.GetInstance().JoyStickInput(newX * 0.5f, newY * 0.5f);
        // Readjust Alpha
        imgBG.color = imgFG.color = originalColor;
    }

    public void ReturnOrigin()
    {
        imgFG.rectTransform.anchoredPosition = new Vector3(0, 0, 1);
        // send movement to player
        PlayerMovement.GetInstance().JoyStickInput(0.0f, 0.0f);
        // Readjust Alpha
        imgBG.color = imgFG.color = transparentColor;
    }
}
