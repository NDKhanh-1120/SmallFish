using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config ")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject enemyPrefabs; // doi tuong ca
    [SerializeField]  GameObject pathPrefabs; // duong di chuyen
    [SerializeField]  float timeBetweenSpawns = 0.5f; // thoi gian cach nhau moi lan sinh
    //[SerializeField]  float spawnRandowFactor = 0.3f;
    [SerializeField] int numberOfEnemies = 6;
    [SerializeField]  float moveSpeed = 2f;

    public GameObject GetEmenyPrefab() { return enemyPrefabs; }
    public List<Transform> GetWaveWayPoints() {
        var waveWayPoints = new List<Transform>();
        foreach(Transform child in pathPrefabs.transform)
        {
            waveWayPoints.Add(child);
        }
        return waveWayPoints; 
    }
    public float GetRandomTimeBetweenSpawns() { return Random.Range(0, timeBetweenSpawns); }
    //public float GetSpwanRandowFator() { return spawnRandowFactor; }
    public int GetNumberofEnemies() { return numberOfEnemies; }
    public float GetMoveSpeed() { return moveSpeed; }

}
