using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoyControl : MonoBehaviour {

    [SerializeField]
    private Image imgFG;

    [SerializeField]
    private Image imgBG;

  
	public void Dragging()
    {
        Vector3 newPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y,1);
        imgFG.rectTransform.position = newPos;

        float newX = Mathf.Clamp(imgFG.rectTransform.anchoredPosition.x, -50, 50);
        float newY = Mathf.Clamp(imgFG.rectTransform.anchoredPosition.y, -50, 50);

        imgFG.rectTransform.anchoredPosition = new Vector3(newX, newY, 1);
        
    }

    public void ReturnOrigin()
    {
        imgFG.rectTransform.anchoredPosition = new Vector3(0, 0, 1);
    }
}
