using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonSelect : MonoBehaviour {
    [SerializeField] Button _button;
    [SerializeField] Move _playerMove;
    [SerializeField] EventTrigger _trigger;
}
