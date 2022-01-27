using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleEnemySpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> FishPrefabs;
    [SerializeField] int MaxNumberObject = 10;
    void Start()
    {
        //vong lap 
        StartCoroutine(
            SpawnAllEnemiesInWave()
            );
    }
    private int selectedIndex;
    private IEnumerator SpawnAllEnemiesInWave()
    {
        do
        {
            //
            selectedIndex =  Random.Range(0, FishPrefabs.Count );
            //sinh ca
            GameObject clonedEnemy = Instantiate(
                FishPrefabs[selectedIndex],
                this.transform.position,
                Quaternion.identity,
                gameObject.transform);
            //
            yield return new WaitForSeconds(0.1f);
        }
        while (gameObject.transform.childCount < MaxNumberObject);
    }
}
