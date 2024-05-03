using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;

[Serializable]
public struct RatingInfo{
    public string name {  get; set; }
    public int score {  get; set; }

    public RatingInfo(string name, int score) {
        this.name = name;
        this.score = score;
    }
}

public class RatingManager : MonoBehaviour
{
    [SerializeField] GameObject[] _ratingItems;
    [SerializeField] CollecItems _playerCollect;
    [Space]
    [SerializeField] string[] _names;
    
    private List<RatingInfo> _ratingInfo = new List<RatingInfo>();

    private void Awake() {
        int childNumber = transform.childCount;
        for (int i=0; i < _names.Length; i++) {
            int randomScore = UnityEngine.Random.Range(2,15);
            RatingInfo info = new RatingInfo(_names[i],randomScore);
            _ratingInfo.Add(info);
        }
    }

    private void OnEnable() {
        RatingInfo you = _ratingInfo[_ratingInfo.Count - 1];
        you.score = PlayerPrefs.GetInt("Score");
        _ratingInfo[_ratingInfo.Count - 1] = you;

        IEnumerable<RatingInfo> sortedRatingInfo = _ratingInfo.OrderByDescending(rate => rate.score);
        int position = 0;
        foreach (RatingInfo item in sortedRatingInfo) {
            _ratingItems[position].GetComponent<RateItem>().Init(position + 1, item.name, item.score);
            position++;
        }
    }
}
