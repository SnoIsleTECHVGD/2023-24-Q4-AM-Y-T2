using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullCode : MonoBehaviour
{
    public GameObject Piece1, Piece2, Piece3, Piece4;
    public int realinteger;
    // Start is called before the first frame update
    void Start()
    {
        realinteger = 4;
    }

    // Update is called once per frame
    void Update()
    {


        Piece1 = GameObject.Find("Puzzle Slot 1(Clone)");
        Piece2 = GameObject.Find("Puzzle Slot 2(Clone)");
        Piece3 = GameObject.Find("Puzzle Slot 3(Clone)");
        Piece4 = GameObject.Find("Puzzle Slot 4(Clone)");
      










    }
}
