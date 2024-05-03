using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RateItem : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _position;
    [SerializeField] TextMeshProUGUI _name;
    [SerializeField] TextMeshProUGUI _score;
    
    public void Init(int position, string name, int score) {
        _position.text = position.ToString();
        _name.text = name;
        _score.text = score.ToString();

        _name.color = Color.black;
        if (name == "YOU") {
            UnderlineText(_position);
            UnderlineText(_name);
            UnderlineText(_score);
        }
    }

    private void UnderlineText(TextMeshProUGUI text) {
        text.text = "<u>" + text.text + "</u>";
    }
}
