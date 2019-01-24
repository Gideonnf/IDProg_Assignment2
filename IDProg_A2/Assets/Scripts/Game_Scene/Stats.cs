using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    float maxWidth;
    bool transparent;

	// Use this for initialization
	void Start () {
        currentHp = maxHp = 2440;
        currentMana = maxMana = 1650;
        maxHealthRegenRate = 5.0f;
        healthRegenRate = 0.0f;
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

        // Only regen if timer is up
        healthRegenRate += Time.deltaTime;
        if (healthRegenRate > maxHealthRegenRate)
        {
            healthRegenRate = 0.0f;
            currentHp++;
        }
        // Check if back to full HP
        if (currentHp == maxHp)
        {
            // make it transparent
            HealthUI.GetComponent<CanvasGroup>().alpha = 0.0f;
            ManaUI.GetComponent<CanvasGroup>().alpha = 0.0f;
            transparent = true;
        }


        // Set the Width of HP bar
        Vector3 oldScale = HealthUI.transform.GetChild(0).localScale;
        oldScale.x = maxWidth * (currentHp / maxHp);
        HealthUI.transform.GetChild(0).localScale = oldScale;
        // Set the Text
        healthText.text = currentHp.ToString();

    }


    public void TakeDamage(int damageAmount)
    {
        currentHp -= damageAmount;
        // prevent player from dying
        currentHp = Mathf.Clamp(currentHp, 1, maxHp);

        TakenDamage();
    }
    public void TakeMana(int manamount)
    {
        currentMana -= manamount;
        currentMana = Mathf.Clamp(currentMana, 1, maxMana);

        TakenDamage();
    }


    private void TakenDamage()
    {
        // reset boolean flag
        transparent = false;
        // reset timer
        healthRegenRate = 0.0f;
        // make it opqaue
        HealthUI.GetComponent<CanvasGroup>().alpha = 1.0f;
        ManaUI.GetComponent<CanvasGroup>().alpha = 1.0f;
    }
}
