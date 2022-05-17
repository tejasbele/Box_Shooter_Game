using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterScript : MonoBehaviour
{
    //refernce to projectile
    public GameObject projectile;
    public float power = 10.0f;

    //AudioClip refernce
    public AudioClip shootSFX;
    
    // Start is called before the first frame update
    /*void Start()
    {
        
    }*/

    // Update is called once per frame
    void Update()
    {
       //Detect if fire button is pressed
       if(Input.GetButtonDown("Fire1") || Input.GetButtonDown("Jump"))
        {
            //if projectile is specified
            if(projectile)
            {
                //instantiate the projectile at the camera +1 position & rotate with camera
                GameObject newProjectile = Instantiate(projectile, transform.position + transform.forward, transform.rotation) as GameObject;
                
                //if the projectile doesn't have the component then add one
                if(!newProjectile.GetComponent<Rigidbody>())
                {
                    newProjectile.AddComponent<Rigidbody>();
                }

                //Apply force to rigidbody component
                newProjectile.GetComponent<Rigidbody>().AddForce(transform.forward * power, ForceMode.VelocityChange);
                
                //play sound effect if set
                if(shootSFX)
                {
                    if(newProjectile.GetComponent<AudioSource>())
                    {
                        // the projectile has an AudioSource component
                        // play the sound clip through the AudioSource component on the gameobject.
                        // note: The audio will travel with the gameobject.
                        newProjectile.GetComponent<AudioSource>().PlayOneShot(shootSFX);
                    }
                    else
                    {
                        // dynamically create a new gameObject with an AudioSource
                        // this automatically destroys itself once the audio is done
                        AudioSource.PlayClipAtPoint(shootSFX, newProjectile.transform.position);
                    }
                }
            }
        }
        
               

    }
}
