using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Move : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private Vector3 _move;
    [SerializeField] private float _speed;
    [SerializeField] private Arrow _arrow;
    [SerializeField] private float _rotationAngle;
    [SerializeField] private int _angle;
    [SerializeField] private GameObject[] colliders;

    [Space]
    [SerializeField] private GameObject _rotation;

    [Header("Sound")]
    [SerializeField] private AudioClip _moveSound;
    [SerializeField] private AudioManager _audioManager;

    [Space]
    [SerializeField] float _scaler;

    private bool _isMoving = false;
    private bool _isDead = false;
    
    private int _canMove = 0;
    private Rigidbody2D _rb;
    private float _fullRotationAngle = 0;

    private float _angleToUse = 360;
    // Start is called before the first frame update
    void Start() {
        _rb = GetComponent<Rigidbody2D>();
        _rb.gravityScale = 0;

        ReSize();
    }

    private void ReSize() {
        var width = Camera.main.orthographicSize * 2.0 * Screen.width / Screen.height;
        transform.localScale = new Vector3((float)width / _scaler, (float)width / _scaler, (float)width / _scaler);
    }

    private void OnEnable() {
        transform.position = Vector3.zero;
        _isDead = false;
        _isMoving = false;
        _angleToUse = 360;
        GetComponent<CollecItems>().SetScoreZero();
        _rotation.SetActive(true);
    }

    // Update is called once per frame
    void Update() 
    {
        if (_isDead) return;
        if (!_isMoving) {
            ChangeMoveVector(_rotationAngle);
            _arrow.ChangePosition(_move + transform.position);
        } else {
            transform.position += (_move * _speed * Time.deltaTime)*_canMove;
            _angleToUse = _angle;
        }
        
    }

    private void ChangeMoveVector(float angle) {
        SetVectorAngle(angle);

        _fullRotationAngle += angle;
        if (_fullRotationAngle >= _angleToUse) {
            _rotationAngle *= -1;
            _fullRotationAngle = 0;
        }
        else if (_fullRotationAngle <= -_angleToUse) {
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

    private void MovePlayer() {
        _rotation.SetActive(false);
        if (!_isDead) _audioManager.PlaySound(_moveSound);
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

    public void Dead() {
        _isDead = true;
        _rotation.SetActive(false);
    }
}
