using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMovement : MonoBehaviour
{
    public float speed, endPosZ, startPosZ;
    public bool isBleacher;
    public Vector3 axis;

    [SerializeField]
    private float currZ;

    private void Start()
    {
        currZ = transform.localPosition.z;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(axis * -speed * Time.deltaTime);
        if (!isBleacher)
        {
            if (transform.position.z < endPosZ)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, startPosZ);
            }
        } else
        {
            if(transform.localPosition.x > endPosZ)
            {
                transform.localPosition = new Vector3(startPosZ, transform.localPosition.y, currZ);
            }
        }
    }
}
