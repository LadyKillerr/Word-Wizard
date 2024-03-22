using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [Header("Prefabs của các ô trống")]
    [SerializeField] List<PuzzleSlots> slotPrefabs;

    [Header("Đáp án của các ô trống đó")]
    public List<string> puzzleAnswer;

    private void Start()
    {
        for (int i = 0; i < slotPrefabs.Count; i++)
        {
            // set từ đã định cho các prefabs variant mình đặt vào 
            slotPrefabs[i].SetWordName(puzzleAnswer[i]) ;
        }

    }

    void Spawn()
    {
        
    }
}
