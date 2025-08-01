using UnityEngine;
using TMPro;
using Cinemachine;

public class PlayerSpawnerManager : MonoBehaviour
{
    public GameObject[] characterPrefabs;
    public Transform spawnPoint;
    private TextMeshProUGUI ammoText;
    public AudioManager audioManager;

    void Start()
    {
        Debug.Log("PlayerSpawnerManager.Start() called");

        GameObject ammoObj = GameObject.Find("Text (TMP)");
        if (ammoObj != null)
        {
            ammoText = ammoObj.GetComponent<TextMeshProUGUI>();
        }
        else
        {
            Debug.LogError("Không tìm thấy Text (TMP) để hiển thị ammoText");
        }

        if (characterPrefabs == null || characterPrefabs.Length == 0)
        {
            Debug.LogWarning("No characterPrefabs assigned");
            return;
        }

        if (spawnPoint == null)
        {
            spawnPoint = this.transform;
        }

        int selected = PlayerPrefs.GetInt("SelectedCharacter", 0);
        if (selected < 0 || selected >= characterPrefabs.Length)
        {
            selected = 0;
        }

        GameObject spawnedPlayer = Instantiate(characterPrefabs[selected], spawnPoint.position, Quaternion.identity);
        Gun gun = spawnedPlayer.GetComponentInChildren<Gun>();
        if (audioManager == null)
        {
            audioManager = FindObjectOfType<AudioManager>();
            if (audioManager == null)
            {
                Debug.LogWarning("AudioManager not found in scene!");
            }
        }
        if (gun != null)
        {
            gun.ammoText = ammoText;
            gun.audioManager = audioManager;
            gun.UpdateAmmoText();
        }

        CinemachineVirtualCamera vCam = FindObjectOfType<CinemachineVirtualCamera>();


        if (vCam != null && spawnedPlayer != null)
        {
            vCam.Follow = spawnedPlayer.transform;
            vCam.LookAt = spawnedPlayer.transform;
        }
    }
}
