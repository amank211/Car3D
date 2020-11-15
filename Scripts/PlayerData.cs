using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int cash;
    public bool[] unlocked;
    public int highscore;
    public PlayerData(Player player) {
        cash = player.cash;
        highscore = player.highscore;
        unlocked = new bool[player.unlocked.Length];
        for (int i = 0; i < unlocked.Length; i++) {
            unlocked[i] = player.unlocked[i];
        }
        
    }
    public PlayerData() {
        cash = 0;
        highscore = 0;
    }
}
