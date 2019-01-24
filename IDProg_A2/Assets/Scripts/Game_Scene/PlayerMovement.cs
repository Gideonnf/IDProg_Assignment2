using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

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

        currentTransform.position += (vel * Time.deltaTime);

	}


    public void JoyStickInput(float xDelta, float yDelta)
    {
        vel.x = xDelta;
        vel.y = yDelta;
    }
}
