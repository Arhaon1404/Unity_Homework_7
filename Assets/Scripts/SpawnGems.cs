using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGems : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoints;
    [SerializeField] private Gem _spawnableObject;

    private Gem _spawnedObject;
    private Coroutine _spawnEnemyCoroutine;
    private float _spawnSecondsPeriod = 2f;
    private bool _isDone = true;

    public void SpawnGemToEmptyDot(Transform _spawnPointChild)
    {
        Debug.Log("Done");
        RunCoroutine(_spawnPointChild);
    }

    private void Start()
    {
        for (int i = 0; i < _spawnPoints.childCount; i++)
        {
            _spawnedObject = Instantiate(_spawnableObject, _spawnPoints.GetChild(i).transform.position, Quaternion.identity);

            _spawnedObject.transform.SetParent(_spawnPoints.GetChild(i));
        }
    }

    private IEnumerator SpawnObject(Transform _spawnPointChild)
    {
        yield return new WaitForSeconds(_spawnSecondsPeriod);

        Instantiate(_spawnableObject, _spawnPointChild.transform.position, Quaternion.identity);

        _isDone = true;
    }

    private void RunCoroutine(Transform _spawnPointChild)
    {
        if (_spawnEnemyCoroutine != null & _isDone == true)
        {
            StopCoroutine(_spawnEnemyCoroutine);
        }

        if (_isDone == true)
        {
            _isDone = false;
            _spawnEnemyCoroutine = StartCoroutine(SpawnObject(_spawnPointChild));
        }
    }
}
