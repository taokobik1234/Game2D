using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private IntroManager introManager;
    void Start()
    {
        if (gameManager == null)
            gameManager = FindObjectOfType<GameManager>();

        if (audioManager == null)
            audioManager = FindObjectOfType<AudioManager>();
        if (introManager == null)
            introManager = FindObjectOfType<IntroManager>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ZombiePlasma"))
        {
            Player player = GetComponent<Player>();
            player.TakeDame(20f);
            audioManager.PlayDamageMaleSound();
        }
        else if (collision.CompareTag("Energy"))
        {
            gameManager.AddEnergy();
            Destroy(collision.gameObject);
            audioManager.PlayEnergySound();
        }
        else if (collision.CompareTag("Key"))
        {
            Destroy(collision.gameObject);
            IntroManager.CompleteLevel1();
        }
        else if (collision.CompareTag("Potion"))
        {
            Destroy(collision.gameObject);
            IntroManager.CompleteLevel2();
        }
        else if (collision.CompareTag("HealthItem"))
        {
            Player player = GetComponent<Player>();
            player.Heal(20f);
            audioManager.PlayHealSound();
            Destroy(collision.gameObject);
        }

    }
}
