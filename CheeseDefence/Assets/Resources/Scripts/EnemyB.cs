using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyB : Enemy
{
    void Start()
    {
        Spd = 1.0f;
        base.Start();
        Life = 10;
        AtacckPoint = 4;
        ScorePoint = 100;
    }

}
