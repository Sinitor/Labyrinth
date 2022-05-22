using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
 
public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST, WAIT}

public class BattleSystem : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    public BattleState state;

    public BattleHUD enemyHUD;
    public BattleHUD playerHUD;


    public TextMeshProUGUI dialogText;

    Unit playerUnit;
    Unit enemyUnit;

    private void Start()
    {
       state = BattleState.START;
       StartCoroutine(SetupBattle());
    } 
    IEnumerator SetupBattle()
    {
       GameObject playerGO =  Instantiate(playerPrefab, playerBattleStation);
       playerUnit = playerGO.GetComponent<Unit>();
       GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
       enemyUnit = enemyGO.GetComponent<Unit>();

        dialogText.text = "A wild " + enemyUnit.unitName + " approaches";

        playerHUD.SetHud(playerUnit);
        enemyHUD.SetHud(enemyUnit);

        yield return new WaitForSeconds(2);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }  
    IEnumerator PlayerAttack()
    {
        state = BattleState.WAIT;
        bool isDead =  enemyUnit.TakeDamage(playerUnit.damage);

        enemyHUD.SetHP(enemyUnit.currentHP);
        dialogText.text = "The attack is succesfull!";

       yield return new WaitForSeconds(2);

        if (isDead)
        {
            state = BattleState.WON;
            EndBattle();
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }  
    IEnumerator EnemyTurn()
    {
        dialogText.text = enemyUnit.unitName + " attacks!";
        yield return new WaitForSeconds(1);
        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);
        playerHUD.SetHP(playerUnit.currentHP);
        yield return new WaitForSeconds(1);
        if (isDead)
        {
            state = BattleState.LOST;
            EndBattle();
        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }
    private void EndBattle()
    {
        if (state == BattleState.WON)
        {
            dialogText.text = "You won the battle";
        }
        else if (state == BattleState.LOST)
        {
            dialogText.text = "You were defeated";
        }
    }
    private void PlayerTurn()
    {
        dialogText.text = "Choose an action:";
    }  
    IEnumerator PlayerHeal()
    {
        state = BattleState.WAIT;
        playerUnit.Heal(5);
        playerHUD.SetHP(playerUnit.currentHP);
        dialogText.text = "You feel renewed strenght!";
        yield return new WaitForSeconds(2);
        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }
    public void AttackButton()
    {
        if (state == BattleState.PLAYERTURN)
        {
           StartCoroutine(PlayerAttack());
        }
    }
    public void HealButton()
    {
        if (state == BattleState.PLAYERTURN)
        {
            StartCoroutine(PlayerHeal());
        }
    }
}
