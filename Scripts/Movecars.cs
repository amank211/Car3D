using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movecars : MonoBehaviour
{
    // Start is called before the first frame update
    public int speed;
    public float lifetime;
    float counter;

    // Update is called once per frame
    void FixedUpdate()
    {

        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        counter += Time.deltaTime;
        if (counter > lifetime) {
            Destroy(gameObject);
        }
    }
}
