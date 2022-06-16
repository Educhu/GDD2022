using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Controller.Enums;
using UnityEngine.SceneManagement;
using Assets.Scripts.Services;

public class GameManager : MonoBehaviour
{
    public List<EnemyScriptableObject> SOMobsList;

    public static GameManager instance;


    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    //Void Start
    private void Start()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);

        LifeSystem.StartLife();
        LifeSystem.AddPotion(2);
    }

    private void InstantiateMobs()
    {
        foreach (EnemyScriptableObject prefab in SOMobsList)
        {
            GameObject aux = Instantiate(prefab.Prefab);

            aux.transform.position = new Vector3(Random.Range(8, 7), Random.Range(-3, 5), 0);

            prefab.Id = aux.GetInstanceID();
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "Tutorial")
        {
            InstantiateMobs();
        }
    }

   public void RemoveEnemy(int enemyId)
    {
        foreach(EnemyScriptableObject enemy in SOMobsList)
        {
            if(enemy.Id == enemyId)
            {
                SOMobsList.Remove(enemy);
            }
        }
    }

    public Sprite CatchSpriteEnemy(int enemyId)
    {
        foreach (EnemyScriptableObject enemy in SOMobsList)
        {
            if (enemy.Id == enemyId)
            {
                return enemy.enemySprite;
            }
        }
        return null;
    }
     
    public Element CatchElementOfEnemy(int Id)
    {
        foreach(EnemyScriptableObject enemy in SOMobsList)
        {
            if(enemy.Id == Id)
            {
                return enemy.element;
            }
        }
        return Element.Mage;
    }

    public string CatchNameOfEnemy(int Id)
    {
        foreach (EnemyScriptableObject enemy in SOMobsList)
        {
            if (enemy.Id == Id)
            {
                return enemy.Nome;
            }
        }
        return "Não Catalogado";
    }

    public void AddToEnemyList(int Id, EnemyScriptableObject enemySO)
    {
        enemySO.Id = Id;

        SOMobsList.Add(enemySO);
    }

    public void OnButtonPlay()
    {
        SceneManager.LoadScene("Tutorial");
    }
}