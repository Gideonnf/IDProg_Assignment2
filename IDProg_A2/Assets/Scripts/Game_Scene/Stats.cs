using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
// DOTween
using DG.Tweening;

public class Stats : MonoBehaviour {

    // Static Instance
    private static Stats m_Instance;
    public static Stats GetInstance()
    {
        return m_Instance;
    }
    [SerializeField]
    private GameObject HealthUI;
    private TextMeshProUGUI healthText;
    [SerializeField]
    private GameObject ManaUI;
    private TextMeshProUGUI manaText;


    // Other Variables
    private float maxHp, maxMana;
    private float currentHp, currentMana;
    float healthRegenRate, maxHealthRegenRate;
    float idleTimer, maxIdleTimer;
    float maxWidth;
    bool transparent;

	// Use this for initialization
	void Start () {
        currentHp = maxHp = 2440;
        currentMana = maxMana = 1650;
        maxHealthRegenRate = 5.0f;
        healthRegenRate = 0.0f;
        idleTimer = 0.0f;
        maxIdleTimer = 3.0f;

        maxWidth = 0.9597315f;
        transparent = true;
        // Set Data
        m_Instance = this;
        healthText = HealthUI.GetComponentInChildren<TextMeshProUGUI>();
        manaText = ManaUI.GetComponentInChildren<TextMeshProUGUI>();
        // make it transparent
        HealthUI.GetComponent<CanvasGroup>().alpha = 0.0f;
        ManaUI.GetComponent<CanvasGroup>().alpha = 0.0f;
    }
	
	// Update is called once per frame
	void Update () {

        // If currently transparent,
        // that means nothing to update
        if (transparent)
            return;

        // Check if back to full Hp
        if (currentHp == maxHp) 
        {
            // if idled for awhile after recovering,
            // then go back to transparent
            if (idleTimer > maxIdleTimer)
            {
                // make it transparent
                HealthUI.GetComponent<CanvasGroup>().DOFade(0.0f, 0.6f);
                ManaUI.GetComponent<CanvasGroup>().DOFade(0.0f, 0.6f);
                transparent = true;
                return;
            }
            else
                idleTimer += Time.deltaTime;
        }
        else
        {
            // Only regen if timer is up
            healthRegenRate += Time.deltaTime;
            if (healthRegenRate > maxHealthRegenRate)
            {
                healthRegenRate = 0.0f;
                currentHp++;

                // after modifiying
                RecalculateHPUI();
            }
        }


       
    }   // end of update


    public void TakeDamage(int damageAmount)
    {
        currentHp -= damageAmount;
        // prevent player from dying
        currentHp = Mathf.Clamp(currentHp, 1, maxHp);

        // after modifiying
        RecalculateHPUI();

        // Do other actions after altering Hp
        StatsModified();
    }
    public void TakeMana(int manamount)
    {
        currentMana -= manamount;
        // prevent player from running out
        currentMana = Mathf.Clamp(currentMana, 1, maxMana);

        // after modifying
        RecalculateManaUI();

        // Do other actions after altering mana
        StatsModified();
    }


    private void StatsModified()
    {
        // reset boolean flag
        transparent = false;
        // reset timers
        healthRegenRate = idleTimer = 0.0f;
        // make it opqaue
        HealthUI.GetComponent<CanvasGroup>().DOFade(1.0f, 0.4f);
        ManaUI.GetComponent<CanvasGroup>().DOFade(1.0f, 0.4f);
    }
    private void RecalculateHPUI()
    {
        // Set the Width of HP bar
        Vector3 oldScale = HealthUI.transform.GetChild(0).localScale;
        oldScale.x = maxWidth * (currentHp / maxHp);
        HealthUI.transform.GetChild(0).localScale = oldScale;
        // Set the Text
        healthText.text = currentHp.ToString();
    }
    private void RecalculateManaUI()
    {
        // Set the Width of Mana bar
        Vector3 oldScale = ManaUI.transform.GetChild(0).localScale;
        oldScale.x = maxWidth * (currentMana / maxMana);
        ManaUI.transform.GetChild(0).localScale = oldScale;
        // Set the Text
        manaText.text = currentMana.ToString();
    }
}
