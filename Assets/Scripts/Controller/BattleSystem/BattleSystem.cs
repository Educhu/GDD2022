using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets.Scripts.Services;
using System;
using Assets.Scripts.Controller.Enums;

public class BattleSystem : MonoBehaviour
{
    public static BattleState state;

    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public GameObject auxEnemyPrefab;

    public GameObject attacksHudButtons;
    public GameObject hudAtack;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    Unit playerUnit;
    Unit enemyUnit;

    public Text dialogueText;

    public BattleHud playerHUD;
    public BattleHud enemyHUD;

    public List<Button> ActionButtons;
    //public List<ElementalEnemyScripitableObject> EnemyList;
    private CombatData dataCombat;

    public float attackDamage;

    public Image enemyImg;
    private GameManager gameManager;

    public double vidaDoPlayer;
    public bool probabilityHealEnemy;


    // Start is called before the first frame update
    void Start()
    {
        //carregando o Json:
        dataCombat = new CombatData();
        dataCombat.LoadData("CombatData");

        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        //state
        state = BattleState.START;

        

        StartCoroutine(SetupBattle());
    }


    //--------IEnumerator--------

    IEnumerator SetupBattle()
    {
        playerPrefab = Instantiate(playerPrefab, playerBattleStation);


        auxEnemyPrefab = Instantiate(enemyPrefab);


        auxEnemyPrefab.transform.SetParent(GameObject.FindGameObjectWithTag("EnemyCombatImg").transform);
        var rect = auxEnemyPrefab.GetComponent<RectTransform>();
        rect.localPosition = new Vector3(300, 100, 0);
        rect.localScale = new Vector3(4, 4, 1);

        enemyImg = auxEnemyPrefab.GetComponent<Image>();

        playerUnit = playerPrefab.GetComponent<Unit>();
        enemyUnit = enemyPrefab.GetComponent<Unit>();
       
        enemyImg.sprite = gameManager.CatchSpriteEnemy(dataCombat.EnemyID);
        enemyUnit.unitElement = gameManager.CatchElementOfEnemy(dataCombat.EnemyID);
        enemyUnit.unitName = gameManager.CatchNameOfEnemy(dataCombat.EnemyID);
        
        //
        
        playerUnit.currentHP = LifeSystem.Life;


        dialogueText.text = "Um " + enemyUnit.unitName + " quer lutar";

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);
        playerHUD.SetPotionHud();

        yield return new WaitForSeconds(1.5f);

        //state
        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    IEnumerator PlayerAttack(Element element)
    {
        if (state == BattleState.PLAYERTURN)
        {
            bool isDead = enemyUnit.ElementalTakeDamage(element);

            enemyHUD.SetHP(enemyUnit.currentHP);
            dialogueText.text = "O ataque acertou!";


            yield return new WaitForSeconds(1.5f);

            if (isDead)
            {
                state = BattleState.WON;
                EndBattle();

                LifeSystem.Instance.SetLife(playerUnit.currentHP);
            }
            else
            {
                state = BattleState.ENEMYTURN;
                StartCoroutine(EnemyTurn());
            }

            hudAtack.SetActive(true);
            attacksHudButtons.SetActive(false);
        }
    }

