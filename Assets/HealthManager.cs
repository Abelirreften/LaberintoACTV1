using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Image healthBar; // Barra de vida de la UI

    public float healthAmount = 100f; // Vida actual del jugador
    public float maxHealth = 100f; // Vida máxima del jugador

    public float regenerationRate = 5f; // Cantidad de vida que se regenera por intervalo
    public float regenerationInterval = 5f; // Intervalo de tiempo entre regeneraciones

    private Coroutine regenerationCoroutine; // Para controlar la regeneración

    void Start()
    {
        // Inicializa la vida al máximo y la barra de vida
        healthAmount = maxHealth;
        UpdateHealthBar();

        // Comienza la regeneración de vida
        regenerationCoroutine = StartCoroutine(RegenerateHealth());
    }

    void Update()
    {
        // Si la vida llega a 0, reinicia la escena
        if (healthAmount <= 0)
        {
            SceneManager.LoadScene("LaberintoAlmacen");
        }
    }

    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
        healthAmount = Mathf.Clamp(healthAmount, 0, maxHealth); // Asegura que la vida esté entre 0 y la vida máxima
        UpdateHealthBar();
    }

    public void Heal(float healingAmount)
    {
        healthAmount += healingAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, maxHealth); // Asegura que la vida no exceda el máximo
        UpdateHealthBar();
    }

    IEnumerator RegenerateHealth()
    {
        while (true)
        {
            // Si la vida no está al máximo, regenera
            if (healthAmount < maxHealth)
            {
                Heal(regenerationRate);
            }

            // Espera un intervalo antes de volver a regenerar
            yield return new WaitForSeconds(regenerationInterval);
        }
    }

    private void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.fillAmount = healthAmount / maxHealth;
        }
    }
}
