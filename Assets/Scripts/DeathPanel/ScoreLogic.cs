using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreLogic : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] TextMeshProUGUI _currentScore;
    [SerializeField] TextMeshProUGUI _bestScore;
    [SerializeField] GameObject _newBest;

    [Space]
    [SerializeField] CollecItems _collectItem;

    [Header("Sound")]
    [SerializeField] AudioClip _newBestSound;
    [SerializeField] AudioManager _audioSource;

    // Start is called before the first frame update
    private void OnEnable() {
        int score = _collectItem._score;
        _currentScore.text = score.ToString();

        int bestScore = PlayerPrefs.GetInt("Score");
        _bestScore.text = Mathf.Max(bestScore, score).ToString();
        if (bestScore < score) {
            StartCoroutine(PlaySound());
            PlayerPrefs.SetInt("Score", score);
            _newBest.SetActive(true);
        }
    }

    private IEnumerator PlaySound() {
        yield return new WaitForSeconds(1);
        _audioSource.PlaySound(_newBestSound);
    }
}
