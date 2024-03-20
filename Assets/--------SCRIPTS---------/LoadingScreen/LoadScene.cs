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

        //if (sceneIndex == 1 || sceneIndex == 2)
        //{
            PlayStartAudio();

        //}
        //else
        //{
        //    PlayButtonAudio();
        //}
    }

    public IEnumerator LoadAsynchrounously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            loadingScreen.SetActive(true);

            loadingBar.value = progress;
            loadingPercent.text = progress * 100 + "%";

            yield return null;
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

    //public void LoadMainMenu()
    //{
    //    // load ra scene menu
    //    SceneManager.LoadScene(HomeMenu);

    //    //gameAudio.PlayButtonAudio();

    //}

    //public void StartPlayButtonSound()
    //{

    //}

    //public void LoadLoadingScreen()
    //{
    //    SceneManager.LoadScene(LoadingScreen);

    //    //gameAudio.PlayButtonAudio();

    //}

    //public void LoadCoreGame()
    //{
    //    SceneManager.LoadScene(CoreGameplay);
    //}


}
