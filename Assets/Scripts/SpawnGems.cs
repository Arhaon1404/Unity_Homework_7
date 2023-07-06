using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGems : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoints;
    [SerializeField] private Gem _spawnableObject;

    private Gem _spawnedObject;

    private void Start()
    {
        for (int i = 0; i < _spawnPoints.childCount; i++)
        {
            _spawnedObject = Instantiate(_spawnableObject, _spawnPoints.GetChild(i).transform.position, Quaternion.identity);

            _spawnedObject.transform.SetParent(_spawnPoints.GetChild(i));
        }
    }
}
