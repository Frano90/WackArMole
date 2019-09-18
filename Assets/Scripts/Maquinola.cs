using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maquinola : MonoBehaviour
{
    //Hay que tener una lista de spawners a ser utilizados
    //Lista de prefabs de los enemigos
    //Llevar el score de los bichos matados

    public List<Spawner> spawners = new List<Spawner>();
    public List<GameObject> enemies = new List<GameObject>();
    public int timeBetweenSpawns;
    public ScoreManager scoreManager;
    public TextMesh score;

    private void Start()
    {
        InitGame();
    }


    public void InitGame()
    {
        //Inicia la maquina.
        StartCoroutine(SpawnDirector());
        RegisterSpawners();
    }

    private void RegisterSpawners()
    {
        foreach (Spawner sp in spawners)
        {
            sp.OnKilledEnemy += AddScore;
        }
    }

    private void UnregisterSpawners()
    {
        foreach (Spawner sp in spawners)
        {
            sp.OnKilledEnemy -= AddScore;
        }
    }

    private void AddScore(Enemy.EnemyType eType)
    {
        scoreManager.AddScore(eType);
        score.text = scoreManager.currentScore.ToString();
    }

    private IEnumerator SpawnDirector()
    {
        while(true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }

    private void SpawnEnemy()
    {
        //Debe elegir uno de los tantos spawners disponibles y le ordena spawnear uno ahi
        int rgnSpawn = Random.Range(0, spawners.Count);
        int rgnEnemies = Random.Range(0, enemies.Count);

        if(!spawners[rgnSpawn].IsSpawnerOccupied())
            spawners[rgnSpawn].SpawnEnemy(enemies[rgnEnemies]);
    }

    private void AddScore()
    {
        //sumar al score del tablero
    }
}
