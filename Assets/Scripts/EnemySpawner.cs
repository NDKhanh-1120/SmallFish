using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject FishPrefabs;
    [SerializeField] int MaxNumberObject = 10;
    void Start()
    {
        //vong lap 
        StartCoroutine(SpawnEnemies());
    }
    private IEnumerator SpawnEnemies()
    {
        do
        {
            //sinh ca
            GameObject clonedEnemy = Instantiate(
                FishPrefabs,
                this.transform.position,
                Quaternion.identity,
                gameObject.transform);
            //
            yield return new WaitForSeconds(2);
        }
        while (gameObject.transform.childCount < MaxNumberObject);
    }
}
