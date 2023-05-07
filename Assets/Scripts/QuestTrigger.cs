using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTrigger : MonoBehaviour
{
    [SerializeField] private QuestManager _questManager;
    [SerializeField] private GameObject _buttonNotifGO;
    private bool _isInside;
    private Action _onPress; 

    private void Awake()
    {
        _onPress = null;
        _isInside = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            _onPress?.Invoke();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        _isInside = true;
        _buttonNotifGO.SetActive(true);
        _onPress += ExecuteQuest;
    }

    /*private void OnTriggerStay(Collider other)
    {
        if (!_isInside)
        {
            _isInside = true;
            _buttonNotifGO.SetActive(true);
            _onPress += ExecuteQuest;
        }
    }*/

    private void OnTriggerExit(Collider other)
    {
        _buttonNotifGO.SetActive(false);
        _isInside = false;
        _onPress = null;
    }

    private void ExecuteQuest()
    {
        _questManager.StartExecute();
    }
    
    
}
