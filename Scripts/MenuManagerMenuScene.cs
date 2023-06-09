using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuManagerMenuScene : MonoBehaviour
{
    public GameObject DataBoard;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void DataBoardButton()
    {
        DataManager.Instance.LoadData();

        DataBoard.transform.GetChild(1).GetComponent<Text>().text ="Total Bullet Shot: " + DataManager.Instance.totalShotBullet.ToString();
        DataBoard.transform.GetChild(2).GetComponent<Text>().text = "Total Enemy Killed: " + DataManager.Instance.totalEnemyKilled.ToString();
        DataBoard.SetActive(true);
    }
    public void XButton()
    {
        DataBoard.SetActive(false);
    }
}
