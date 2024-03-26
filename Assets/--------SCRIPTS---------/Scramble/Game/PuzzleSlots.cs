using System;
using UnityEngine;

public class PuzzleSlots : MonoBehaviour
{



    [SerializeField] string wordSlot;

    public GameObject puzzleSlotGameObject;

    // hidden components



    private void Awake()
    {

    }

    private void Update()
    {

    }

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

    public string GetPuzzleSlotText()
    {
        return wordSlot;
    }












}
