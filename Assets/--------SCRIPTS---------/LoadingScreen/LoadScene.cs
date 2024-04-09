using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    [Header("Level Loader Section")]

    [SerializeField] GameObject loadingScreen;
    [SerializeField] Slider loadingBar;
    //[SerializeField] Image loadingBarImage; // dùng khi chị Khánh gửi chữ Loading
    [SerializeField] TextMeshProUGUI loadingPercent;

    float delayTime = 1f;

    AudioManager audioManager;

    private void Start()
    {
        audioManager = FindAnyObjectByType<AudioManager>();
    }

    public void LoadLevel(int sceneIndex)
    {
        LoadAudio();

        StartCoroutine(LoadAsynchrounously(sceneIndex));

    }

    public void IntroLoadLevel (int sceneIndex)
    {
        StartCoroutine(StartLoading(sceneIndex));

    }

    IEnumerator StartLoading(int sceneIndex)
    {
        yield return new WaitForSeconds(delayTime);
        StartCoroutine(LoadAsynchrounously(sceneIndex));
    }

    void LoadAudio()
    {
        if (audioManager != null)
        {
            audioManager.PlayStartAudio();
        }
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
    

}
