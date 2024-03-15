using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] List<PuzzleSlots> slotPrefabs;
    [SerializeField] PuzzlePiece piecePrefabs;
    [SerializeField] Transform slotParent, pieceParent;
    public List<string> puzzleAnswer;

    private void Start()
    {
        for (int i = 0; i < slotPrefabs.Count; i++)
        {
            slotPrefabs[i].SetWordName(puzzleAnswer[i]);
        }

    }

    void Spawn()
    {
        
    }
}
