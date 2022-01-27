using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroupSpawner : MonoBehaviour
{
    public GameObject group;
    public GameObject FishPrefab;
    public int NumberGroup = 3;
    public int MinNumberOfFishInGroup;
    public int MaxNumberOfFishInGroup;
    public float groupRadius = 3f;
    private int NumberInCurrentGroup;
    void Start()
    {
        
    }

    void Update()
    {
        if (transform.childCount < NumberGroup)
        {

            GameObject grp = Instantiate(
                                group,
                                gameObject.transform.position,
                                Quaternion.identity,
                                gameObject.transform);

            NumberInCurrentGroup = Random.Range(MinNumberOfFishInGroup, MaxNumberOfFishInGroup);
            for (int i = 0; i < NumberInCurrentGroup; i++)
            {

                float ranOffSetX = Random.Range(-groupRadius, groupRadius);
                float ranOffSetY = Random.Range(-groupRadius, groupRadius);
                GameObject fish = Instantiate(
                                    FishPrefab,
                                    //Vector3.zero,
                                    new Vector3(ranOffSetX, ranOffSetY,transform.position.z),
                                    Quaternion.identity,
                                    grp.transform);
                fish.GetComponent<EnemyPathingRandom>().moveSpeed = 0;
                
            }
        }
    }
}
