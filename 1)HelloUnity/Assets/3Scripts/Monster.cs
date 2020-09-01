using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster
{
  public string name;
  public int age;
  public int power;

  public Monster()
  {
    this.name = "default";
    this.age = 0;
    this.power = 0;
  }
  public Monster(string name)
  {
    this.name = name;
    this.age = 0;
    this.power = 0;
  }
  public Monster(string name, int age)
  {
    this.name = name;
    this.age = age;
    this.power = 0;
  }
  public Monster(string name, int age, int power)
  {
    this.name = name;
    this.age = age;
    this.power = power;
  }

  public void Attack()
  {
      Debug.Log("name : "+name+" age : "+age+" power : "+power + " 공격");
  }
  public void Run()
  {
      Debug.Log("달리기, "+"name : "+name+" age : "+age+" power : "+power+ " 달리기");
  }
}
