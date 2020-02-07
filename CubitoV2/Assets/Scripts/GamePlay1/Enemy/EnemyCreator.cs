using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator : MonoBehaviour
{
    public GameObject enemyPrefab;
    public List<GameObject> enemies = new List<GameObject>();

    public void CreateEnemy(bool _move = false, bool _spawn = false, bool _enabled = false)
    {
        GameObject enemy = Instantiate(enemyPrefab) as GameObject;

        if (_enabled){enemy.SetActive(true);}
        if (_spawn){enemy.GetComponent<EnemySpawn>().SpawnEnemy();}
        enemy.GetComponent<EnemyMovement>().enabled = _move;

        enemies.Add(enemy);
    }

    public void SpawnAllEnemies()
    {
        foreach (GameObject _enemy in enemies)
        {
            _enemy.GetComponent<EnemySpawn>().SpawnEnemy();
        }
    }

    public void ActivateAllEnemies()
    {
        foreach (GameObject _enemy in enemies)
        {
            _enemy.SetActive(true);
        }
    }

    public void EnableMovementAllEnemies(bool _enabled)
    {
        foreach (GameObject _enemy in enemies)
        {
            _enemy.GetComponent<EnemyMovement>().enabled = _enabled;
        }
    }

}
