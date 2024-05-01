using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeBGColor : MonoBehaviour
{
    [SerializeField] Image _image;

    private void Start() {
        ChangeColor();
    }

    public void ChangeColor() {
        _image.color = Random.ColorHSV(0,1,0.4f,1f,0.5f,1f);
    }
}
