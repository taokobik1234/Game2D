using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 25f;
    [SerializeField] private float timeDestroy = 0.5f;
    [SerializeField] private GameObject bloodPrefabs;
    [SerializeField] private GameObject fireEffectPrefab;


    private float damage;

    public void SetDamage(float value)
    {
        damage = value;
    }

    void Start()
    {
        if (damage > 15f)
        {
            Invoke(nameof(SpawnFireEffect), 0.05f);
        }

        Destroy(gameObject, timeDestroy);
    }

    void SpawnFireEffect()
    {
        if (fireEffectPrefab != null)
        {
            GameObject fx = Instantiate(fireEffectPrefab, transform.position, transform.rotation);

            fx.transform.parent = this.transform;
            fx.transform.localPosition = Vector3.zero;
        }
    }

    void Update()
    {
        MoveBullet();
    }

    void MoveBullet()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDame(damage);
                GameObject blood = Instantiate(bloodPrefabs, transform.position, Quaternion.identity);
                Destroy(blood, 1f);
            }
            Destroy(gameObject);
        }
    }
}