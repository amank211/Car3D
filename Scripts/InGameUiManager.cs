using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUiManager : MonoBehaviour
{

    public CarController car;
    public Text speed;
    public Text score;
    public int Score;
    public float timecounter;
   



    // Start is called before the first frame update
    public void Start()
    {
        Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        int currdistance = (int) car.transform.position.z;
        
        timecounter += Time.deltaTime;
        Score = (int) car.transform.position.z;
        speed.text = "Speed: " + ((int) car.rigidbdy.velocity.sqrMagnitude).ToString();
        score.text = "Score: " + Score;

    }
}
