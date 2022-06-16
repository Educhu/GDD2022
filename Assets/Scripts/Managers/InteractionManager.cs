using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets.Scripts.Services;

public class InteractionManager : MonoBehaviour
{
    public static bool hasKlausInteraction = false;
    public static bool isKlausInstantiated = false;

    public static GameObject klaus;
    public GameObject klausPrefab;
    public GameObject player;

    private Vector3 klausDestinationPosition;
    static private bool isKlausMoving = false;
    private float typingSpeed;


    public GameObject baloom;
    public EnemyScriptableObject klausSO;


    // Start is called before the first frame update
    void Awake()
    {
        klaus = klausPrefab;

        klausDestinationPosition = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
    }



    private void Update()
    {
        KlausMoving();
    }

    public static void InstanciaKlaus()
    {
        if(!hasKlausInteraction && !isKlausInstantiated)
        {
            klaus = Instantiate(klaus, new Vector3(0, -24, 0), Quaternion.identity);
            isKlausInstantiated = true;
            isKlausMoving = true;
        }
    }

    public void KlausMoving()
    {
        if (isKlausMoving)
        {
            //ENQUANTO o Klaus não está na posição final faça:
            if (!klaus.transform.position.Equals(klausDestinationPosition))
            {
               
                klausDestinationPosition = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);

                klaus.transform.position = Vector3.Lerp(klaus.transform.position,
                                                        klausDestinationPosition, Time.deltaTime);

                if (Vector3.Distance(klaus.transform.position, player.transform.position) <= 2.1f)
                {
                    klausDestinationPosition -= new Vector3(0, 2, 0);
                    klaus.transform.position = klausDestinationPosition;
                }
            }
            else
            {
                isKlausMoving = false;
                baloom.SetActive(true);

                var dataCombat = new CombatData();
                dataCombat.EnemyID = gameObject.GetInstanceID();

                dataCombat.SaveData("CombatData");
            }
        }
    }
    public void StartKlausBattle()
    {
        hasKlausInteraction = true;
        //chamar a cena de Combate e passar as informações da batalha.

        if(hasKlausInteraction)
        {
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>()
            .AddToEnemyList(klaus.GetInstanceID(), klausSO);

            var dataCombat = new CombatData();
            dataCombat.EnemyID = klaus.GetInstanceID();
            dataCombat.SaveData("CombatData");

            SceneManager.LoadScene("Combate", LoadSceneMode.Single);
        }
    }
}
