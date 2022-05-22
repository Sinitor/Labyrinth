using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleHUD : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI lvlText;
    public Slider hpSlider; 

    public void SetHud(Unit unit)
    {
        nameText.text = unit.unitName;
        lvlText.text = "LVL " + unit.unitLevel;
        hpSlider.maxValue = unit.maxHP;
        hpSlider.value = unit.currentHP;
    } 

    public void SetHP(int hp)
    {
        hpSlider.value = hp;
    }
}
