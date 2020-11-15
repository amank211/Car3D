using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGenerator : MonoBehaviour
{

    public Transform spawnpoint;
    public GameObject car;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "road") {
            
            other.transform.position = spawnpoint.position;
            spawnpoint.position += new Vector3(0, 0, 40);
        }
        if (other.tag == "movingcars")
        {
            Destroy(other.gameObject);
        }
    }
    private void FixedUpdate()
    {
        Vector3 position = transform.position;
        position.z = car.transform.position.z - 150;
        transform.position = position;
    }
}
