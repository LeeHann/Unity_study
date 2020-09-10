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
  public GameObject itemBoxPrefab;
  public GameObject goalPrefab;
  public GameObject player;


  private void Start()
  {
    for (int z = 0; z < stage.Length; z++)
    {
      for (int x = 0; x < stage[z].Length; x++)
      {
        switch (stage[z][x])
        {
          case 'P':
            SetPropPosition(player, x, z);
            break;

          case 'W':
            LeavePropOnStage(wallPrefab, x, z);
            break;

          case 'I':
            LeavePropOnStage(itemBoxPrefab, x, z);
            break;

          case 'G':
            LeavePropOnStage(goalPrefab, x, z);
            break;

          default:
            break;
        }
      }
    }
  }

  void LeavePropOnStage(GameObject prop, int x, int z) //Prefab을 Scene의 stage위에 올려놓기
  {
    GameObject obj = Instantiate(prop, stageTransform);
    SetPropPosition(obj, x, z);
  }

  void SetPropPosition(GameObject prop, int x, int z) //실질적 배치 함수(플레이어 포함)
  {
    Vector3 newPos = new Vector3(x, 0.5f, -z);
    Vector3 correction = new Vector3(-(stage[z].Length * 0.5f), 0f, (stage.Length * 0.5f));
    prop.transform.position = newPos + correction + new Vector3(0.5f, 0f, -0.5f);
  }
}
