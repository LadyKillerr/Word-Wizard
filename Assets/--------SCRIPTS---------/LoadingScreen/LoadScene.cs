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

    [Header("Animation Timer - equal to Anim time")]
    [SerializeField] float endAnimTime = .5f;
    [SerializeField] float startAnimTime = .5f;

    AudioManager audioManager;
    [SerializeField] Animator transitionsAnim;

    private void Awake()
    {
        Application.targetFrameRate = 60;

        audioManager = FindAnyObjectByType<AudioManager>();

        if (transitionsAnim != null && transitionsAnim.enabled)
        {
            transitionsAnim.SetTrigger("start");

        }
        else
        {
            return;
        }
    }

    public void LoadLevel(int sceneIndex)
    {
        LoadAudio();

        StartCoroutine(LoadAsynchrounously(sceneIndex));

    }

    // Load Scene khác với anim "end" ( sẽ đợi 1s để anim chạy r mới load scene)
    public void LoadLevelWithAnim(int sceneIndex)
    {
        if (transitionsAnim != null && transitionsAnim.enabled)
        {
            transitionsAnim.SetTrigger("end");

            if (audioManager != null)
            {
                audioManager.PlayStartAudio();
            }

            // đợi 1s để anim chạy thì sẽ load luôn
            StartCoroutine(LoadAsyncWithoutLoadingScreen(sceneIndex));

        }
    }



    // hàm này sẽ load có đợi endAnimTime để anim chạy
    public IEnumerator LoadAsyncWithoutLoadingScreen(int sceneIndex)
    {
        yield return new WaitForSeconds(endAnimTime);
        SceneManager.LoadSceneAsync(sceneIndex);




    }

    public void LoadAsyncWithoutAudio(int sceneIndex)
    {
        StartCoroutine(LoadAsyncWithoutLoadingScreen(sceneIndex));
    }

    public IEnumerator LoadAsynchrounously(int sceneIndex)
    {

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!operation.isDone)
        {
            Debug.Log("The Game is loading");

            float progress = Mathf.Clamp01(operation.progress / .9f);

            if (loadingScreen != null)
            {
                loadingScreen.SetActive(true);
                loadingBar.value = progress;
                loadingPercent.text = progress * 100 + "%";

            }


            yield return null;
        }
    }




    // 2 hàm này dành cho intro load vào game 
    public void IntroLoadGame(int sceneIndex)
    {
        if (transitionsAnim != null)
        {
            transitionsAnim.enabled = true;

            // đợi 1s để anim chạy thì sẽ load luôn
            StartCoroutine(IntroLoadAsync(sceneIndex));

        }
    }

    IEnumerator IntroLoadAsync(int sceneIndex)
    {
        // 1s chạy anim nổ bóng 1s chạy anim transitions -> tổng là 2s
        yield return new WaitForSeconds(endAnimTime);
        transitionsAnim.SetTrigger("end");

        yield return new WaitForSeconds(startAnimTime);
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



