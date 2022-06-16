using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeSystem : MonoBehaviour
{
    public static LifeSystem Instance;

    public static float Life { get; private set; }
    public static int Potion { get; private set; }

    public List<GameObject> BottleList;
    public Sprite potionEmpty;
    public Sprite potionFull;

    public Image hpForeGround;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        for(int i = 0; i <= Potion; i++)
        {
            BottleList[i].GetComponent<Image>().sprite = potionFull;
        }
    }

    private void Update()
    {
        UpdateLifeBar();
    }

    //POÇÃO:

    public void ReloadPotion()
    {
        if (Potion >= 0 && Potion <= 9)
        {
            BottleList[Potion].GetComponent<Image>().sprite = potionFull;
        }
    }

    public void RemovePotion()
    {
        Potion -= 1;
    }
    public void AddPotion()
    {
        Potion += 1;
    }

    public static void AddPotion(int quantidade)
    {
        Potion += quantidade;

        Debug.Log(Potion);
    }

    //VIDA:

    public void LifeIsFull()
    {
        Life = 1;
    }

    public void IncreaseLife(float vida)
    {
        Life += vida;
    }

    private void UpdateLifeBar()
    {
        hpForeGround.fillAmount = Life;
    }

    public void SetLife(float life)
    {
        Life = life;
    }

    public static void StartLife()
    {
        Life = 1;
    }
}
