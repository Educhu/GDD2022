using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Entities.Enums;

public class Mob : Enemy
{
    public Element Element { get; private set; }
    public List<Vector3> pointsPatrol { get; private set; } = new List<Vector3>();
    private int Pos;

    //public Vector3 destino1, destino2, destino3, destino4;

    public Mob()
    {
    }

    public Mob(Element element, Vector2 posicao, int life, float damage, string name): base(posicao, life, damage, name) 
    {
        Element = element;
        Life = life;
        Damage = damage;
        Name = name;
        Pos = 0;        
    }

    public void AddPointPatrol(Vector2 point)
    {
        pointsPatrol.Add(point);
    }

    public void Patrol(Transform actualTransform)
    {
        switch(Pos)
        {
            case 0: 

                if(!(actualTransform.position.x >= pointsPatrol[0].x))
                    actualTransform.Translate(Vector3.right * Time.deltaTime * 2);
                else
                    Pos++;

                break;

            case 1:

                if (!(actualTransform.position.x <= pointsPatrol[1].x))
                    actualTransform.Translate( Vector3.left * Time.deltaTime * 2 );
                else
                    Pos--;

                break;
        }
    }
}
