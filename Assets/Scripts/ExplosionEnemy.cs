using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEnemy : Enemy
{
    [SerializeField] private GameObject explosionPrefabs;
    private void CreateExplosion()
    {
        if(explosionPrefabs != null)
        {
            Instantiate(explosionPrefabs, transform.position, Quaternion.identity);
        }
    }

    protected override void Die()
    {
        CreateExplosion();
        base.Die();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CreateExplosion();
        }
    }
}
