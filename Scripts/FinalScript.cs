using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinalScript : MonoBehaviour
{
    public static DataManager Instan;

    public GameObject finalPoint;
    public GameObject finalScreen;
    public GameObject player;
    public GameObject pauseButton;

    private int enemyKilled;

    void Start()
    {
        
    }

    void Update()
    {
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Time.timeScale = 1;
            finalScreen.SetActive(true);
            player.SetActive(false);
            GameObject.Find("ScoreText").GetComponent<Text>().text = "Your Score: " + (DataManager.Instance.EnemyKilled*2).ToString();
            pauseButton.gameObject.SetActive(false);
        }
    }
    public int Killed
    {
        get
        {
            return enemyKilled;
        }
        set
        {
            enemyKilled = value;
            GameObject.Find("KilledText").GetComponent<Text>().text = enemyKilled.ToString();

        }
    }


}
