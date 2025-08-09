using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    public float damage = 20f;
    public float damageInterval = 1f;

    private Dictionary<GameObject, float> lastDamageTime = new Dictionary<GameObject, float>();

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        GameObject playerObj = other.gameObject;

        if (!lastDamageTime.ContainsKey(playerObj))
        {
            lastDamageTime[playerObj] = 0f;
        }

        if (Time.time - lastDamageTime[playerObj] >= damageInterval)
        {
            Player player = playerObj.GetComponent<Player>();
            if (player != null)
            {
                player.TakeDame(damage);
                lastDamageTime[playerObj] = Time.time;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (lastDamageTime.ContainsKey(other.gameObject))
        {
            lastDamageTime.Remove(other.gameObject);
        }
    }
}
