using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    Vector3 currentEulerAngle;
    float rotationspeed = 45;
    Quaternion currentrotaion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        currentEulerAngle += new Vector3(0, 1, 0) * rotationspeed * Time.deltaTime;
        currentrotaion.eulerAngles = currentEulerAngle;

        transform.rotation = currentrotaion;

        
    }
}
