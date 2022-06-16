using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Scripts.Services;
using Assets.Scripts.Controller.Enums;

[System.Serializable]
public class MobController : MonoBehaviour
{
    public BattleState state;
    public bool isAlive = true;


    public Element Element { get; private set; }
    public List<Vector3> pointsPatrol { get; private set; } = new List<Vector3>();
    private int Pos;

    // Start is called before the first frame update
    void Start()
    {
        AddPointPatrol(new Vector3(10, 0, 0));
        AddPointPatrol(new Vector3(-10, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        Patrol(GetComponent<Transform>());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            var dataCombat = new CombatData();
            dataCombat.EnemyID = gameObject.GetInstanceID();

            dataCombat.SaveData("CombatData");

            SceneManager.LoadScene("Combate", LoadSceneMode.Single);
        }
    }

    public void AddPointPatrol(Vector2 point)
    {
        pointsPatrol.Add(point);
    }

    public void Patrol(Transform actualTransform)
    {
        switch (Pos)
        {
            case 0:

                if (!(actualTransform.position.x >= pointsPatrol[0].x))
                    actualTransform.Translate(Vector3.right * Time.deltaTime * 2);
                else
                    Pos++;

                break;

            case 1:

                if (!(actualTransform.position.x <= pointsPatrol[1].x))
                    actualTransform.Translate(Vector3.left * Time.deltaTime * 2);
                else
                    Pos--;

                break;
        }
    }
}
