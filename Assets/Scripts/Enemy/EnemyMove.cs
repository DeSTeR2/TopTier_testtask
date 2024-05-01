using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public Vector3 _move;
    public float _speed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += _move*_speed*Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.transform.tag == "Wall") {
            GetRandomMove();
        }
    }

    private void GetRandomMove() {
        _move = Vector3.zero;
    }
}
