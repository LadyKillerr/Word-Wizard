using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnglishLevelSelector : MonoBehaviour
{

    [SerializeField] GameObject levelSelector;

    bool isShow;

    void Start()
    {
        isShow = false;
    }


    void Update()
    {

    }

    public void ToggleLevelSelector()
    {
        if (!isShow)
        {
            isShow = true;
            levelSelector.SetActive(true);

        }
        else
        {
            isShow = false;
            levelSelector.SetActive(false);
        }
    }
}
