 using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollow : MonoBehaviour
{
    public Transform target;
    private Vector3 offset;
    void Start()
    {
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newPosition = new Vector3(offset.x + target.position.x , transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position , newPosition , 10);
    }
}
