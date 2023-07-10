using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    Quaternion originRotation;
    float angle;
    //int counter = 1;
    //int counter2 = 0;

    // Start is called before the first frame update
    void Start()
    {
        originRotation = transform.rotation;
    }

    /*
    // Update is called once per frame
    void FixedUpdate()
    {        
        angle++;
        

        if (counter==1) {
            Quaternion rotationY = Quaternion.AngleAxis(angle, Vector3.up);
            // Quaternion rotationZ = Quaternion.AngleAxis(angle, Vector3.forward);
            // Quaternion rotationX = Quaternion.AngleAxis(angle, Vector3.right);

            transform.rotation *= rotationY;
            //counter = 0;
            //counter2 = 1;
        }
        else if (counter2==1) {
            Quaternion rotationY = Quaternion.AngleAxis(angle, Vector3.up);
            Quaternion rotationZ = Quaternion.AngleAxis(angle, Vector3.forward);
            // Quaternion rotationX = Quaternion.AngleAxis(angle, Vector3.right);

            transform.rotation *= rotationZ * rotationY;
            counter = 1;
            counter2 = 0;
        }
    }
    */


    void FixedUpdate()
    {
        angle++;

        Quaternion rotationY = Quaternion.AngleAxis(angle, Vector3.up);
        // Quaternion rotationZ = Quaternion.AngleAxis(angle, Vector3.forward);
        // Quaternion rotationX = Quaternion.AngleAxis(angle, Vector3.right);

        transform.rotation *= rotationY;
    }
}
