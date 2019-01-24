using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour {

    [SerializeField]
    private Image coolDownImage;
    private bool used;
    private float coolDownTime;

	// Use this for initialization
	void Start () {
        used = false;
        coolDownTime = 4.0f;
    }


    public void Update()
    {
        if (!used)
            return;

        // Reduce the fill amount on the image
        coolDownImage.fillAmount -= 1.0f / coolDownTime * Time.deltaTime;
        if(coolDownImage.fillAmount <= 0.0f)
        {
            coolDownImage.fillAmount = 0.0f;
            used = false;
        }

    }

    public void SkillUsed()
    {
        if (used)
            return;

        // Make all the attacking buttons be opaque as skills have been used
        gameObject.GetComponentInParent<AttackButton>().BeOpaque();

        // Use up some mana
        Stats.GetInstance().TakeMana(2);

        // reset the image
        coolDownImage.fillAmount = 1.0f;
        used = true;
    }
}
