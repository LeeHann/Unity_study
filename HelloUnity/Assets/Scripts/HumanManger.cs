using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanManger : MonoBehaviour
{
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
        ShowEnding(player.love[0]);
        ShowEnding(player.love[1]);
        ShowEnding(player.love[2]);
    }

    void ShowEnding(int love)
    {
        if(love < 50)
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
}
