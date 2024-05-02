using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollecItems : MonoBehaviour
{
    [SerializeField] SpawnItems _spawnItems;
    [SerializeField] TextMeshProUGUI _scoreText;
    
    private float _score;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Item") {
            _score++;
            _scoreText.text = _score.ToString();
            _spawnItems.Respawn();
            collision.gameObject.transform.GetComponentInParent<ItemAnimation>().Delete();
        }
    }

}
