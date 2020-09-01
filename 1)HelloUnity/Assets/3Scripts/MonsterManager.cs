using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    void Start()
    {
        Monster m1 = new Monster();
        m1.name = "monster1";
        m1.age = 10;
        m1.power = 1;
        m1.Attack();

        Monster m2 = new Monster("monster2");
        m2.age = 20;
        m2.power = 2;
        m2.Run();

        Monster m3 = new Monster("monster3", 30);       
        m3.power = 3;
        m3.Attack();
    }

}
