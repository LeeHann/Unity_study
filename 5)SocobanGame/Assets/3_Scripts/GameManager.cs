using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  // 한 칸 씩 움직이는 소코반 게임
  // 가변 배열
  char[][] stage = new char[10][]
  {
        new char[10]{'W', 'W', 'W', 'W', 'W', ' ', 'W', 'W', 'W', ' '},
        new char[10]{'W', ' ', ' ', ' ', 'W', ' ', 'W', 'G', 'W', ' '},
        new char[10]{'W', ' ', 'I', ' ', 'W', ' ', 'W', 'G', 'W', ' '},
        new char[10]{'W', ' ', 'I', ' ', 'W', ' ', 'W', 'G', 'W', ' '},
        new char[10]{'W', 'W', 'W', ' ', 'W', 'W', 'W', ' ', 'W', ' '},
        new char[10]{' ', 'W', 'W', ' ', ' ', ' ', ' ', ' ', 'W', ' '},
        new char[10]{' ', 'W', ' ', 'I', ' ', 'W', ' ', 'P', 'W', ' '},
        new char[10]{' ', 'W', ' ', ' ', ' ', 'W', 'W', 'W', 'W', ' '},
        new char[10]{' ', 'W', 'W', 'W', 'W', 'W', ' ', ' ', ' ', ' '},
        new char[10]{' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}
  };

  public Transform stageTransform;
  public GameObject wallPrefab;
  public GameObject itemBoxPrefab;
  public GameObject goalPrefab;
  public MoveableProp player;
  List<MoveableProp> itemBoxes;

  private void Start()
  {
    itemBoxes = new List<MoveableProp>();
    for (int z = 0; z < stage.Length; z++)
    {
      for (int x = 0; x < stage[z].Length; x++)
      {
        switch (stage[z][x])
        {
          case 'P':
            SetPropPosition(player.gameObject, x, z);
            player.Init(x, z);
            break;

          case 'W':
            LeavePropOnStage(wallPrefab, x, z);
            break;

          case 'I':
            GameObject item = LeavePropOnStage(itemBoxPrefab, x, z);

            MoveableProp moveableItem = item.GetComponent<MoveableProp>();

            itemBoxes.Add(moveableItem); //List Add/Remove/Removeat

            // itemBoxes.Remove(moveableItem);
            // itemBoxes.RemoveAt(index);
            
            moveableItem.Init(x,z);
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

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.UpArrow))
    {
      Vector3 upVector = new Vector3(0f, 0f, 1f);
      MovePlayer(upVector);
    }
    if (Input.GetKeyDown(KeyCode.DownArrow))
    {
      Vector3 downVector = new Vector3(0f, 0f, -1f);
      MovePlayer(downVector);
    }
    if (Input.GetKeyDown(KeyCode.LeftArrow))
    {
      Vector3 leftVector = new Vector3(-1f, 0f, 0f);
      MovePlayer(leftVector);
    }
    if (Input.GetKeyDown(KeyCode.RightArrow))
    {
      Vector3 rightVector = new Vector3(1f, 0f, 0f);
      MovePlayer(rightVector);
    }


  }

  void MovePlayer(Vector3 dir)
  {
    int moveX = (int)(player.myPos.x + dir.x);
    int moveZ = (int)(player.myPos.z - dir.z);

    char destination = stage[moveZ][moveX];

    switch (destination)
    {
      case 'W':
        break;

      case 'I':
        int nextX = (int)(moveX + dir.x);
        int nextZ = (int)(moveZ - dir.z);
        char nextItem = stage[nextZ][nextX]; //플레이어가 미는 아이템의 전방
        if (!(nextItem == 'W' || nextItem == 'I'))
        {
          stage[moveZ][moveX] = 'P';
          stage[nextZ][nextX] = 'I';

          player.Move(dir);
          foreach(var i in itemBoxes)
          {
            if(i.myPos.x == moveX && i.myPos.z == moveZ)
            {
              i.Move(dir);
            }
          }
        }
        break;

      case ' ':
      case 'P':
      case 'G':
        player.Move(dir);
        break; 
    }
  }

  bool MoveProp(int moveX, int moveZ, MoveableProp prop)
  {
    char moveCell = stage[moveZ][moveX];

    switch (moveCell)
    {
      case 'W':
        return false;

      case 'I':
      foreach(var item in itemBoxes)
      {
        if(item.myPos == new Vector3(moveX, 0f, moveZ))
        {

        }
      }
        return true;
        
      default :
      return false;
    }
  }

  GameObject LeavePropOnStage(GameObject prop, int x, int z) //Prefab을 Scene의 stage위에 올려놓기
  {
    GameObject obj = Instantiate(prop, stageTransform);
    SetPropPosition(obj, x, z);

    return obj;
  }

  void SetPropPosition(GameObject prop, int x, int z) //실질적 배치 함수(플레이어 포함)
  {
    Vector3 newPos = new Vector3(x, 0f, -z);
    Vector3 correction = new Vector3(-(stage[z].Length * 0.5f), 0f, (stage.Length * 0.5f));
    prop.transform.position = newPos + correction + new Vector3(0.5f, 0f, -0.5f);
  }
}
