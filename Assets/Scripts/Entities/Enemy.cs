using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Entities.Enums;

public class Enemy 
{
    public Vector2 Posicao { get; set; }
    public int Life { get; protected set; }
    public float Damage { get; protected set; }
    public string Name { get; protected set; }
//    public int Pos { get; protected set; }

    public Enemy()
    {
    }

    public Enemy(Vector2 posicao, int life, float damage, string name)
    {
        Posicao = posicao;
        Life = life;
        Damage = damage;
        Name = name;
    }



   
}
