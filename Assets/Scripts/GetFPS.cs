using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class GetFPS : MonoBehaviour
{
    TextMeshProUGUI _fpsText;
    float _fps;
    // Start is called before the first frame update
    void Start()
    {
        _fpsText = GetComponent<TextMeshProUGUI>();
        InvokeRepeating("GetFps", 1, 1);
    }

    void GetFps() {
        _fps = (int)(1f / Time.unscaledDeltaTime);
        _fpsText.text = "FPS: " + _fps.ToString();
    }
}
