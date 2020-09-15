using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//struct : 값 타입, 상속 못함, 매개변수가 없는 생성자를 만들 수 없음

public struct AttackInfo
{
    public AttackAttrib attrib;
    public int damage;

    public AttackInfo(AttackAttrib attrib, int damage)
    {
        this.attrib = attrib;
        this.damage = damage;
    }

    public int GetDamage(AttackAttrib attackedAttrib)
    {
        int addAttack = GetAddAttack(attrib, attackedAttrib);
        if(addAttack == 1) damage *= 2;
        else if(addAttack == -1) damage = Mathf.FloorToInt((float)damage*0.5f);
        
        return damage;
    }

   // -1 : 데미지 감소 | 0 : 데미지 유지 | 1 : 추가 데미지
    int GetAddAttack(AttackAttrib my, AttackAttrib your)
    {
        switch(my)
        {
            case AttackAttrib.Fire:
                if(your == AttackAttrib.Wind) return 1;
                else if(your == AttackAttrib.Water) return -1;
                return 0;

            case AttackAttrib.Water:
                if(your == AttackAttrib.Fire) return 1;
                else if(your == AttackAttrib.Wind) return -1;
                return 0;

            case AttackAttrib.Wind:
                if(your== AttackAttrib.Water) return 1;
                else if(your== AttackAttrib.Fire) return -1;
                return 0;
            default :
                return 0;
        }
   }
}
