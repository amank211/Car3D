using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Damage : MonoBehaviour
{

    public int damage;
    public GameObject horn;
    AudioSource honking;
    public GameObject gameoverUI;

    public Text score;
    public Text money;
    public Text highscore;

    public PlayerData playerdata = new PlayerData();
    public Player player;
    public int moneyearn;

    public InGameUiManager inGameUiManager;


    // Start is called before the first frame update
    void Start()
    {
        
        damage = 0;
        horn = getchild(gameObject, "Roll");
        honking = horn.GetComponent<AudioSource>();

        playerdata = SaveSystem.LoadPlayer();
        player = new Player(playerdata.cash, playerdata.unlocked, playerdata.highscore);

    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "movingcars" || other.gameObject.tag == "obstacles") {
            damage++;
            honking.Play();
        }
        if (damage >= 1) {
            Time.timeScale = 0;
            

            gameoverUI.SetActive(true);

            if (inGameUiManager.Score >= player.highscore) {
                player.highscore = inGameUiManager.Score;   
            }
            moneyearn =  inGameUiManager.Score / 10;
            player.cash += moneyearn;
            score.text = "Score: " + inGameUiManager.Score.ToString();
            money.text = moneyearn.ToString();
            highscore.text = "High Score" + player.highscore.ToString();
            SaveSystem.SavePlayer(player);

        }
    }

    public GameObject getchild(GameObject fromobject, string name)
    {
        Transform[] ts = fromobject.transform.GetComponentsInChildren<Transform>();

        foreach (Transform t in ts)
        {
            if (t.gameObject.name == name)
            {
                return t.gameObject;
            }

        }
        return null;
    }

}
