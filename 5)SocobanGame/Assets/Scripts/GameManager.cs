using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{   
    char[][] stage = new char[10][]
    {
        new char[10]{'W', 'W', 'W', 'W', 'W', ' ', 'W', 'W', 'W', ' '},
        new char[10]{'W', ' ', ' ', ' ', 'W', ' ', 'W', 'G', 'W', ' '},
        new char[10]{'W', ' ', 'I', ' ', 'W', ' ', 'W', 'G', 'W', ' '},
        new char[10]{'W', ' ', 'I', ' ', 'W', ' ', 'W', 'G', 'W', ' '},
        new char[10]{'W', 'W', 'W', ' ', 'W', 'W', 'W', ' ', 'W', ' '},
        new char[10]{' ', 'W', 'W', ' ', ' ', 'P', ' ', ' ', 'W', ' '},
        new char[10]{' ', 'W', ' ', 'I', ' ', 'W', ' ', ' ', 'W', ' '},
        new char[10]{' ', 'W', ' ', ' ', ' ', 'W', 'W', 'W', 'W', ' '},
        new char[10]{' ', 'W', 'W', 'W', 'W', 'W', ' ', ' ', ' ', ' '},
        new char[10]{' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}
    };

    public Transform stageTransform;
    public GameObject wallPrefab;

    private void Start() {
        for(int z=0; z<stage.Length; z++)
        {
            for(int x=0; x<stage[z].Length; x++)
            {
                if(stage[z][x] == 'W')
                {
                    GameObject wallObj = Instantiate(wallPrefab, stageTransform);
                    // Vector3 newPos = new Vector3(x + (-4.5f), 0.5f, (4.5f) - z);
                    // wallObj.transform.position = newPos;

                    Vector3 newPos = new Vector3(x, 0.5f, -z);
                    Vector3 correction = new Vector3(-(stage[z].Length*0.5f), 0f, (stage.Length*0.5f));
                    wallObj.transform.position = newPos + correction + new Vector3(0.5f, 0f, -0.5f);
                    
                }
            }
        }
    }

}
