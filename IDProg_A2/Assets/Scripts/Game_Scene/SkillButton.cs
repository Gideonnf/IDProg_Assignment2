using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void SkillUsed()
    {
        Debug.Log("USED!!");
        // Make all the attacking buttons be opaque as skills have been used
        gameObject.GetComponentInParent<AttackButton>().BeOpaque();
    }
}
