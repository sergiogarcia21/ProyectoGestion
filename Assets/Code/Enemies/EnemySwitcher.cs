using System.Collections.Generic;
using UnityEngine;

public class EnemySwitcher : MonoBehaviour
{
    public List<EnemyConfigurationSO> enemies;
    private Enemy _enemy;
    private int _nextEnemyIndex = 0;
    private UIScreenController _uIScreenController;

    private void Awake()
    {
        _enemy = FindObjectOfType<Enemy>();
        _uIScreenController = FindObjectOfType<UIScreenController>();
    }

    public void StartGame()
    {
        Reset();
        SetNextEnemy();
    }

    public void Reset()
    {
        _nextEnemyIndex = 0;
    }

    public void SetNextEnemy()
    {
        if(_nextEnemyIndex >= enemies.Count)
        {
            EndGame();
            return;
        }

        _enemy.SetConfiguration(enemies[_nextEnemyIndex]);
        _nextEnemyIndex++;
    }

    private void EndGame()
    {
        print("Juego terminado");
        _uIScreenController.SwitchScreen("EndOfGame");
    }
}
