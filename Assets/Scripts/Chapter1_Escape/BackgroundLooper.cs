using UnityEngine;

public class BackgroundLooper : MonoBehaviour
{
    public float scrollSpeed = 2f; 
    private Transform[] backgrounds; 
    private float backgroundWidth;

    void Start()
    {
        
        int childCount = transform.childCount;
        backgrounds = new Transform[childCount];

        for (int i = 0; i < childCount; i++)
        {
            backgrounds[i] = transform.GetChild(i);
        }

        
        backgroundWidth = backgrounds[0].GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        foreach (Transform bg in backgrounds)
        {
            bg.position += Vector3.left * scrollSpeed * Time.deltaTime;
        }

        for (int i = 0; i < backgrounds.Length; i++)
        {
            if (backgrounds[i].position.x < -backgroundWidth)
            {
                Transform rightMost = backgrounds[0];
                for (int j = 1; j < backgrounds.Length; j++)
                {
                    if (backgrounds[j].position.x > rightMost.position.x)
                        rightMost = backgrounds[j];
                }

                backgrounds[i].position = new Vector3(
                    rightMost.position.x + backgroundWidth,
                    backgrounds[i].position.y,
                    backgrounds[i].position.z
                );
            }
        }
    }
}
