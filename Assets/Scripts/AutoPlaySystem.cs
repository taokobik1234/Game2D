using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoPlaySystem : MonoBehaviour
{
    public float detectionRange = 10f;
    public float attackRange = 5f;
    public float attackRangeMin = 3f;
    public float attackRangeMax = 5f;
    public float moveSpeed = 3f;
    public LayerMask enemyLayer;
    public LayerMask trapLayer;

    private Transform targetEnemy;
    private Gun gun;
    private Rigidbody2D rb;
    private bool isAutoPlay = false;
    private bool isInTrap = false;

    public float trapSafeDistance = 1f;
    public float trapDetectRadius = 0.5f;
    private bool isEscapingTrap = false;
    private Vector2 escapeDirection = Vector2.zero;
    private Transform nearestTrap;

    private Vector2 desiredVelocity = Vector2.zero;

    void Start()
    {
        gun = GetComponentInChildren<Gun>();
        if (gun != null)
            gun.isAutoPlayMode = isAutoPlay;

        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!isAutoPlay) return;

        CheckIfInTrap();
        FindClosestEnemy();

        if (isInTrap && nearestTrap != null)
        {
            Vector2 escapeDir = (transform.position - nearestTrap.position).normalized;
            if (escapeDir == Vector2.zero) escapeDir = Vector2.up;

            desiredVelocity = escapeDir * moveSpeed;

            if (targetEnemy != null && gun != null)
            {
                gun.RotateToTarget(targetEnemy);
                gun.AutoShoot();
            }

            if (!IsNearTrap())
            {
                isEscapingTrap = false;
                nearestTrap = null;
                isInTrap = false;
                desiredVelocity = Vector2.zero; 
            }

            return; 
        }

        if (targetEnemy != null)
        {
            float distance = Vector2.Distance(transform.position, targetEnemy.position);
            Vector2 direction = Vector2.zero;

            if (distance > attackRangeMax)
                direction = (targetEnemy.position - transform.position).normalized;
            else if (distance < attackRangeMin)
                direction = (transform.position - targetEnemy.position).normalized;
            else
                direction = Vector2.zero;

            desiredVelocity = direction * moveSpeed;

            if (gun != null)
            {
                gun.RotateToTarget(targetEnemy);
                gun.AutoShoot();
            }
        }
        else
        {
            desiredVelocity = Vector2.zero;
        }
    }

    void CheckIfInTrap()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, trapDetectRadius, trapLayer);
        if (hits.Length > 0)
        {
            nearestTrap = hits[0].transform;
            float minD = Vector2.Distance(transform.position, nearestTrap.position);
            foreach (var h in hits)
            {
                float d = Vector2.Distance(transform.position, h.transform.position);
                if (d < minD)
                {
                    minD = d;
                    nearestTrap = h.transform;
                }
            }

            isInTrap = true;

            if (!isEscapingTrap)
            {
                isEscapingTrap = true;
                escapeDirection = (transform.position - nearestTrap.position).normalized;
                if (escapeDirection == Vector2.zero) escapeDirection = Vector2.up;
            }
        }
        else
        {
            isInTrap = false;
        
        }
    }

    bool IsNearTrap()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, trapSafeDistance, trapLayer);
        return hit != null;
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

        if (!isAutoPlay)
        {
            desiredVelocity = Vector2.zero;
            isEscapingTrap = false;
            nearestTrap = null;
            isInTrap = false;
        }
        else
        {
            desiredVelocity = Vector2.zero;
            isEscapingTrap = false;
            nearestTrap = null;
            isInTrap = false;
        }
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlay;
    }

    void FixedUpdate()
    {
      
        if (!isAutoPlay) return;

        if (rb != null)
        {
            rb.velocity = desiredVelocity;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, detectionRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, trapDetectRadius);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, trapSafeDistance);
    }
}
