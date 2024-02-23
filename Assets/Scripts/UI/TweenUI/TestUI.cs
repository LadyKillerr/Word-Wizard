using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestUI : MonoBehaviour
{
    [SerializeField] GameObject TestImage;

    FadeTweenUI fadeUIScript;

    bool isActive;

    private void Start()
    {
        fadeUIScript = TestImage.GetComponent<FadeTweenUI>();
    }

    private void Update()
    {
        if (fadeUIScript.enabled == true)
        {
            isActive = true;
        }
        else
        {
            isActive = false;
        }

    }

    public void ToggleFadeUI()
    {
        if (!isActive)
        {
            TestImage.SetActive(true);
            fadeUIScript.enabled = true;
            isActive = true;
        }
        else
        {
            TestImage.SetActive(false);

            fadeUIScript.enabled = false;
            isActive = false;
        
        }
    }
}
