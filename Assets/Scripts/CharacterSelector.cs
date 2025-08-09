using UnityEngine.SceneManagement;
using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    public GameObject[] characterPrefabs;
    public Transform previewSpawnPoint;
    private GameObject currentCharacter;
    private int selectedIndex = 0;
    [SerializeField] private Transform previewParent;


    void Start()
    {
        ShowCharacter(selectedIndex);
    }

    public void NextCharacter()
    {
        selectedIndex = (selectedIndex + 1) % characterPrefabs.Length;
        ShowCharacter(selectedIndex);
    }

    public void PreviousCharacter()
    {
        selectedIndex = (selectedIndex - 1 + characterPrefabs.Length) % characterPrefabs.Length;
        ShowCharacter(selectedIndex);
    }

    public void ShowCharacter(int index)
    {
        if (currentCharacter != null)
        {
            Destroy(currentCharacter);
        }

        GameObject prefab = characterPrefabs[index];
        currentCharacter = Instantiate(prefab, previewSpawnPoint.position, Quaternion.identity);

        currentCharacter.transform.SetParent(previewParent, worldPositionStays: true);

        //currentCharacter.transform.localScale = Vector3.one;
        currentCharacter.transform.localScale = new Vector3(2f, 2f, 1f);

        Debug.Log("Character instantiated: " + currentCharacter.name);
        Debug.Log("Position: " + previewSpawnPoint.position);
        Debug.Log("Scale: " + currentCharacter.transform.localScale);
        Debug.Log("SpriteRenderer: " + (currentCharacter.GetComponent<SpriteRenderer>() != null));
    }


    public void OnPlay()
    {
        PlayerPrefs.SetInt("SelectedCharacter", selectedIndex);
        //SceneManager.LoadScene("Chapter1");
    }
}
