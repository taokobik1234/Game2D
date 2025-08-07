using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoPlaySystem : MonoBehaviour
{
    public float detectionRange = 10f;
    public float attackRange = 5f;
    public float attackRangeMin = 3f; 
    public float attackRangeMax = 7f; 
    public float moveSpeed = 3f;
    public LayerMask enemyLayer;

    private Transform targetEnemy;
    private Gun gun;
    private Rigidbody2D rb;
    private bool isAutoPlay = false;

    void Start()
    {
        gun = GetComponentInChildren<Gun>();
        gun.isAutoPlayMode = isAutoPlay;

        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!isAutoPlay) return;

        FindClosestEnemy();

        if (targetEnemy != null)
        {
            float distance = Vector2.Distance(transform.position, targetEnemy.position);
            Vector2 direction = Vector2.zero;

            if (distance > attackRangeMax)
            {
                direction = (targetEnemy.position - transform.position).normalized;
            }
            else if (distance < attackRangeMin)
            {
                direction = (transform.position - targetEnemy.position).normalized;
            }
            else
            {
                direction = Vector2.zero;
            }

            rb.velocity = direction * moveSpeed;

            if (gun != null)
            {
                gun.RotateToTarget(targetEnemy);
                gun.AutoShoot();
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }


    void FindClosestEnemy()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, detectionRange, enemyLayer);
        float minDist = Mathf.Infinity;
        Transform closest = null;

        foreach (var hit in hits)
        {
            float dist = Vector2.Distance(transform.position, hit.transform.position);
            if (dist < minDist)
            {
                minDist = dist;
                closest = hit.transform;
            }
        }

        targetEnemy = closest;
    }

    public void SetAutoPlay(bool enable)
    {
        isAutoPlay = enable;
        if (gun != null)
            gun.isAutoPlayMode = isAutoPlay;
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlay;
    }
}
