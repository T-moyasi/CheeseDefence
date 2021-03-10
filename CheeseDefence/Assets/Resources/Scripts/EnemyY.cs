using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyY : Enemy
{
    void Start()
    {
        Spd = 2.0f;
        base.Start();
        Life = 3;
        AtacckPoint = 2;
        ScorePoint = 10;
    }

 
}
