using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanManger : MonoBehaviour
{
    float a = 1.0f;
    public Player player;
    public Human[] humans;
    
    void Start()
    {
        // Debug.Log("------first------");
        // humans[0].Say();
        // Debug.Log("------second------");
        // humans[1].Say();
        // Debug.Log("------third------");
        // humans[2].Say();

        // for(int i=0; i<humans.Length; i++)
        // {
        //     Debug.Log("---------" + (i+1) + "----------");
        //     humans[i].Say();
        // }


        // ShowEnding(player.love[0]);
        // ShowEnding(player.love[1]);
        // ShowEnding(player.love[2]);

        foreach(int f in player.love)
        {
            ShowEnding(f);
        }

        for(int i = 0; i<player.love.Length; i++)
        {
            ShowEnding(player.love[i]);
        }

        int j = 0;
        while(j < player.love.Length)
        {
            ShowEnding(player.love[j]);
            j++;
        }
    }

    void ShowEnding(int love)
    {
        if(isEnding(love))
        {
            Debug.Log("Bad End");
        }
        else if(love < 100)
        {
            Debug.Log("Good End");
        }
        else
        {
            Debug.Log("hidden End");
        }
    }

    bool isEnding(int f)
    {
        //return f < 50;
        return !(f>=50);
    }
}
