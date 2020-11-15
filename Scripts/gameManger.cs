using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManger : MonoBehaviour
{

    string started = "FirstStart";
    bool hasstarted;
    public static Player player;

    public void Start()
    {

        if (Firsttime())
        {
            PlayerPrefs.SetInt(started, 1);

            bool[] unlocked = new bool[5];
            for (int i = 0; i < unlocked.Length; i++) {
                unlocked[i] = false;
            }
            unlocked[0] = true;

            player = new Player(100, unlocked, 0);

            SaveSystem.SavePlayer(player);
        }
        else {
            PlayerData data = SaveSystem.LoadPlayer();
            player = new Player();
            player.cash = data.cash;
            player.unlocked = data.unlocked;
            player.highscore = data.highscore;

        }
        Debug.Log(player.cash);
        
    }


    public bool Firsttime() {
        return PlayerPrefs.GetInt(started) == 1 ? false : true;
    }




}
