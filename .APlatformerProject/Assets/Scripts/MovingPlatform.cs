using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private Vector3 finishPos = Vector3.zero;
    [SerializeField]
    private float speed = 0.5f;
    private Vector3 startPos;
    private float trackPercent = 0;
    private int direction = 1;
    void Start()
    {
        startPos = transform.position;
    }
    void Update()
    {
        trackPercent += direction * speed * Time.deltaTime;
        float x = (finishPos.x - startPos.x) * trackPercent +
        startPos.x;
        float y = (finishPos.y - startPos.y) * trackPercent +
        startPos.y;
        transform.position = new Vector3(x, y, startPos.z);
        if ((direction == 1 && trackPercent > .9f) ||
        (direction == -1 && trackPercent < .1f))
        {
            direction *= -1;
        }
    }
}
