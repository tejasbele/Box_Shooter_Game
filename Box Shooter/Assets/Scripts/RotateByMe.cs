using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateByMe : MonoBehaviour
{
    public float speed = 10.0f;

    //set up the possible directions of rotation
    public enum whichWayToRotate { AroundX, AroundY, AroundZ };

    public whichWayToRotate way = whichWayToRotate.AroundX;

    // Update is called once per frame
    void Update()
    {
        switch(way)
        {
            case whichWayToRotate.AroundX:
                transform.Rotate(Vector3.right * speed * Time.deltaTime);
                break;

            case whichWayToRotate.AroundY:
                transform.Rotate(Vector3.up * speed * Time.deltaTime);
                break;

            case whichWayToRotate.AroundZ:
                transform.Rotate( Vector3.forward * speed * Time.deltaTime);
                break;
        }
    }
}
