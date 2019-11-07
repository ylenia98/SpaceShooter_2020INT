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
    [Header("Player Options")]

    [SerializeField]

    //attribute - exposes the variable inside Unity
    private float _speed = 3.5f;

   

    [SerializeField]

    private float _fireRate = 0.5f;
    private float _nextFire = -1.0f;

    [SerializeField]
    private int _lives = 3;

    private SpawnManager _spawnManager;

    
    [Header("Laser")]
    [SerializeField]

    private GameObject _laserPrefab;

    [Header("Triple Shot")]
    [SerializeField]

    private GameObject _tripleShotPrefab;

    [SerializeField]

    private bool _isTripleShotActive = false;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);

        _spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        if(_spawnManager == null)
        {
            Debug.LogError("The Spawn Manager Script could not be found !");
        }
    }
    
    void Update()
    {
        CalculateMovement();
        

        //if i hit the space key I want to spawn the laser
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _nextFire) // if i hit the space key and the game time is greater than nextFire, reset next fire = current time + fire rate
        {
            FireLaser();
        }
    }

    // Update is called once per frame
    void CalculateMovement()
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
         if(transform.position.x > 11.5f)
        {
            transform.position = new Vector3(-11.5f, transform.position.y, 0);
        }
         else if(transform.position.x < -11.5f)
        {
            transform.position = new Vector3(11.5f, transform.position.y, 0);
        }
         

    }

    void FireLaser()
    {
        _nextFire = Time.time + _fireRate;

        //check if isTripleShot is active
        // instantiate the triple shot prefab
        // else fire 1 laser

        if (_isTripleShotActive == true)
        {
            Instantiate(_tripleShotPrefab, transform.position, Quaternion.identity);
        }
        else
        {

            //Calculate 0.8 units vertically from the player
            Vector3 laserPos = transform.position + new Vector3(0, 0.8f, 0);

            // first write this code to know if it is working, then remove it Debug.Log("The space key was pressed");
            //Quaternion identity =  default rotation (0, 0, 0).
            Instantiate(_laserPrefab, laserPos, Quaternion.identity);
        }
    }


    public void Damage()
    {
        // reduce the player's lives by 1

        //different type of how to write -1 from lives
       // _lives = _lives - 1;
        _lives -= 1;
       // _lives--;

        //check if dead
        //destory us

        if(_lives < 1)
        {
            // Communicate with the SpawnManager and tell it to stop spawning

            _spawnManager.OnPlayerDeath();

            Destroy(this.gameObject);
        }
    }

    public void ActivateTripleShot()
    {
        _isTripleShotActive = true;
        StartCoroutine(TripleShotPowerDownRoutine());
    }

    IEnumerator TripleShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(5f);
        _isTripleShotActive = false;

    }
}