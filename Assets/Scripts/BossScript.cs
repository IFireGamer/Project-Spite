using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int HP = 10;
    public bool moveUp = true;
    public int speed;
    public Player player;
    private void FixedUpdate()
    {
        if (moveUp)
        {
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,speed*10));
        }
        else
        {
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -speed * 10));
        }

        if(HP == 0)
        {
            player.enemyCount--;
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("cdEnemy"))
        {
            moveUp = !moveUp;
        }
    }
}
