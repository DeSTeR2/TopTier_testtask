using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemy;
    [SerializeField] private GameObject[] _spawnPoints;
    
    bool _start = true;
    int _enemyNumber;
    int _enemyIndex;

    private void Start() {

        _enemyNumber = Random.Range(1, 4);
        _enemyIndex = Random.Range(0, _enemy.Length);

        for (int i=0; i<_enemyNumber;i++) {
            Instantiate(_enemy[_enemyIndex], _spawnPoints[i].transform.position, Quaternion.identity, transform);
        }
        _start = false; 
    }

    public void Restart() {
        if (_start) return;
        for (int i=0; i< _enemyNumber; i++) {
            Destroy(transform.GetChild(i).gameObject);
        }
        _enemyNumber = Random.Range(1, 4);
        _enemyIndex = Random.Range(0, _enemy.Length);
        Start();
    }

    public void Stop() {
        List<GameObject> enemies = new List<GameObject>();
        for (int i = 0; i < _enemyNumber; i++) {
            enemies.Add(transform.GetChild(i).gameObject);
        }
        foreach (GameObject enemy in enemies) {
            enemy.GetComponent<EnemyMove>().Stop();
        }
    }
}
