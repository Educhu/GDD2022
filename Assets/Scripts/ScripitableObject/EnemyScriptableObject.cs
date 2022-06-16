using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Controller.Enums;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/Enemy", order = 1)]
public class EnemyScriptableObject : ScriptableObject
{
    public int Id;
    public string Nome;
    public GameObject Prefab;
    public Element element;
    public Sprite enemySprite;
}
