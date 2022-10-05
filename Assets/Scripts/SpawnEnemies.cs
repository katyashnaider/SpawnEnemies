using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Enemy _enemy;

    private const float StepSecondSpawn = 2f;
    private Coroutine _coroutine;

    private void Start()
    {
        _coroutine = StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        var waitForSeconds = new WaitForSeconds(StepSecondSpawn);

        foreach(var spawnPoint in _spawnPoints)
        {
            Instantiate(_enemy, spawnPoint.transform.position, Quaternion.identity);

            yield return waitForSeconds;
        }

        StopCoroutine(_coroutine);
    }
}
