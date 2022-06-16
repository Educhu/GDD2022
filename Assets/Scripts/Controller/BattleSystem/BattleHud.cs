using Assets.Scripts.Controller.Enums;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHud : MonoBehaviour
{
	public Text nameText;
	public Text levelText;
	public Image hpForeGround;

	public GameObject imageElement;
	public Sprite fireElement;
	public Sprite waterElement;
	public Sprite thunderElement;
	public Sprite earthElement;
	public Sprite mageElement;

	public List<GameObject> BottleHudList;
	public Sprite potionEmpty;
	public Sprite potionFull;

	public void SetPotionHud()
    {
		for (int _potion = 0; _potion <= LifeSystem.Potion; _potion++)
		{
			BottleHudList[_potion].GetComponent<Image>().sprite = potionFull;
		}
	}

	public void UsePotion()
    {
		BottleHudList[LifeSystem.Potion].GetComponent<Image>().sprite = potionEmpty; ;
		LifeSystem.Instance.RemovePotion();
	}

	public void SetHUD(Unit unit)
	{
		nameText.text = unit.unitName;
		levelText.text = "Lvl " + unit.unitLevel;
		//hpForeGround.fillAmount = unit.maxHP;
		hpForeGround.fillAmount = (float)unit.currentHP;

		if (unit.unitElement == Element.Water)
        {
			imageElement.GetComponent<Image>().sprite = waterElement;
		}
		
		if(unit.unitElement == Element.Fire) 
		{
			imageElement.GetComponent<Image>().sprite = fireElement;
		}

		if (unit.unitElement == Element.Earth)
		{
			imageElement.GetComponent<Image>().sprite = earthElement;
		}

		if (unit.unitElement == Element.Thunder)
		{
			imageElement.GetComponent<Image>().sprite = thunderElement;
		}

		if(unit.unitElement == null)
        {
			imageElement.GetComponent<Image>().sprite = mageElement;
		}
	}

	public void SetHP(double hp)
	{
		hpForeGround.fillAmount = (float)hp;
	}
}
