using UnityEngine;

public class PuzzleSlots : MonoBehaviour
{
    //[SerializeField] AudioSource puzzleSlotAudioSource;

    [SerializeField] string wordSlot;


    // hidden components

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("PuzzlePiece"))
        {

        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("PuzzlePiece"))
        {

        }
    }









    public void SetWordName(string newWord)
    {
        wordSlot = newWord;
    }

    public string GetWordName()
    {
        return wordSlot;
    }



}
