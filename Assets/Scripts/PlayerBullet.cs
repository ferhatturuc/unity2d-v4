using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D theRB;
    public GameObject impactEffect;
    public int damageToGive = 50;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        //okumuzun hızı
        theRB.velocity = transform.right * speed;
    }
    //cisimle carpısmada okları yok  ediyor ama bir hata  sonucu ok cıkar cıkmaz yok oluyor
    private void OnTriggerEnter2D(Collider2D other)
    {
        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
        // eğer saldırımız düşmana çarparsa düşmana hasar ver
      if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyController>().DamageEnemy(damageToGive);
        }
    }
    //harita dısına cıkan okları yok ediyor
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
