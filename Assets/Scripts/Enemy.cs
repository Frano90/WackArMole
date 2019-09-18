using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    public int maxHp;
    private int currentHp;
    public EnemyType type;
    public Spawner spawner;

    public event Action<EnemyType> OnEnemyDead = delegate { };

    private void DestroySelf()
    {
        OnEnemyDead(type);
        Destroy(gameObject);
    }

    public void DamageEnemy(int damage)
    {
        //Se le hace daño al tocarlo. Si se queda sin vida, se tiene que destruir
        currentHp -= damage;

        if(currentHp <= 0)
        {
            DestroySelf();
        }

    }

    public enum EnemyType
    {
        enemyBase
    }
}
