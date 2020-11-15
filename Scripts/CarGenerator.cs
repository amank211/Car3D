using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarGenerator : MonoBehaviour
{
    public Transform carTransform;
    public GameObject[] cars;
    public float startoffset, repeattime;
    int[] lane = new int[2];

    // Start is called before the first frame update
    void Start()
    {
        lane[0] = 1;
        lane[1] = -1;
        InvokeRepeating("Spawn", startoffset, repeattime);
    }

    void Spawn() {
        int random = Random.Range(0, cars.Length);
        int randomdistance = Random.Range(20, 50);
        int randomlane = Random.Range(0, 2);
        Vector3 position = carTransform.transform.position + new Vector3(0, 0, randomdistance);
        position.y = 0;
        position.x = lane[randomlane];
        Instantiate(cars[random], position, new Quaternion(0, 0, 0, 0));
    }
    
}
