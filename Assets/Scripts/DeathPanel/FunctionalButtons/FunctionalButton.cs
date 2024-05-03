using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FunctionalButton : MonoBehaviour {
    [Header("Sprites")]
    [SerializeField] Image _iconObject;
    [SerializeField] Sprite _iconToSet;

    [Header("Text")]
    [SerializeField] TextMeshProUGUI _text;
    [SerializeField] string _buttonName;

    // Start is called before the first frame update
    void Start()
    {
        _text.text = _buttonName;
        ChangeSprite(_iconToSet);
    }


    public void ChangeSprite(Sprite _sprite) {
        _iconObject.sprite = _sprite;
    }
}
