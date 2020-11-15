using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Showcar : MonoBehaviour
{

    List<CarDetails> cars = new List<CarDetails>();
    public static int currentindex;
    CarDetails obj;
    public Text pricetext;
    public Text Speedtext;
    public Text Braketext;
    public Text cashtext;

    public Button locked;
    public gameManger manager;

    public GameObject notenoughmoney;

    public Button play;

    // Start is called before the first frame update
    void Start()
    {
        manager.Start();
        foreach (Transform child in transform) {
            obj = child.GetComponent<CarDetails>();
            cars.Add(obj);
        }
        currentindex = 0;
        cashtext.text = gameManger.player.cash.ToString();
        updatecar();
        
    }

    public void Next() {
        if (currentindex < 4) {
            cars[currentindex].gameObject.SetActive(false);
            currentindex++;
            updatecar();
        }
    }

    public void Previous() {
        if (currentindex > 0) {
            cars[currentindex].gameObject.SetActive(false);
            currentindex--;
            updatecar();
        }
    }

    void updatecar() {
        cars[currentindex].gameObject.SetActive(true);
        if (gameManger.player.unlocked[currentindex])
        {
            locked.gameObject.SetActive(false);
            play.transform.parent.gameObject.SetActive(true);
        }
        else {
            locked.gameObject.SetActive(true);
            play.transform.parent.gameObject.SetActive(false);
            pricetext.text = "Price: " + cars[currentindex].price.ToString();
        }
        
        
        Speedtext.text = "Speed: " + cars[currentindex].speed.ToString();
        Braketext.text = "Brake: " + cars[currentindex].braking.ToString();
    }


    public void Startgame() {
        SceneManager.LoadScene("SampleScene");
    }


    public void buycurrentcar() {
        int price = cars[currentindex].price;
        if (gameManger.player.cash >= price)
        {

            gameManger.player.cash -= price;
            gameManger.player.unlocked[currentindex] = true;
            cashtext.text = gameManger.player.cash.ToString();
            SaveSystem.SavePlayer(gameManger.player);
            updatecar();

        }
        else {
            notenoughmoney.SetActive(true);
        }
        
        
    }

    public void oknotenoughmoney() {
        notenoughmoney.SetActive(false);
    }

}
