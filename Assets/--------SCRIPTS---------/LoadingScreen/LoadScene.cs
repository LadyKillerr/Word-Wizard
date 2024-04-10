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

    float delayTime = 1.5f;

    AudioManager audioManager;
    Animator transitionsAnim;

    private void Awake()
    {
        audioManager = FindAnyObjectByType<AudioManager>();

        transitionsAnim = FindAnyObjectByType<Animator>();
    }

    public void LoadLevel(int sceneIndex)
    {
        LoadAudio();

        StartCoroutine(LoadAsynchrounously(sceneIndex));

    }

    public void LoadLevelWithAnim(int sceneIndex)
    {
        if (transitionsAnim != null && transitionsAnim.enabled)
        {
            transitionsAnim.SetTrigger("end");

            // đợi 1s để anim chạy thì sẽ load luôn
            StartCoroutine(LoadAsyncWithoutLoadingScreen(sceneIndex));

        }
    }

    // hàm này dành cho intro load vào game 
    public void IntroLoadLevel(int sceneIndex)
    {
        StartCoroutine(StartLoading(sceneIndex));

    }

    IEnumerator StartLoading(int sceneIndex)
    {
        yield return new WaitForSeconds(delayTime);
        StartCoroutine(LoadAsynchrounously(sceneIndex));
    }

    public IEnumerator LoadAsynchrounously(int sceneIndex)
    {

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!operation.isDone)
        {
            Debug.Log("The Game is loading");

            float progress = Mathf.Clamp01(operation.progress / .9f);

            loadingScreen.SetActive(true);

            loadingBar.value = progress;
            loadingPercent.text = progress * 100 + "%";

            yield return null;
        }
    }

    // hàm này sẽ load có đợi 1s để anim chạy
    public IEnumerator LoadAsyncWithoutLoadingScreen(int sceneIndex)
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync(sceneIndex);


    }







    void LoadAudio()
    {
        if (audioManager != null)
        {
            audioManager.PlayStartAudio();
        }
    }

}
