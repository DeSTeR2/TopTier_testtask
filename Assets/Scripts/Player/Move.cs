using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Vector3 _move;
    public float _speed;
    public Arrow _arrow;
    public float _rotationAngle;
    public int _angle = 60;

    public bool _isMoving = false;

    private int _canMove = 0;
    private Rigidbody2D _rb;
    public float _fullRotationAngle = 0;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.gravityScale = 0;
    }

    // Update is called once per frame
    void Update() 
    { 
        if (!_isMoving) {
            ChangeMoveVector(_rotationAngle);
            _arrow.ChangePosition(_move + transform.position);
        } else {
            transform.position += (_move * _speed * Time.deltaTime)*_canMove;
        }
    }

    private void ChangeMoveVector(float angle) {
        Vector3 rotatedVector = _move;

        float angleRadiant = Mathf.Deg2Rad * angle;

        rotatedVector.x = Mathf.Cos(angleRadiant) * _move.x - Mathf.Sin(angleRadiant) * _move.y;
        rotatedVector.y = Mathf.Sin(angleRadiant) * _move.x + Mathf.Cos(angleRadiant) * _move.y;
        _move = rotatedVector;

        _fullRotationAngle += angle;
        if (_fullRotationAngle >= _angle) {
            _rotationAngle *= -1;
            _fullRotationAngle = 0;
        }
        else if (_fullRotationAngle <= -_angle) {
            _rotationAngle *= -1;
            _fullRotationAngle = 0;
        }
    }

    public void MovePlayer() {
        _isMoving = true;
        _canMove = 1;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        ChangeMoveVector(180);
        _isMoving = false;
        _canMove = 0;
    }

    private void OnCollisionStay2D(Collision2D collision) {
        _isMoving = false;
        _canMove = 0;
    }
}
