using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathingRandomAndKeepOff : MonoBehaviour
{
    [SerializeField] GameObject KeepOffObject;
    [SerializeField] float originSpeed = 3f;
    private float moveSpeed;
    public float mass = 0.5f;
    //[SerializeField] BoxCollider2D mapBounds;
    public float moveRadius = 30f;
    private float xMax, xMin, yMax, yMin;
    private Vector2 nearDistance; 

    void Start()
    {
        moveSpeed = originSpeed;
        nearDistance = new Vector2(3f, 3f);
        //xMin = mapBounds.bounds.min.x ;
        //xMax = mapBounds.bounds.max.x ;
        //yMin = mapBounds.bounds.min.y ;
        //yMax = mapBounds.bounds.max.y ;
        xMin = -moveRadius;
        xMax = moveRadius;
        yMin = -moveRadius;
        yMax = moveRadius;
        // xac dinh vi tri dich vi tri dich
        targetPosition = new Vector3( UnityEngine.Random.Range(xMin, xMax),
                                       UnityEngine.Random.Range(yMin, yMax),
                                        this.transform.position.z
                                        );
    }

    void Update()
    {
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

        if( Vector2.Distance(transform.position ,KeepOffObject.transform.position) < nearDistance.magnitude
            && this.mass < KeepOffObject.GetComponent<Player>().mass)
        {
            targetPosition = 2 * transform.position - KeepOffObject.transform.position;
            SpeedUpIn(3f);

        }
        else     
        if(transform.position == targetPosition)
        {
            targetPosition = new Vector3(
                                UnityEngine.Random.Range(xMin, xMax),
                                UnityEngine.Random.Range(yMin, yMax),
                                this.transform.position.z
                                );
        }
    }
    private void SpeedUpIn(float time)
    {
        moveSpeed *= 3;
        StartCoroutine(ExecuteAfterTime(time, () => { BackToOriginSpeed(); }));
    }
    private void BackToOriginSpeed()
    {
        moveSpeed = originSpeed;
    }
    private bool isCoroutineExecuting = false;
    IEnumerator ExecuteAfterTime(float time, Action task)
    {
        if (isCoroutineExecuting)
            yield break;
        isCoroutineExecuting = true;
        yield return new WaitForSeconds(time);
        task();
        isCoroutineExecuting = false;
    }
}
