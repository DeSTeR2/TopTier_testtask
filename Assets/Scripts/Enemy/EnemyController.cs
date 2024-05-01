using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private GameObject[] _spawnPoints;
    public int _enemyNumber;

    private void Start() {
        for (int i=0; i<_enemyNumber;i++) {
            Instantiate(_enemy, _spawnPoints[i].transform.position, Quaternion.identity, transform);
        }
    }
}
