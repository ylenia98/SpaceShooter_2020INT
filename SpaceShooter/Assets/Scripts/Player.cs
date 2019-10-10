using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// MonoBehaviour is a Unity class that allows us to attach scripts to GameObjects.
// The colon symbol means that the player inherits MonoBehavior's code.

public class Player : MonoBehaviour
{
    /* Variable is a box with information that can be changed.
     Step 1 : identify if the variable is going to be public or private.
     private variable can only be seen by the class itself
     Step 2: data type (int (whole numbers), 
                        float(numbers number with a point 5.6), 
                        bool(true of false), 
                        string(text))
    every variable needs a name
    Step 4: optional value               
*/

    [SerializeField]

    //attribute - exposes the variable inside Unity
    private float _speed = 3.5f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }
    

    // Update is called once per frame
    void Update()
    {
        /*
        // Vector3.right = new Vector3(1, 0, 0)
        // read the keyboars input from the user
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * horizontalInput * _speed * Time.deltaTime);
        transform.Translate(Vector3.up * verticalInput * _speed * Time.deltaTime);

*/
    
    // more optimized version for the above
        Vector3 direction = new Vector3(
            Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical"),
            0

        );

         transform.Translate(direction * _speed * Time.deltaTime);

         // if the player position on the Y axis is > 0 
         // y position = 0
         // else if the y poisition < -4.5
         // y position = -4.5
         if(transform.position.y > 0)
         {
             transform.position = new Vector3(transform.position.x, 0, 0);
            
         }
         else if(transform.position.y < -4.5)
         {
             transform.position = new Vector3(transform.position.x, -4.5f, 0);

         }

         // if X position is > 11.5
         // X position = -11.5
         // else if X position < -11.5
         // X position = 11.5
         

    }
}