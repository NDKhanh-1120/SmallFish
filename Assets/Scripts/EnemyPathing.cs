using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    WaveConfig waveConfig;
    public void SetWaveConfig(WaveConfig wayconfig) { waveConfig = wayconfig; }
    List<Transform> wayPoints;
    int waypointIndex = 0;
    void Start()
    {
        wayPoints = waveConfig.GetWaveWayPoints();
        transform.position = wayPoints[0].transform.position;
    }

    void Update()
    {
        var speed = waveConfig.GetMoveSpeed() * Time.deltaTime;
        Move(speed);
    }
    void Move(float speed) { 
        if (waypointIndex <= wayPoints.Count - 1)
        {
            var targetPosition = wayPoints[waypointIndex].transform.position;
            // chuyen huong
            if((transform.position - targetPosition).x > 0) this.GetComponent<SpriteRenderer>().flipX = true;
            else this.GetComponent<SpriteRenderer>().flipX = false;
            // di chuyen
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed);
            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else Destroy(gameObject);
    

    }
}
