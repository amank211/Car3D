using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDetails : MonoBehaviour
{
    public string name;
    public int speed;
    public int braking;
    public int price;
    public bool Unlocked;

    CarDetails(string name, int speed, int braking, int price) {
        this.name = name;
        this.speed = speed;
        this.braking = braking;
        this.price = price;
    }
    void Unlock() {
        Unlocked = true;
    }
}
