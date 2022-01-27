using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public List<GameObject> Items;
    public float TimeBetweenThrowns = 10f;
    private int selectItem;

    void Start()
    {
        StartCoroutine(ExecuteAfterTime(TimeBetweenThrowns, () => { ThrownItem(); }));
    }

    private void ThrownItem()
    {
        
        selectItem = UnityEngine.Random.Range(0, Items.Count);
        GameObject item = Instantiate(
                            Items[selectItem],
                            new Vector3(UnityEngine.Random.Range(-30, 30), 30, this.transform.position.z),
                            Quaternion.identity,
                            gameObject.transform
                            );
        item.GetComponent<Rigidbody2D>().velocity = Vector2.down * 5;
    }

    private bool isCoroutineExecuting = false;
    IEnumerator ExecuteAfterTime(float time, Action task)
    {
        while (true)
        {
        if (isCoroutineExecuting)
            yield break;
        isCoroutineExecuting = true;
        yield return new WaitForSeconds(time);
        task();
        isCoroutineExecuting = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
