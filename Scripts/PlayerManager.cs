using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class PlayerManager : MonoBehaviour
{

    public float health, bulletSpeed;

    bool dead = false;

    Transform muzzle;

    public Transform bullet, floatingText, bloodParticle;

    public Slider slider;

    bool mouseIsNotOverUI;

    // Start is called before the first frame update
    void Start()
    {
        muzzle = transform.GetChild(1);
        slider.maxValue = health;
        slider.value = health;

    }
    
    // Update is called once per frame
    void Update()
    {
        mouseIsNotOverUI = EventSystem.current.currentSelectedGameObject == null;  //herhangi bir nesneye t�kland�g�nda ate� etmemesi i�in
        if (Input.GetMouseButtonDown(0) && mouseIsNotOverUI)  //mouseun sol tu�u
        {
            ShootBullet();
        }
    }

    public void getDamage(float damage) // enemy'nin verdi�i hasar miktar�
    {

        Instantiate(floatingText,transform.position,Quaternion.identity).GetComponent<TextMesh>().text=damage.ToString();
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
            Destroy(Instantiate(bloodParticle,transform.position,Quaternion.identity),3f);
            DataManager.Instance.LoseProcess();
            dead = true;
            Destroy(gameObject);
        }
    }

    void ShootBullet()
    {
       Transform tempBullet;
       tempBullet=Instantiate(bullet, muzzle.position, Quaternion.identity);
       tempBullet.GetComponent<Rigidbody2D>().AddForce(muzzle.forward * bulletSpeed); //f�rlatmak i�in
       DataManager.Instance.ShotBullet++;
    }
}
