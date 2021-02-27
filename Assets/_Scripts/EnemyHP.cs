using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public float this_HP;
    public float buff;
    public float hal_buff;
    public GameObject main;

    public void DamegeFromPlayer(int damage)
    {
        this_HP -= damage * buff;
    }

    public void DamageFromHal(int damage)
    {
        this_HP -= damage * hal_buff;
    }
}
