using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSpawner : MonoBehaviour
{
    public GameObject spikeTrapPrefab;
    public int numberOfTraps = 5;

    public Vector2 areaSize = new Vector2(10f, 5f); 
    public Vector2 areaCenter = Vector2.zero;       

    void Start()
    {
        SpawnTraps();
    }

    void SpawnTraps()
    {
        for (int i = 0; i < numberOfTraps; i++)
        {
            Vector2 randomPos = new Vector2(
                Random.Range(-areaSize.x / 2, areaSize.x / 2),
                Random.Range(-areaSize.y / 2, areaSize.y / 2)
            );

            Vector2 spawnPosition = areaCenter + (Vector2)transform.position + randomPos;

            Instantiate(spikeTrapPrefab, spawnPosition, Quaternion.identity);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector3 center = new Vector3(areaCenter.x, areaCenter.y, 0f) + transform.position;
        Vector3 size = new Vector3(areaSize.x, areaSize.y, 1f);
        Gizmos.DrawWireCube(center, size);
    }
}
