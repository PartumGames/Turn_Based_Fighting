using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Combat_UI : MonoBehaviour
{

    public GameObject battlePanel;

    public GameObject attackPanelButton;
    public GameObject attackPanel;
    //public GameObject closeButton;

    public Combat_Manager combatManager;

    private bool showBattlePanel = true;
    private bool showAttackPanel = true;

    public Text turnText;


    private void Start()
    {
        ToggleBattlePanel();
        ToggleAttackPanel();
    }

    public void ToggleBattlePanel()
    {
        showBattlePanel = !showBattlePanel;
        battlePanel.SetActive(showBattlePanel);
    }

    public void ToggleAttackPanel()
    {
        showAttackPanel = !showAttackPanel;

        attackPanelButton.SetActive(!showAttackPanel);
        attackPanel.SetActive(showAttackPanel);
    }


    public void RunAway()
    {
        combatManager.RunAway();
    }

    public void Attack()
    {
        combatManager.PhysicalAttack();
    }

    public void Magic()
    {
        combatManager.MagicAttack();
    }

    public void ShowCurrentTurn(string _turn)
    {
        turnText.text = _turn + "'s Turn";
    }

}
