using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroupPathingRandom : MonoBehaviour
{
    
    public float moveSpeed = 2f;
    public float mass = 0.5f;
    [SerializeField] BoxCollider2D mapBounds;

    private float xMax, xMin, yMax, yMin;

    void Start()
    {
        //xMin = mapBounds.bounds.min.x ;
        //xMax = mapBounds.bounds.max.x ;
        //yMin = mapBounds.bounds.min.y ;
        //yMax = mapBounds.bounds.max.y ;
        xMin = -30f;
        xMax = 30f;
        yMin = -10f;
        yMax = 10f;
        // xac dinh vi tri dich vi tri dich
        targetPosition = new Vector3( Random.Range(xMin, xMax),
                                        Random.Range(yMin, yMax),
                                        this.transform.position.z
                                        );
    }

    void Update()
    {

        if (moveSpeed == 0) return;
        var distance = moveSpeed * Time.deltaTime;
        Move(distance);
    }
    private Vector3 targetPosition;
    void Move(float distance)
    {
        // chuyen huong
        if ((transform.position - targetPosition).x > 0)
            foreach(Transform child in gameObject.transform)
                child.transform.eulerAngles = new Vector2(0, 180);
        else
            foreach (Transform child in gameObject.transform)
                child.transform.eulerAngles = new Vector2(0, 0);
        // di chuyen
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, distance);
        //    
        if(transform.position == targetPosition)
        {
            targetPosition = new Vector3(
                                Random.Range(xMin, xMax),
                                Random.Range(yMin, yMax),
                                this.transform.position.z
                                );
        }
    }
}
