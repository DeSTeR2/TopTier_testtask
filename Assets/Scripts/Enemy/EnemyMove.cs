using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private Vector3 _move;
    [SerializeField] private float _speed;
    [SerializeField] private EnemyColliders[] _raycast;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += _move * _speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.transform.tag == "Wall") {
            GetRandomMove();
        }
    }

    private void GetRandomMove() {
        List<Vector2> possibleMoves = new List<Vector2>();

        for (int i=0; i < _raycast.Length;i++) {
            if (!_raycast[i].GetHit()) {
                possibleMoves.Add(_raycast[i]._pointVector);
            }
        }
        int index = Random.Range(0, 100) % possibleMoves.Count;
        _move = possibleMoves[index];
    }
}
 