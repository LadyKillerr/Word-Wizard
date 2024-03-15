using UnityEngine;

public class PuzzleSlots : MonoBehaviour
{
    //[SerializeField] AudioSource puzzleSlotAudioSource;
    [SerializeField] AudioClip completeClip;
    public string wordName;


    // hidden components
    AudioSource puzzleSlotAudioSource;

    public void SetWordName(string newWord)
    {
        wordName = newWord;
    }

    public string GetWordName()
    {
        return wordName;
    }

    void Start()
    {
        puzzleSlotAudioSource = GetComponent<AudioSource>();
    }

    public void Placed()
    {
        puzzleSlotAudioSource.PlayOneShot(completeClip);
    }



}
