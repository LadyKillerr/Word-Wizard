using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabsSpawnerButtons : MonoBehaviour
{
    PrefabsSpawner prefabsSpawner;
    [SerializeField] int prefabsIndex;

    AudioManager audioManager;

    void Awake()
    {
        prefabsSpawner = FindAnyObjectByType<PrefabsSpawner>();
        audioManager = FindAnyObjectByType<AudioManager>();
    }

    void Update()
    {

        if (prefabsSpawner == null)
        {
            Debug.Log("prefabsSpawner is null");
        }
    }

    public void HideSelectionPanel()
    {
        prefabsSpawner.HideSelectionPanel();
    }

    public void TurnOffGame()
    {
        Debug.Log("The game has been turned off");
        Application.Quit();
    }


    public void ConnectStoryPrefabs()
    {
        prefabsIndex = prefabsSpawner.GetPrefabsIndex();

        prefabsSpawner.SpawnStoryPrefabs(prefabsIndex);
        Debug.Log("Run SpawnStory Prefabs");
    }

    public void ConnectQuizPrefabs()
    {
        prefabsIndex = prefabsSpawner.GetPrefabsIndex();

        prefabsSpawner.SpawnQuizPrefabs(prefabsIndex);

        Debug.Log("Run Spawn Quiz Prefabs");

    }

    public void PlayButtonSound()
    {
        audioManager.PlayButtonClip();
    }
}
