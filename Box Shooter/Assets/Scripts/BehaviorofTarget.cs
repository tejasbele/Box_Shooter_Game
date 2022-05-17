using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorofTarget : MonoBehaviour
{

    //target impact on game
    public int scoreAmount = 0;
    public float timeAmount = 0.0f;

    //explosion on hit
    public GameObject explosionPrefab;

    //when collided with another object
    //it is actually the Physics
    void OnCollisionEnter(Collision newCollision)
    {
        //exit if there is a gamemanager & gameisover
        if(GameManager.gm)
        {
            if (GameManager.gm.gameIsOver)
                return;
        }

        //only do stuff if hit by an projectile
        if(newCollision.gameObject.tag == "Projectile")
        {
            if (explosionPrefab)
            {
                //instantiate an explosion effect at the gameObject position and rotation
                Instantiate(explosionPrefab, transform.position, transform.rotation);
            }
        }

        //if game manager exists, then make the adjustments based on the target properties
        if (GameManager.gm)
            GameManager.gm.targetHit(scoreAmount, timeAmount);

        //destroy projectile
        Destroy (newCollision.gameObject);

        //destroy self
        Destroy (gameObject);
    }

    /*// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
}
