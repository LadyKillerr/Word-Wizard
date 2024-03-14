using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] List<PuzzleSlots> slotPrefabs;
    [SerializeField] PuzzlePiece piecePrefabs;
    [SerializeField] Transform slotParent, pieceParent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
