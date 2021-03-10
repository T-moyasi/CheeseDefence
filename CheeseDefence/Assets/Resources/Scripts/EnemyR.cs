using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyR : Enemy
{
    void Start()
    {
        Spd = 3f;
        base.Start();
        Life = 1;
        AtacckPoint = 1;
        ScorePoint = 1;
    }

  
}
