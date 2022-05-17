using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicController : MonoBehaviour
{
    //public variables
    public float moveSpeed = 3.0f;
    public float gravity = 9.81f;

    //praivate vraible
    private CharacterController myController;

    //Use this for Initialization 
    void Start()
    {
        myController = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //amount that object moves in z-direction
        Vector3 movementZ = Input.GetAxis("Vertical") * Vector3.forward * moveSpeed * Time.deltaTime;

        //amount that object moves in x-direction
        Vector3 movementX = Input.GetAxis("Horizontal") * Vector3.right * moveSpeed * Time.deltaTime;

        //local space to World space
        Vector3 movement = transform.TransformDirection(movementX + movementZ);

        //uses gravity
        movement.y -= gravity * Time.deltaTime;

        myController.Move(movement);
    }
}
