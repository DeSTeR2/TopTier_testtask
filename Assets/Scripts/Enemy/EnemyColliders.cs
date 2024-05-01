using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColliders : MonoBehaviour
{
    public float _distance;
    public Vector2 _pointVector;

    public bool GetHit() {
        RaycastHit2D hit;
        hit = Physics2D.Raycast(transform.position, _pointVector, _distance,LayerMask.GetMask("UI"));
        return (hit.collider != null);
    }
}
