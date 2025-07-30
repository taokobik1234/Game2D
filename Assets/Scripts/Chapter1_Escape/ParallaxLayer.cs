using UnityEngine;

public class ParallaxLayer : MonoBehaviour
{
    public float parallaxSpeed;  

    private Transform cam;
    private Vector3 previousCamPos;

    void Start()
    {
        cam = Camera.main.transform;
        previousCamPos = cam.position;
    }

    void Update()
    {
        Vector3 deltaMovement = cam.position - previousCamPos;
        transform.position += new Vector3(deltaMovement.x * parallaxSpeed, 0, 0);
        previousCamPos = cam.position;
    }
}
