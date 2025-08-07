using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Gun : MonoBehaviour
{
    private float rotateOffset = 180f;
    [SerializeField] private Transform firePos;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float shotDelay = 0.15f;
    private float nextShot;
    [SerializeField] private int maxAmmo = 24;
    public int currentAmmo;
    public TextMeshProUGUI ammoText;
    public AudioManager audioManager;
    public bool isAutoPlayMode = false;

    void Start()
    {
        currentAmmo = maxAmmo;
        UpdateAmmoText();
    }

    void Update()
    {
        RotateGun();
        Shoot();
        Reload();
    }

    void RotateGun()
    {
        if (isAutoPlayMode) return;

        if (Input.mousePosition.x < 0 || Input.mousePosition.x > Screen.width || Input.mousePosition.y < 0 || Input.mousePosition.y > Screen.height)
        {
            return;
        }

        Vector3 displayment = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(displayment.y, displayment.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle + rotateOffset);

        if (angle < -90 || angle > 90)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, -1, 1);
        }
    }


    void Shoot()
    {
        if (Time.timeScale == 0f) return;
        if (Input.GetMouseButtonDown(0) && currentAmmo > 0 && Time.time >= nextShot)
        {
            nextShot = Time.time + shotDelay;
            Instantiate(bulletPrefab, firePos.position, firePos.rotation);
            currentAmmo--;
            UpdateAmmoText();
            audioManager.PlayShootSound();
        }
    }
    void Reload()
    {
        if(Input.GetMouseButtonDown(1)&& currentAmmo < maxAmmo)
        {
            currentAmmo = maxAmmo;
            UpdateAmmoText();
            audioManager.PlayReloadSound();
        }
    }

    public void UpdateAmmoText()
    {
        if(ammoText != null)
        {
            if(currentAmmo > 0)
            {
                ammoText.text = currentAmmo.ToString();
            }
            else
            {
                ammoText.text = "Empty";
            }
        }
    }

    public void AutoShoot()
    {
        if (Time.timeScale == 0f) return;
        if (Time.time >= nextShot && currentAmmo > 0)
        {
            nextShot = Time.time + shotDelay;
            Instantiate(bulletPrefab, firePos.position, firePos.rotation);
            currentAmmo--;
            UpdateAmmoText();
            audioManager.PlayShootSound();
        }
    }

    public void RotateToTarget(Transform target)
    {
        if (target == null) return;

        Vector2 direction = -target.position + transform.parent.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle + rotateOffset);

        if (angle < -90 || angle > 90)
            transform.localScale = new Vector3(1, 1, 1);
        else
            transform.localScale = new Vector3(1, -1, 1);
        

    }

}
