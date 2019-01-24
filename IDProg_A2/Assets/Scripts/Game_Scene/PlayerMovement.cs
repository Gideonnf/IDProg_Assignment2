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
    Transform transform;


	// Use this for initialization
	void Start () {
        m_Instance = this;
        vel = Vector2.zero;
        transform = GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {

        transform.position += (vel * Time.deltaTime);

	}


    public void JoyStickInput(float xDelta, float yDelta)
    {
        vel.x = xDelta;
        vel.y = yDelta;
    }
}
