using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckGem : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoints;
    [SerializeField] private UnityEvent _isDotEmpty;

    public void CheckEmptyDot()
    {
        for (int i = 0; i < _spawnPoints.childCount; i++)
        {
            if (_spawnPoints.GetChild(i) == null)
            {
                _isDotEmpty.Invoke();
            }
        }
    }
}
