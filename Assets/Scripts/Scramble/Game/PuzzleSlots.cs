using UnityEngine;

public class PuzzleSlots : MonoBehaviour
{
    //[SerializeField] AudioSource puzzleSlotAudioSource;
    [SerializeField] AudioClip completeClip;

    // hidden components
    AudioSource puzzleSlotAudioSource;


    void Start()
    {
        puzzleSlotAudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    public void Placed()
    {
        puzzleSlotAudioSource.PlayOneShot(completeClip);
    }


}
