using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Combat_Manager : MonoBehaviour
{
    public FightTurn turn;

    private GameObject enemy;
    private Enemy_AI enemyAI;

    public Player player;

    public Combat_UI combatUI;

    public GameObject arenaCam;

    public Transform enemySpot;

    public GameObject arena;



    public void Start_Battle(GameObject _enemy)
    {
        arena.SetActive(true);
        enemy = _enemy;
        player.gameObject.SetActive(false);
        enemy = Instantiate(enemy, enemySpot.position, Quaternion.identity);
        enemyAI = enemy.GetComponent<Enemy_AI>();
        arenaCam.SetActive(true);
        combatUI.ToggleBattlePanel();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        combatUI.ShowCurrentTurn(turn.ToString());
    }

    private void Stop_Battle()
    {
        arena.SetActive(false);
        player.gameObject.SetActive(true);
        Destroy(enemy);
        arenaCam.SetActive(false);
        combatUI.ToggleBattlePanel();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    //-----------------------------------User Input---------------------

    public void PhysicalAttack()
    {
        //deal damage to the enemy here
        NextTurn();
        combatUI.ToggleAttackPanel();
    }

    public void MagicAttack()
    {
        //deal damage to the enemy here
        NextTurn();
        combatUI.ToggleAttackPanel();
    }

    public void RunAway()
    {
        NextTurn();
        Stop_Battle();
    }


    //---------------------------Helpers-------------------------

    public void NextTurn()
    {
        CheckHealths();

        if(turn == FightTurn.Enemy)
        {
            turn = FightTurn.Player;
        }
        else
        {
            turn = FightTurn.Enemy;
            enemyAI.Attack();
        }
    }

    public void CheckHealths()
    {
        if (player.health <= 0)
        {
            PlayerLoses();
        }

        if(enemyAI.health <= 0)
        {
            PlayerWins();
        }
    }

    public void PlayerWins()
    {
        Stop_Battle();
        //give a reward to player....xp, or special item
    }

    public void PlayerLoses()
    {
        Stop_Battle();
        //game over
    }


}

public enum FightTurn { Player, Enemy };



