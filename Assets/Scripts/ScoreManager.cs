using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName ="Scoreboard Manager")]
public class ScoreManager : ScriptableObject
{
    public int currentScore;
    public int scoreBaseEnemy;
    public GameObject scoreText;

    private void OnDisable()
    {
        currentScore = 0;
    }

    public void ModifyScore(int x)
    {
        //Modifica el valor de score
        currentScore += x;
    }

    private void UpdateScoreText()
    {
        //Actualizar el scoreboard
    }

    public void AddScore(Enemy.EnemyType type)
    {
        switch (type)
        {
            case Enemy.EnemyType.enemyBase:
                ModifyScore(scoreBaseEnemy);
                break;
            
        }
    }
}
