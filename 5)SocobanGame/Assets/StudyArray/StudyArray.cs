using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudyArray : MonoBehaviour
{
    // 2차원 배열
    char[,] array = new char[3, 8]
    {
        {' ', ' ', 'W', 'W', ' ', ' ', 'W', ' '},
        {' ', ' ', ' ', ' ', ' ', ' ', 'W', ' '},
        {' ', ' ', ' ', ' ', ' ', ' ', 'W', ' '}
    };

    // 3차원 배열

    char[,,] threeArray = new char[2,2,3]
    {
        {{'0', '1', '2'}, {'3', '4', '5'}},
        {{'0', '1', '2'}, {'3', '4', '5'}}
    };

    // 가변 배열
    char[][] trees = new char[8][]
    {
        new char[8]{' ', ' ', 'W', 'W', ' ', ' ', 'W', ' '},
        new char[8]{' ', ' ', ' ', ' ', ' ', ' ', 'W', ' '},
        new char[8]{' ', ' ', ' ', ' ', ' ', ' ', 'W', ' '},
        new char[8]{' ', ' ', 'W', ' ', ' ', ' ', ' ', ' '},
        new char[8]{'W', 'W', 'W', ' ', ' ', ' ', ' ', 'W'},
        new char[8]{' ', ' ', 'W', 'W', 'W', ' ', ' ', 'W'},
        new char[8]{' ', 'W', 'W', ' ', ' ', 'W', 'W', ' '},
        new char[8]{' ', 'W', 'W', ' ', ' ', 'W', 'W', 'W'}
    };

    public Transform stageTransform;
    public GameObject treePrefab;
    public Color[] treeColor;

    void Array()
    {
        //가변 배열의 크기 가져오기
        int sizeOfArray = trees.Length;
        int sizeOfArrayInArray = trees[3].Length;

        //2차원 배열의 크기 가져오기
        int firstSizeOfArray = array.GetLength(0); // 3
        int secSizeofArray = array.GetLength(1); // 8

        //3차원 배열 크기
        int thirdSizeOfArray = threeArray.GetLength(2); // 3

    }
    private void Start() {
        for(int z=0; z<trees.Length; z++)
        {
            for(int x=0; x<trees[z].Length; x++)
            {
                if(trees[z][x] == 'W')
                {   
                    GameObject treeObj = Instantiate(treePrefab, stageTransform);
                    
                    Vector3 newPos = new Vector3(x, 0f, -z);
                    Vector3 correction = new Vector3(-(trees[z].Length*0.5f), 0f, (trees.Length*0.5f));
                    treeObj.transform.position = newPos + correction + new Vector3(0.5f, 0f, -0.5f);

                    float randomFloat = Random.Range(0.7f, 1.3f);
                    treeObj.transform.localScale = new Vector3(randomFloat, randomFloat, randomFloat);
                    
                    treeObj.GetComponent<Tree>().leafRenderer.material.color = treeColor[Random.Range(0, treeColor.Length)];
                }
            }
        }
    }
}
