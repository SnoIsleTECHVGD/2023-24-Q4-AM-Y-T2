using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class RefCode : MonoBehaviour
{

    public TargetCode Creature;

    private float WinTimer => Creature.WinTimer;
    private float DeathTimer => Creature.deathtimer;
    private bool GameWin => Creature.YouWon;
    private bool Dead => Creature.IsDead;

}
