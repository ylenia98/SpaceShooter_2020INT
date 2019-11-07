using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
     // Update is called once per frame
     [SerializeField]

    private float _speed = 3f;

    void Update()
    {
        // move down at 3m/s 
        
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        // when we leave the screen, destroy us
        if (transform.position.y <-8f)
        {
            Destroy(this.gameObject);
        }

    }

    // on trigger enter
    void OnTriggerEnter2D(Collider2D other)
    {
        // if i hit the player
        if (other.tag == "Player")
        {
            //tell the player to active the TripleShot
            Player player = other.GetComponent<Player>();

            if(player!= null)
            {
                player.ActivateTripleShot();
            }

            

       

            // destroy us
            Destroy(this.gameObject);
        }
    }

   
}
