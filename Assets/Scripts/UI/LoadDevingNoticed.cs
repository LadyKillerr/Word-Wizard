using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadDevingNoticed : MonoBehaviour
{
    // panel tối tối để cover màn hình 
    [SerializeField] GameObject underDevelopmentNoti;

    // hộp thông báo "under development" 
    [SerializeField] GameObject NotiText; 

    // Screen Darken
    [SerializeField] GameObject screenDarken;

    AudioManager gameAudio; 

    void Start()
    {
        gameAudio = FindObjectOfType<AudioManager>();

        underDevelopmentNoti.SetActive(false) ;
    }

    void Update()
    {
        // hàm update là không càn thiết trong trường hợp sử dụng chay void
        //HideDevingNoti();
        //ShowDevingNoti();
    }

    // ẩn hộp thông báo đi 
    public void HideDevingNoti()
    {
        underDevelopmentNoti.SetActive(false);
        NotiText.SetActive(false);
        screenDarken.SetActive(false);

    }

    // trượt hộp thông báo xuống
    public void ShowDevingNoti()
    {
        underDevelopmentNoti.SetActive(true);
        NotiText.SetActive(true);
        screenDarken.SetActive(true);

        gameAudio.PlayBugClip();
    }

    
}
