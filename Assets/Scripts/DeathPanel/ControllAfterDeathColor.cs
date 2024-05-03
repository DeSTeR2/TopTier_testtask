using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllAfterDeathColor : MonoBehaviour
{
    [SerializeField] Image _gameBackground;
    [SerializeField] Image _panelImage;

    // Start is called before the first frame update
    private void OnEnable() {
        _panelImage.color = _gameBackground.color;
    }
}
