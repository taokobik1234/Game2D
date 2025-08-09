using UnityEngine;

public class ItemDamageBoost : MonoBehaviour
{
    [SerializeField] private float boostFactor = 2f;
    [SerializeField] private float duration = 5f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Gun gun = other.GetComponentInChildren<Gun>();
            if (gun != null)
            {
                gun.BoostDamage(boostFactor, duration);
            }

            AudioManager audioManager = FindObjectOfType<AudioManager>();
            if (audioManager != null)
            {
                audioManager.PlayHealSound();
            }

            Destroy(gameObject);
        }
    }
}
