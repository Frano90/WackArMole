using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Spawner : MonoBehaviour
{
    //bool para saber si esta siendo usado o no
    bool IsOccupied = false;
    GameObject currentEnemyInSpawner;
    public event Action<Enemy.EnemyType> OnKilledEnemy = delegate { };
    public int spawnerID;
    public Transform hammerPlace;

    public void SpawnEnemy(GameObject enemy_prefab)
    {
        //Recibe el prefab que tiene que spawnear y lo hace
        //Debe decir que esta siendo ocupado por un bicho
        //Al instanciar el bicho, debe subscribirse al aviso de cuando se destruye asi se destraba
        currentEnemyInSpawner = Instantiate<GameObject>(enemy_prefab);
        currentEnemyInSpawner.transform.SetParent(transform);
        currentEnemyInSpawner.transform.localPosition = Vector3.zero;
        currentEnemyInSpawner.GetComponent<Enemy>().OnEnemyDead += FreeSpawn;
        currentEnemyInSpawner.GetComponent<Enemy>().spawner = this;
        IsOccupied = true;
       
    }

    public void FreeSpawn(Enemy.EnemyType enemyType)
    {
        //libera el spawn para volver a usarse
        currentEnemyInSpawner = null;
        IsOccupied = false;
        OnKilledEnemy(enemyType);
    }

    public bool IsSpawnerOccupied()
    {
        return IsOccupied;
    }
}
