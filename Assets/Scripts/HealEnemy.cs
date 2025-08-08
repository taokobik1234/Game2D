using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealEnemy : Enemy
{
    [SerializeField] private float healValue = 20f;
    [SerializeField] private GameObject healItemPrefabs;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (player != null)
            {
                player.TakeDame(enterDamage);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (player != null)
            {
                player.TakeDame(stayDamage);
            }
        }
    }

    protected override void Die()
    {
        Instantiate(healItemPrefabs, transform.position, Quaternion.identity);
        base.Die();
    }
    public void HealPlayer()
    {
        if(player != null)
        {
            player.Heal(healValue);
        }
    }
}
