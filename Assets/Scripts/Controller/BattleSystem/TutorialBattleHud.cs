using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialBattleHud : MonoBehaviour
{
    public Image hpForeGround;
    public GameObject playerPrefab;

    public Unit playerUnit;
    

    // Start is called before the first frame update
    void Start()
    { 
        playerUnit = playerPrefab.GetComponent<Unit>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(hpForeGround.fillAmount);
    }

    public void SetHUD(Unit unit)
    {
        Debug.Log("sethud");
        hpForeGround.fillAmount = (float)unit.currentHP;
    }

    public void SetHP(double hp)
    {
        Debug.Log("setHp");
        hpForeGround.fillAmount = (float)hp;
    }
}
