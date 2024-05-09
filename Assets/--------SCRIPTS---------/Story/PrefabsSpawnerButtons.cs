using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PrefabsSpawnerButtons : MonoBehaviour
{
    PrefabsSpawner prefabsSpawner;
    int prefabsIndex;
    [Header("Quiz Button State")]
    [SerializeField] string bookName;
    [SerializeField] Button quizButton;
    [SerializeField] Sprite normalState;
    [SerializeField] Sprite lockedState;

    AudioManager audioManager;

    NotiManager notiManager;


    void Awake()
    {
        prefabsSpawner = FindAnyObjectByType<PrefabsSpawner>();
        audioManager = FindAnyObjectByType<AudioManager>();
        notiManager = FindAnyObjectByType<NotiManager>();


        UpdateQuizButtonState();
    }

    public void UpdateQuizButtonState()
    {
        if (PlayerPrefs.GetInt(bookName) == 1)
        {
            quizButton.image.sprite = normalState;
        }
        else
        {
            quizButton.image.sprite = lockedState;
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
        // nếu status là đã xong thì ấn bthg
        if (PlayerPrefs.GetInt(bookName) == 1)
        {
            prefabsIndex = prefabsSpawner.GetPrefabsIndex();

            prefabsSpawner.SpawnQuizPrefabs(prefabsIndex);

            Debug.Log("Run Spawn Quiz Prefabs");

        }
        // nếu status là chưa xong || pending thì không nhận 
        else
        {
            notiManager.ShowIsLockedNoti();
        }

    }

    public void PlayButtonSound()
    {
        if (audioManager != null)
        {
            audioManager.PlayButtonClip();

        } 
    }
}
