using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    public GameObject applePrefab;
    public float speed = 1f;
    public float leftAndRightEdge = 10f;
    public float chanceToChangeDirection = 0.1f;
    public float secondsBetweenAppleDrops = 1f;

    private void Start()
    {
        InvokeRepeating("DropApple", 2f, secondsBetweenAppleDrops);
    }

    private void DropApple()
    {
        GameObject apple = Instantiate(applePrefab) as GameObject;
        apple.transform.position = transform.position;
    }

    private void Update() //maxComputer fps
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if (pos.x < -leftAndRightEdge)
            speed = Mathf.Abs(speed);
        else if (pos.x > leftAndRightEdge)
            speed = -Mathf.Abs(speed);
    }

    private void FixedUpdate() //50 fps
    {
        //Random.value == Random.Next(0, 1);
        if (Random.value <= chanceToChangeDirection)
            speed *= -1;
    }
}