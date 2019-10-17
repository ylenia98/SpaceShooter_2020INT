using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    private float _speed = 8f;
    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3();
        //move the laser upwards
        transform.Translate(Vector3.up * _speed * Time.deltaTime);

        //if the laser position Y is greater than 7, destroy the object

        if (transform.position. y > 7)
        {
            Destroy(this.gameObject);
        }
    }
}
