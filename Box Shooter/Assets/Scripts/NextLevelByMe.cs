using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelByMe : MonoBehaviour
{
    //responds on collision
    void OnCollisionEnter (Collision newCollision)
    {
        //do only if hit by projectile
        if(newCollision.gameObject.tag == "Projectile")
        {
            //calling NextLevel function in GameManager
            GameManager.gm.NextLevel();
        }
    }
}
