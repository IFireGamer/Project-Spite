using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour
{
    private int HP = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("PlayerBullet"))
        {
            HP--;
            if(HP == 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
    // Update is called once per frame

}
