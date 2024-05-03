using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollecItems : MonoBehaviour
{
    [SerializeField] SpawnItems _spawnItems;
    [SerializeField] TextMeshProUGUI _scoreText;

    [Space]
    [SerializeField] ChangeBGColor _changeBGColor;

    [Space]
    public int _score = 0;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Item") {
            _score++;
            if (_score % 5 == 0) _changeBGColor.ChangeColor();
            _scoreText.text = _score.ToString();
            _spawnItems.Respawn();
            collision.gameObject.transform.GetComponentInParent<ItemAnimation>().Delete();
        }
    }

    public void SetScoreZero() {
        _score = 0;
        _scoreText.text = _score.ToString();
        _changeBGColor.ChangeColor();
    }

}
