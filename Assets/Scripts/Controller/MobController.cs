using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Entities.Enums;
using UnityEngine.SceneManagement;
using Assets.Scripts.Services;

[System.Serializable]
public class MobController : MonoBehaviour
{
    public Mob m1;
    public Mob m2;
    public Mob m3;

    public BattleState state;
    public bool isAlive = true; 

    // Start is called before the first frame update
    void Start()
    {
        m1 = new Mob();

        m1.AddPointPatrol(new Vector3(10, 0, 0));
        m1.AddPointPatrol(new Vector3(-10, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        m1.Patrol(GetComponent<Transform>());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            var dataCombat = new CombatData();
            dataCombat.EnemyID = gameObject.GetInstanceID();

            dataCombat.SaveData("CombatData");

            SceneManager.LoadScene("Combate", LoadSceneMode.Single);
        }
    }
}
