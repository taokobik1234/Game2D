using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossEnemy : Enemy
{
    [SerializeField] private GameObject plasmaPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float speedPlasma = 20f;
    [SerializeField] private float speedCircePlasma = 10f;
    [SerializeField] private float hpValue = 100f;
    [SerializeField] private float skillCooldown = 2f;
    private float nextSkillTime = 0f;
    protected override void Update()
    {
        base.Update();
        if (Time.time >= nextSkillTime)
        {
            UsingSkill();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.TakeDame(enterDamage);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.TakeDame(stayDamage);
        }
    }

    private void ShootPlasma()
    {
        if(player != null)
        {
            Vector3 direction2Player = player.transform.position - firePoint.position;
            direction2Player.Normalize();
            GameObject plasma = Instantiate(plasmaPrefab, firePoint.position, Quaternion.identity);
            ZombiePlasma zombiePlasma = plasma.AddComponent<ZombiePlasma>();
            zombiePlasma.setMoveDirection(direction2Player* speedPlasma);
        }
    }

    private void ShootCirclePlasma()
    {
        const int plasmaCount = 12;
        float angleStep = 360f / plasmaCount;
        for(int i=0; i < plasmaCount; i++)
        {
            float angle = i * angleStep;
            Vector3 plasmaDirection = new Vector3(Mathf.Cos(Mathf.Deg2Rad * angle), Mathf.Sin(Mathf.Deg2Rad * angle), 0);
            GameObject plasma = Instantiate(plasmaPrefab,transform.position, Quaternion.identity);
            ZombiePlasma zombiePlasma = plasma.AddComponent<ZombiePlasma>();
            zombiePlasma.setMoveDirection(plasmaDirection * speedCircePlasma);
        }
    }

    private void Heal(float hpAmount)
    {
        currentHp = Mathf.Min(currentHp + hpAmount, maxHp);
        UpdateHpBar();
    }

    private void RandomSkill()
    {
        int randomSkill = Random.Range(0, 3);
        switch (randomSkill)
        {
            case 0:
                ShootPlasma();
                break;
            case 1:
                ShootCirclePlasma();
                break;
            case 2:
                Heal(hpValue);
                break;
        }
    }

    private void UsingSkill()
    {
        nextSkillTime = Time.time + skillCooldown;
        RandomSkill();
    }
}
