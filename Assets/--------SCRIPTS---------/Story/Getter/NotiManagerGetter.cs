using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotiManagerGetter : MonoBehaviour
{
    NotiManager notiManager;

    // Start is called before the first frame update
    void Awake()
    {
        notiManager = FindAnyObjectByType<NotiManager>();
    }
    
    public void ResetStory()
    {
        notiManager.ReloadStory();
    }

}
