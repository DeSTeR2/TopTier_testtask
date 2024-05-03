using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FunctionalButtonManager : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] Button _mute;
    [SerializeField] Button _rate;
    [SerializeField] Button _share;
    [SerializeField] Button _scores;
    [SerializeField] Button _removeAds;

    [Header("Panels")]
    [SerializeField] GameObject _rateObject;
    [SerializeField] GameObject _scoreObject;

    [Header("Scripts")]
    [SerializeField] MuteScript _muteScript;
    [SerializeField] ShareScript _shareScript;
    [SerializeField] RemoveAdsScript _removeAdScript;


    // Start is called before the first frame update
    void Start()
    {
        Subscribe();    
    }

    void Subscribe() {
        _mute.onClick.AddListener(Mute);
        _rate.onClick.AddListener(Rate);
        _share.onClick.AddListener(Share);
        _scores.onClick.AddListener(Scores);
        _removeAds.onClick.AddListener(RemoveAds);
    }

    void Mute() {
        _muteScript.Mute();
    }

    void Rate() {
        _rateObject.SetActive(true);
    }
    void Share() {
        _shareScript.Share();
    }
    void Scores() {
        _scoreObject.SetActive(true);
    }

    void RemoveAds() {
        _removeAdScript.RemoveAds();
    }
}
