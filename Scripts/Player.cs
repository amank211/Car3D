using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int cash;
    public bool[] unlocked;
    public int highscore;
    public Player() {
        this.cash = 0;
        highscore = 0;
    }
    public Player(int cash, bool[] unlocked, int highscore) {
        this.cash = cash;
        this.unlocked = unlocked;
        this.highscore = highscore;
    }
}
