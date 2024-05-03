using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteScript : MonoBehaviour {

    [SerializeField] Sprite _imageMute;
    [SerializeField] Sprite _imageNoMute;
    [Space]
    [SerializeField] List<AudioSource> audioSources;
    [Space]
    [SerializeField] FunctionalButton _functionalButton;

    bool mute = false;
    // Start is called before the first frame update

    public void Mute() {
        if (mute) _functionalButton.ChangeSprite(_imageMute);
        else _functionalButton.ChangeSprite(_imageNoMute);
        foreach (AudioSource audioSorce in audioSources) {
            if (mute) audioSorce.volume = 0;
            else audioSorce.volume = 1;
        }
        mute = !mute;
    }
}
