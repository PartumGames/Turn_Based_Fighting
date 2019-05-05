using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight_Spot : MonoBehaviour
{

    public Combat_Manager manager;
    public GameObject enemy;

    private bool canFight = true;


    private void OnTriggerEnter(Collider other)
    {
        if (canFight)
        {
            if (other.CompareTag("Player"))
            {
                canFight = false;
                manager.Start_Battle(enemy);
            }
        }
    }

}
