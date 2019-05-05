using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI : MonoBehaviour
{
    private Combat_Manager manager;

    public float health;

    private void Start()
    {
        manager = FindObjectOfType<Combat_Manager>();
    }

    public void Attack()
    {
        StartCoroutine(WaitASec());
    }

    IEnumerator WaitASec()
    {
        yield return new WaitForSeconds(2f);
        manager.NextTurn();
        Debug.Log("Enemy has attacked");
    }
}
