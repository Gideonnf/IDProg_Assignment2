using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    // MiniMap
    [SerializeField]
    private RectTransform miniMapTransform;
    // Static Instance
    private static PlayerMovement m_Instance;
    public static PlayerMovement GetInstance()
    {
        return m_Instance;
    }
    // Other Variables
    Vector3 vel;
    Transform currentTransform;


	// Use this for initialization
	void Start () {
        m_Instance = this;
        vel = Vector2.zero;
        currentTransform = GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {

        // Update own position
        currentTransform.position += (vel * Time.deltaTime);

        // Update minimap position
        UpdateMiniMap();
    }


    public void JoyStickInput(float xDelta, float yDelta)
    {
        vel.x = xDelta;
        vel.y = yDelta;
    }


    private void UpdateMiniMap()
    {
        // get the vel and reverse it, as the axis is reverted
        Vector2 mapVel = vel * 0.7f;
        mapVel.x *= 0.5f;
        mapVel = -mapVel;
        //translate it
        miniMapTransform.anchoredPosition += (mapVel * Time.deltaTime);

        //Vector3 newPos;
        //newPos = currentTransform.localPosition;
        //newPos.x += 47.9f;
        //newPos.y += 116.6f;
        //miniMapTransform.anchoredPosition = newPos;
    }
}
