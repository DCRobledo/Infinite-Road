using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Vector2 offset;
    public Transform obj;

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(transform.position.x, offset.y + obj.position.y, -10);
    }
}
