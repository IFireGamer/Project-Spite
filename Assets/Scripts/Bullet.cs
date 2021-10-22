using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Rigidbody2D>().AddForce(new Vector2(1000, 0));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            Destroy(this.gameObject);
        }
        if (collision.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
            collision.GetComponent<BossScript>().HP--;
        }
    }


}
