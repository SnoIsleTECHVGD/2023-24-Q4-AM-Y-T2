using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private List<PuzzleSlot> _slotPrefabs;
    [SerializeField] private PuzzlePiece _piecePrefab;
    [SerializeField] private Transform _slotParent, _pieceParent;
    GameObject slotchecker;
    public int puzzlecounting;

    void Start()
    {
        Spawn();

    }

    private void Update()
    {

        //slotchecker = GameObject.Find("Puzzle Slot 1(Clone)");

        //puzzlecounting = slotchecker.GetComponent<PuzzleSlot>().pubnumber;

        //if (puzzlecounting == 0)
        //{
        //    Spawn();
        //    CancelInvoke(nameof(Spawn));

        //}
    }

    void Spawn()
    {
        var randomSet = _slotPrefabs.OrderBy(s=>Random.value).Take(4).ToList();

        for(int i = 0; i < randomSet.Count; i++)
        {
            var spawnedSlot = Instantiate(randomSet[i], _slotParent.GetChild(i).position, Quaternion.identity);

            var spawnedPiece = Instantiate(_piecePrefab, _pieceParent.GetChild(i).position, Quaternion.identity);
            spawnedPiece.Init(spawnedSlot);
        }
    }
}
