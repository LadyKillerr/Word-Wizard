using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{

    AudioSource puzzleManagerAudioSource;

    [SerializeField] AudioClip turtleWord;
    [SerializeField][Range(0, 1)] float turtleAudio = 1f;

    private void Awake()
    {
        puzzleManagerAudioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        
    }

    void PlayAudio(AudioClip clip, float volume)
    {
        if (!puzzleManagerAudioSource.isPlaying && puzzleManagerAudioSource.enabled == true)
        {
            puzzleManagerAudioSource.PlayOneShot(clip, volume);

        }
    }

    public void PlayTurtleAudio()
    {
        PlayAudio(turtleWord, turtleAudio);
    }
}
