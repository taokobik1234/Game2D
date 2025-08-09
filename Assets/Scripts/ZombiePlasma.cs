using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiePlasma : MonoBehaviour
{
    private Vector3 moveDirection;
    void Start()
    {
        Destroy(gameObject, 5f);
    }

    void Update()
    {
        if (moveDirection == Vector3.zero) return;
        transform.position += moveDirection * Time.deltaTime;
    }

    public void setMoveDirection(Vector3 direction)
    {
        moveDirection = direction;
    }
}
