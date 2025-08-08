using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSpriteAnimation : MonoBehaviour
{
    public Sprite[] frames;         
    public float frameRate = 0.08f;
    private SpriteRenderer sr;
    private int currentFrame = 0;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        StartCoroutine(PlayAnimation());
    }

    IEnumerator PlayAnimation()
    {
        while (currentFrame < frames.Length)
        {
            sr.sprite = frames[currentFrame];
            currentFrame++;
            yield return new WaitForSeconds(frameRate);
        }

        Destroy(gameObject); 
    }
}
