using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenrator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] obstacles;

    void Start()
    {
        spawn();
    }

    void spawn() {
        int random = Random.Range(0, obstacles.Length);
        GameObject obst =  Instantiate(obstacles[random], transform.position, transform.rotation);
        obst.transform.parent = transform;
    }
}
