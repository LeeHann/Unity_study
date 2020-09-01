using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal
{
    public string name;
    public string sound;

    //생성자
    public Animal()
    {
        name = "default";
        sound = "default";
    }
    public Animal(string name)
    {
        this.name = name;
        this.sound = "default";
    }
    public Animal(string name, string sound)
    {
        this.name = name;
        this.sound = sound;
    } 

    public void PlaySound()
    {
        Debug.Log(name + " : " + sound);
    }
}
