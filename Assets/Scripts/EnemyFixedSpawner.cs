using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFixedSpawner : MonoBehaviour
{
    [SerializeField] GameObject FishPrefabs;
    [SerializeField] int MaxNumberObject = 10;
    private int currentQuatity;
    private void Update()
    {
        if (gameObject.transform.childCount < MaxNumberObject)
        {
            //sinh ca
            GameObject clonedEnemy = Instantiate(
                FishPrefabs,
                this.transform.position,
                Quaternion.identity,
                gameObject.transform);
        }
    }
}
