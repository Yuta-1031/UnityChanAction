using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_1Skeleton1 : MonoBehaviour
{
    private GameObject t_1EnemyController;
    private Temple1Enemy t_1Enemy;

    public GameObject parent;
    SleletonController skel;

    private void Start()
    {
        t_1EnemyController = GameObject.FindWithTag("T_1EneCon");
        t_1Enemy = t_1EnemyController.GetComponent<Temple1Enemy>();
        skel = parent.GetComponent<SleletonController>();
    }
    private void Update()
    {
        if(skel.hp <= 0)
        {
            t_1Enemy.Skeleton1SetFalse();
        }
    }
}
