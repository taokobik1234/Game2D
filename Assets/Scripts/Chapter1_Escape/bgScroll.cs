using UnityEngine;

public class bgScroll : MonoBehaviour
{
    public float scrollSpeed = 0.5f;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, 20); // lặp lại sau 20 đơn vị
        transform.position = startPosition + Vector3.left * newPosition;
    }
}
