using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Manager : MonoBehaviour {
    //  public string[] StatusEffects = new string[3];
    public enum StatusEffectTypes
    {
        CrippledLeg,
        Diarrhea,
        Flu,
        CripplingDepression,
        TotalTypes
    }
    public List<int> StatusEffects = new List<int>();
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp("1"))
        { // Testing
            if (!AddStatusEffects(0))
                RemoveStatusEffects(0);
        }
        else if (Input.GetKeyUp("2"))
        { // Testing
            if (!AddStatusEffects(1))
                RemoveStatusEffects(1);
        }
       else  if (Input.GetKeyUp("3"))
        { // Testing
            if (!AddStatusEffects(2))
                RemoveStatusEffects(2);
        }
        else if (Input.GetKeyUp("4"))
        { // Testing
            if (!AddStatusEffects(3))
                RemoveStatusEffects(3);
        }

    }

    public bool RemoveStatusEffects(int i)
    {
        StatusEffects.Remove(i);
        return true;
    }

    public bool AddStatusEffects(int i)
    {
        //int i = 0;
        foreach(int it in StatusEffects)
        {
            if (it == i)
            {
                // It exist in the current list
                return false;
            }
        }

        // It doesnt ecist
        StatusEffects.Add(i);
        return true;
    }
}
