using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGems : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoints;
    [SerializeField] private Gem _spawnableObject;

    private Coroutine _spawnEnemyCoroutine;
    private float _spawnSecondsPeriod = 2f;
    private bool _isDone = true;

    private void Start()
    {
        for (int i = 0; i < _spawnPoints.childCount; i++)
        {
            Instantiate(_spawnableObject, _spawnPoints.GetChild(i).transform.position, Quaternion.identity);
        }
    }

    private void SpawnGemToEmptyDot(Transform _spawnPointChild)
    {
        RunCoroutine();

        Instantiate(_spawnableObject, _spawnPointChild.transform.position, Quaternion.identity);
    }

    private IEnumerator SpawnObject()
    {
        yield return new WaitForSeconds(_spawnSecondsPeriod);

        _isDone = true;
    }

    private void RunCoroutine()
    {
        if (_spawnEnemyCoroutine != null & _isDone == true)
        {
            StopCoroutine(_spawnEnemyCoroutine);
        }

        if (_isDone == true)
        {
            _isDone = false;
            _spawnEnemyCoroutine = StartCoroutine(SpawnObject());
        }
    }
}
