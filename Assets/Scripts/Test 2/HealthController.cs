using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    [Header("Health Parameters")]
    public int maxHealth = 100;
    static public float currentHealth;
    [SerializeField] private float smoothDecreaseDuration = 0.5f;

    [Header("UI Parameters")]
    public TMP_Text healthText;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthText.text = currentHealth.ToString();
        //UpdateHealthText();
    }

    public void TakeDamage(int damage)
    {
        StartCoroutine(SmoothDecreaseHealth(damage));
    }

    private IEnumerator SmoothDecreaseHealth (int damage)
    {
        float damagePerTick = damage / smoothDecreaseDuration;
        float elapsedTime = 0f;

        while (elapsedTime < smoothDecreaseDuration)
        {
            float currentDamage = damagePerTick * Time.deltaTime;
            currentHealth -= currentDamage;
            elapsedTime += Time.deltaTime;

            UpdateHealthText();

            if(currentHealth <= 0)
            {
                currentHealth = 0;
                //player death
                break;
            }
            yield return null;
        }
    }
    public void UpdateHealthText()
    {
        healthText.text = currentHealth.ToString();
    }

}
