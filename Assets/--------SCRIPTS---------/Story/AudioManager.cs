using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [Header("Game SFX")]
    [SerializeField] AudioClip startAudio;
    [SerializeField][Range(0, 1)] float startVolume = 1f;

    [SerializeField] AudioClip buttonAudio;
    [SerializeField][Range(0, 1)] float buttonVolume = 1f;

    [SerializeField] AudioClip pageTurningAudio;
    [SerializeField][Range(0, 1)] float pageTurningVolume = 1f;

    [SerializeField] AudioClip bugAudio;
    [SerializeField][Range(0, 1)] float bugAudioVolume = 1f;

    [SerializeField] AudioClip congratsAudio;
    [SerializeField][Range(0, 1)] float congratsAudioVolume = 1f;



    AudioSource gameAudio;

    private void Awake()
    {
#pragma warning disable CS0618 // Type or member is obsolete
        int instanceCount = FindObjectsOfType(GetType()).Length;
#pragma warning restore CS0618 // Type or member is obsolete

        if (instanceCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
        gameAudio = GetComponent<AudioSource>();
    }

    void Start()
    {

        // lấy ra vị trí của camera để làm điểm phát audio
        // cameraPosition = Camera.main.transform.position;

    }

    // hàm dùng chung để chạy tất cả các clip âm thanh được lưu ở đây
    void PlayAudio(AudioClip clip, float volume)
    {
        if (gameAudio != null )
        {
            gameAudio.PlayOneShot(clip, volume);

        }


    }

    public void PlayStartAudio()
    {
        PlayAudio(startAudio, startVolume);
    }

    public void PlayOkayAudio()
    {
        AudioSource.PlayClipAtPoint(startAudio, Camera.main.transform.position);
    }

    public void PlayButtonClip()
    {
        PlayAudio(buttonAudio, buttonVolume);
    }

    public void PlayPageTurningClip()
    {
        PlayAudio(pageTurningAudio, pageTurningVolume);
    }

    public void PlayBugClip()
    {
        PlayAudio(bugAudio, bugAudioVolume);
    }

    public void PlayCongratsClip()
    {
        PlayAudio(congratsAudio, congratsAudioVolume);
    }

    //public void PlayWordA()
    //{
    //    PlayAudio(aWord, aWordAudioVolume);
    //}

    //public void PlayWordB()
    //{
    //    PlayAudio(bWord, bWordAudioVolume);
    //}

    //public void PlayWordC()
    //{
    //    PlayAudio(cWord, cWordAudioVolume);
    //}

    //public void PlayWordD()
    //{
    //    PlayAudio(dWord, dWordAudioVolume);
    //}

    //public void PlayWordE()
    //{
    //    PlayAudio(eWord, eWordAudioVolume);
    //}

    //public void PlayWordF()
    //{
    //    PlayAudio(fWord, fWordAudioVolume);
    //}
    //public void PlayWordG()
    //{
    //    PlayAudio(gWord, gWordAudioVolume);
    //}

    //public void PlayWordH()
    //{
    //    PlayAudio(hWord, hWordAudioVolume);
    //}

    //public void PlayWordI()
    //{
    //    PlayAudio(iWord, iWordAudioVolume);
    //}

    //public void PlayWordK()
    //{
    //    PlayAudio(kWord, kWordAudioVolume);
    //}

    //public void PlayWordL()
    //{
    //    PlayAudio(lWord, lWordAudioVolume);
    //}

    //public void PlayWordM()
    //{
    //    PlayAudio(mWord, mWordAudioVolume);
    //}

    //public void PlayWordN()
    //{
    //    PlayAudio(nWord, nWordAudioVolume);
    //}

    //public void PlayWordO()
    //{
    //    PlayAudio(oWord, oWordAudioVolume);
    //}

    //public void PlayWordP()
    //{
    //    PlayAudio(pWord, pWordAudioVolume);
    //}

    //public void PlayWordQ()
    //{
    //    PlayAudio(qWord, qWordAudioVolume);
    //}
    //public void PlayWordR()
    //{
    //    PlayAudio(rWord, rWordAudioVolume);
    //}

    //public void PlayWordS()
    //{
    //    PlayAudio(sWord, sWordAudioVolume);
    //}

    //public void PlayWordT()
    //{
    //    PlayAudio(tWord, tWordAudioVolume);
    //}

    //public void PlayWordU()
    //{
    //    PlayAudio(uWord, uWordAudioVolume);
    //}

}
