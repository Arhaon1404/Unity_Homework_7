using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckGem : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoints;
    [SerializeField] private UnityEvent _isDotEmpty;

    private string _stringGem = "Gem";

    private void CheckEmptyDot()
    {
        for (int i = 0; i < _spawnPoints.childCount; i++)
        {
            if (_spawnPoints.GetChild(i).Find(_stringGem) == null)
            {
                _isDotEmpty.Invoke();
            }
        }
    }
}
