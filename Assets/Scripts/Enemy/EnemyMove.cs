using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMove : MonoBehaviour {
    [SerializeField] private Vector3 _move;
    [SerializeField] private float _speed;
    [SerializeField] private EnemyColliders[] _raycast;
    [Space]
    [SerializeField] private float _scaler;

    bool canMove = true;

    private void Start() {
        ReSize(); 
    }

    void Update()
    {
        if (!canMove) return;

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

    private void ReSize() {
        var width = Camera.main.orthographicSize * 2.0 * Screen.width / Screen.height;
        transform.localScale = new Vector3((float)width / _scaler, (float)width / _scaler, (float)width / _scaler);
    }
    public void Stop() {
        canMove = false;
    }
}
 