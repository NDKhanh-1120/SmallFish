using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform followTranform;
    [SerializeField] BoxCollider2D mapBounds;

    private float xMax, xMin, yMax, yMin;
    private float camX, camY;
    private float camOrthSize;
    private float camRatio;
    private Camera mainCam;

    private Vector3 smoothPos;
    public float smoothSpeed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        xMin = mapBounds.bounds.min.x;
        xMax = mapBounds.bounds.max.x;
        yMin = mapBounds.bounds.min.y;
        yMax = mapBounds.bounds.max.y;
        //Debug.Log(xMin + " " + xMax + " " + yMin + " " + yMax);

        mainCam = GetComponent<Camera>();
        camOrthSize = mainCam.orthographicSize;
        camRatio = (xMax + camOrthSize) / 2.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        camX = Mathf.Clamp(followTranform.position.x, xMin + camOrthSize, xMax - camOrthSize);
        camY = Mathf.Clamp(followTranform.position.y, yMin + camOrthSize, yMax - camOrthSize);
        smoothPos = Vector3.Lerp(
                                this.transform.position,
                                new Vector3(camX, camY, this.transform.position.z   ),
                                smoothSpeed
                                );
        this.transform.position = smoothPos;
    }
}
