using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathingRandom : MonoBehaviour
{
    
    public float moveSpeed = 2f;
    public float mass = 0.5f;
    //[SerializeField] BoxCollider2D mapBounds;
    public float radius = 30f; 
    void Start()
    {
        //xMin = mapBounds.bounds.min.x ;
        //xMax = mapBounds.bounds.max.x ;
        //yMin = mapBounds.bounds.min.y ;
        //yMax = mapBounds.bounds.max.y ;

        // xac dinh vi tri dich vi tri dich
        targetPosition = new Vector3( Random.Range(-radius, radius),
                                        Random.Range(-radius, radius),
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
            transform.eulerAngles = new Vector2(0, 180);
        else
            transform.eulerAngles = new Vector2(0, 0);
        // di chuyen
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, distance);
        //    
        if(transform.position == targetPosition)
        {
            targetPosition = new Vector3(
                                Random.Range(-radius, radius),
                                Random.Range(-radius, radius),
                                this.transform.position.z
                                );
        }
    }
}
