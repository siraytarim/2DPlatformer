using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance;

    public float health;
    public float damage; //player'a verdiði damage

    public int damageCounter = 0;

    bool colliderBusy = false;

    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = health;
        slider.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !colliderBusy)
        {
            damageCounter++;
            colliderBusy = true;
            other.GetComponent<PlayerManager>().getDamage(damage);
        }
        else if(other.tag == "Bullet")
        {
            getDamage(other.GetComponent<BulletManager>().bulletDamage);
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            colliderBusy = false;
        }
    }

    public void getDamage(float damage) // bullet'ýn verdiði hasar miktarý
    {
        if (health - damage >= 0)
        {
            health -= damage;
        }
        else
        {
            health = 0;
        }
        slider.value = health;
        AmIDead();
    }
    void AmIDead()
    {
        if (health <= 0)
        {
            damageCounter++;
            DataManager.Instance.EnemyKilled++;
            Destroy(gameObject);

        }
    }
}
