using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMover : MonoBehaviour
{
    public enum motionDirections {Spin, Horizontal, Vertical};
    public motionDirections motionState = motionDirections.Horizontal;
    public float spinSpeed = 180.0f;
    public float motionMagnitude = 0.1f;
    //public bool doSpin = true;
    //public bool doMotion = false;

    // Update is called once per frame
    void Update()
    {
        switch (motionState)
        {
            case motionDirections.Spin:
                //rotate around the up (y-axis) axis of the gameObject
                gameObject.transform.Rotate(Vector3.up * spinSpeed * Time.deltaTime);
                break;

            case motionDirections.Horizontal:
                //it allows the gameObject to move right-left
                gameObject.transform.Translate(Vector3.right * Mathf.Cos(Time.timeSinceLevelLoad) * motionMagnitude);
                break;

            case motionDirections.Vertical:
                //it allows the gameObject to move up-down
                gameObject.transform.Translate(Vector3.up * Mathf.Cos(Time.timeSinceLevelLoad) * motionMagnitude);
                break;
        }
    }
}
