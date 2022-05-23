using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Entities.Enums;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/Enemy/Elemental", order = 1)]
public class ElementalEnemyScripitableObject : ScriptableObject
{
    public int Id;
    public GameObject Prefab;
    public Element element;
    public Sprite enemySprite;
}
