using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ContainManager : MonoBehaviour
{
    [SerializeField] private List<ContainSlot> _slotPrefabs;
    [SerializeField] private ContainPiece _piecePrefab;
    [SerializeField] private Transform _slotParent, _pieceParent;
    PuzzleSlot slotchecker;
    public int puzzlecounting;

    void Start()
    {
        Spawn();

    }

    private void Update()
    {

        //slotchecker = GameObject.Find("Puzzle Slot 1(Clone)").GetComponent<PuzzleSlot>();

        //puzzlecounting = slotchecker.GetComponent<PuzzleSlot>().pubnumber;

        //if (puzzlecounting == 0)
        //{
        //    Spawn();
        //    CancelInvoke(nameof(Spawn));

        //}
    }

    void Spawn()
    {
        var randomSet = _slotPrefabs.OrderBy(s => Random.value).Take(4).ToList();

        for (int i = 0; i < randomSet.Count; i++)
        {
            var spawnedSlot = Instantiate(randomSet[i], _slotParent.GetChild(i).position, Quaternion.identity);

            var spawnedPiece = Instantiate(_piecePrefab, _pieceParent.GetChild(i).position, Quaternion.identity);
            spawnedPiece.Init(spawnedSlot);
        }
    }
}
