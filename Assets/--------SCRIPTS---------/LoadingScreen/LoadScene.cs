using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    //[Header("Game Scene Index - change this according to scene build settings")]
    //[SerializeField] int Intro ;
    //[SerializeField] int LoadingScreen ;
    //[SerializeField] int HomeMenu;
    //[SerializeField] int StoriesList;
    //[SerializeField] int CoreGameplay;

    [Header("Level Loader Section")]

    [SerializeField] GameObject loadingScreen;
    [SerializeField] Slider loadingBar;
    //[SerializeField] Image loadingBarImage; // dùng khi chị Khánh gửi chữ Loading
    [SerializeField] TextMeshProUGUI loadingPercent;

    AudioManager gameAudio;

    private void Awake()
    {
        gameAudio = FindAnyObjectByType<AudioManager>();
    }

    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsynchrounously(sceneIndex));
    }


    public IEnumerator LoadAsynchrounously(int sceneIndex)
    {
        yield return new WaitForSecondsRealtime(0.5f);

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            loadingScreen.SetActive(true);

            loadingBar.value = progress;
            loadingPercent.text = progress * 100 + "%";

            
        }
    }

    void PlayStartAudio()
    {
        gameAudio.PlayStartAudio();
    }

    void PlayButtonAudio()
    {
        gameAudio.PlayButtonClip();
    }

    


}
