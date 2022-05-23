using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Entities.Enums;
using UnityEngine.SceneManagement;
using Assets.Scripts.Services;

public class GameManager : MonoBehaviour
{
    public List<ElementalEnemyScripitableObject> SOMobsList;

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
    }

    private void InstantiateMobs()
    {
        foreach (ElementalEnemyScripitableObject prefab in SOMobsList)
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
        foreach(ElementalEnemyScripitableObject enemy in SOMobsList)
        {
            if(enemy.Id == enemyId)
            {
                SOMobsList.Remove(enemy);
            }
        }
    }

    public Sprite CatchSpriteEnemy(int enemyId)
    {
        foreach (ElementalEnemyScripitableObject enemy in SOMobsList)
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
        foreach(ElementalEnemyScripitableObject enemy in SOMobsList)
        {
            if(enemy.Id == Id)
            {
                return enemy.element;
            }
        }
        return Element.Mage;
    }

    public void OnButtonPlay()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
