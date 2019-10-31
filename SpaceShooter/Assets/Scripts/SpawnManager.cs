﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField]

    private GameObject _enemyPrefab;

    [SerializeField]

    private GameObject _enemyContainer;

    private bool _stopSpawning = false;

    // Start is called before the first frame update
    void Start()
    {
        // StartCoroutine("SpawnRoutine");   or
        // StartCouroutine(SpawnRoutine());

        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        //create an infinte while loop
        //create new enemy objects
        //wait for 3 seconds

        while (_stopSpawning == false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-8.5f, 8.5f), 7f, 0);
            GameObject newEnemy = Instantiate(_enemyPrefab, posToSpawn, Quaternion.identity);
            //to parent an object
            newEnemy.transform.SetParent(_enemyContainer.transform);


            yield return new WaitForSeconds(3f);
        }
    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }

   
}
