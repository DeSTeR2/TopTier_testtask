using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Move : MonoBehaviour
{
    [SerializeField] private Vector3 _move;
    [SerializeField] private float _speed;
    [SerializeField] private Arrow _arrow;
    [SerializeField] private float _rotationAngle;
    [SerializeField] private int _angle = 60;
    [SerializeField] private GameObject[] colliders;
    [SerializeField] private GameObject _rotation;
    [SerializeField] private AudioClip _moveSound;

    private AudioSource _moveAudio;
    private bool _isMoving = false;

    private int _canMove = 0;
    private Rigidbody2D _rb;
    private float _fullRotationAngle = 0;

    // Start is called before the first frame update
    void Start() {
        _moveAudio = GetComponent<AudioSource>();
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
        SetVectorAngle(angle);

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

    private void SetVectorAngle(float angle) {

        Vector3 rotatedVector = _move;

        float angleRadiant = Mathf.Deg2Rad * angle;

        rotatedVector.x = Mathf.Cos(angleRadiant) * _move.x - Mathf.Sin(angleRadiant) * _move.y;
        rotatedVector.y = Mathf.Sin(angleRadiant) * _move.x + Mathf.Cos(angleRadiant) * _move.y;
        _move = rotatedVector;
    }

    private void SetVectorAngle(Vector2 vector) {

        Vector2 newVector = new Vector2(0, 0);

        if (vector.x == 0) {
            newVector = new Vector2(vector.y, 0);
        } else {
            newVector = new Vector2(0, -vector.x);
        }

        _move.x = newVector.x;
        _move.y = newVector.y;
    }

    public void MovePlayer() {
        _rotation.SetActive(false);
        _moveAudio.PlayOneShot(_moveSound);
        _isMoving = true;
        _canMove = 1;
        _rotationAngle = Mathf.Abs(_rotationAngle);
        _fullRotationAngle = 0;
    }

    private void CalculateAndApplyAngle() {
        foreach (var collider in colliders) {
            EnemyColliders script = collider.GetComponent<EnemyColliders>();
            if (script.GetHit()) {
                SetVectorAngle(-script._pointVector);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.transform.tag == "Wall")
        {
            CalculateAndApplyAngle();
            _isMoving = false;
            _rotation.SetActive(true);
            _canMove = 0;
        }
    }
}
