﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    // if player entered this area, he will take damage
    private void OnCollisionStay2D(Collision2D collision)
    {
        Stats.GetInstance().TakeDamage(1);
        // send movement to player to stop moving
        PlayerMovement.GetInstance().JoyStickInput(0.0f, 0.0f);
    }

}