    public void ProbabilityCheck()
    {
        float actionProbability = 0.2f;

        float rnd = UnityEngine.Random.Range(0f, 1f);

        if(rnd <= actionProbability)
        {
            probabilityHealEnemy = true;

            Debug.Log("curou " + rnd);
        }
        else
        {
            probabilityHealEnemy = false;

            Debug.Log("não curou " + rnd);
        }
    }

   
    IEnumerator EnemyTurn()
    {
        ProbabilityCheck();   


        if(probabilityHealEnemy == false)
        {
            dialogueText.text = enemyUnit.unitName + " Ataca!";

            yield return new WaitForSeconds(1f);

            //usar o Elemento do inimigo
            bool isDead = playerUnit.ElementalTakeDamage(Element.Water);

            playerHUD.SetHP(playerUnit.currentHP);
            LifeSystem.Instance.SetLife(playerUnit.currentHP);

            yield return new WaitForSeconds(1f);

            if (isDead)
            {
                state = BattleState.LOST;
                EndBattle();

                LifeSystem.Instance.SetLife(0);
            }
            else
            {
                state = BattleState.PLAYERTURN;
                PlayerTurn();
            }
        }
        else if(probabilityHealEnemy == true)
        {
            dialogueText.text = enemyUnit.unitName + " Se Regenera!";

            yield return new WaitForSeconds(1f);

            enemyUnit.Heal(0.3f);
            enemyHUD.SetHP(enemyUnit.currentHP);

            yield return new WaitForSeconds(1f);

            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }

    IEnumerator PlayerHeal()
    {
        if (state == BattleState.PLAYERTURN && LifeSystem.Potion >= 0)
        {
            playerUnit.Heal(0.5f);

            playerHUD.SetHP(playerUnit.currentHP);
            LifeSystem.Instance.SetLife(playerUnit.currentHP);
            dialogueText.text = "A magia de cura lhe fortalece!";

            //metodo
            playerHUD.UsePotion();

            yield return new WaitForSeconds(1.5f);

            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
        else
        {
            state = BattleState.PLAYERTURN;
        }
    }

    IEnumerator PlayerDodge()
    {
        state = BattleState.PLAYERTURN;

        dialogueText.text = "Você desvia do " + enemyUnit.unitName;

        yield return new WaitForSeconds(1.5f);
    }

    IEnumerator Timer()
    {
        //rodar animação de morte

        //DestroyImmediate(auxEnemyPrefab, true);
        //enemyImg.sprite.SetActive(false);
        //enemyImg.SetActive(false);
        auxEnemyPrefab.SetActive(false);

        // sprite set active false.
        //ver se eu estou usando o enemy prefab.

        yield return new WaitForSeconds(5f);

        SceneManager.LoadScene("Tutorial", LoadSceneMode.Single);
    }



    //--------Metodos--------

    void EndBattle()
    {
        if (state == BattleState.WON)
        {
            //PlayerController.vida = vidaDoPlayer;
            LifeSystem.Instance.SetLife(playerUnit.currentHP);

            dialogueText.text = "Você ganhou a luta!";
            try
            {
                DestroyEnemy();
            }
            catch (Exception) { };

            StartCoroutine(Timer());
        }
        else if (state == BattleState.LOST)
        {
            dialogueText.text = "Você foi derrotado";

            Destroy(playerPrefab);
        }
    }

    void PlayerTurn()
    {
        dialogueText.text = "Escolha uma ação";

        for (int i = 0; i < ActionButtons.Count - 1; i++)
        {
            ActionButtons[i].interactable = true;
        }
    }

    public void OnElementAttack(int element)
    {
        attacksHudButtons.SetActive(false);
        hudAtack.SetActive(true);


        if (state == BattleState.PLAYERTURN)
        {
            IEnumerator coroutine = PlayerAttack((Element)element);

            StartCoroutine(coroutine);
        }
    }

    public void DestroyEnemy()
    {
        Debug.Log(dataCombat.EnemyID);
        gameManager.RemoveEnemy(dataCombat.EnemyID);
    }



    //--------Botões--------

    public void OnAttackButton()
    {
        if(state == BattleState.PLAYERTURN)
        {
            hudAtack.SetActive(false);
            attacksHudButtons.SetActive(true);

            for(int i = 0; i < ActionButtons.Count - 1; i++)
            {
                ActionButtons[i].interactable = false;
            }
        }
    }

    public void OnHealButton()
    {
        if (state == BattleState.PLAYERTURN)
        {
            StartCoroutine(PlayerHeal());
        } 
    }

    public void OnDodgeButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerDodge());
    }

    public void OnScapeButton()
    {
        if (state == BattleState.PLAYERTURN)
        {
            SceneManager.LoadScene("Tutorial", LoadSceneMode.Single);
        }  
    }
}
