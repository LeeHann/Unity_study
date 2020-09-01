using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoo : MonoBehaviour
{
    bool isOpen = false;
    bool isReallyOpen = false;

    Animal someAnimal = null;
    Animal otherAnimal = null;

    void Start()
    {
        // Animal tom = new Animal("톰", "애용");

        // // tom.name = "톰";
        // // tom.sound = "애용";
        // tom.PlaySound();       

        // Animal jerry = new Animal();

        // jerry.name = "제리";
        // jerry.sound = "찍..";
        // jerry.PlaySound();

        // GameObject obj = new GameObject("create_obj");

        // tom.name = "탐";
        // tom.PlaySound();

        // someAnimal = tom;
        // someAnimal.PlaySound();

        isOpen = true;
        isReallyOpen = isOpen;
        Debug.Log("is Really Open? : " + isReallyOpen);

        isOpen = false;
        Debug.Log("is Really Open?(2) : " + isReallyOpen);        

        Animal a = new Animal("animal A", "aa");
        someAnimal = a;
        otherAnimal = someAnimal;
        otherAnimal.PlaySound();

        someAnimal.name = "Some 동물";
        otherAnimal.PlaySound();
    }
}
