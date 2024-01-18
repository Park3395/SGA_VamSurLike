using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeetleQueenFSM : MonoBehaviour
{
    private enum BQState
    {
        Spawn,
        Idle,
        Walk,
        BeetleSpawn,
        FireSpit,
        Damaged,
        Flinch,
        Death
    }

    BQState e_State;

    public float HP;
    public float MaxHP;
}
