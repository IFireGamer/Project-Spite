using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10;
    public float jumpForce = 10;
    public bool grounded = true;
    public Object bulletObject;
    public int HP = 3;
    public bool invuln = false;
    public GameObject loss;
    public GameObject win;
    public int enemyCount;

    private void FixedUpdate()
    {
        Rigidbody2D rigid = this.GetComponent<Rigidbody2D>();
        float xValue = Input.GetAxis("Horizontal") * speed;
        float jump = Input.GetAxis("Vertical");
        
        if (xValue != 0)
        {
            rigid.AddForce(new Vector2(xValue, 0));
        }
        if ((jump > 0)&&grounded)
        {
            rigid.AddForce(new Vector2(0, jumpForce));
            grounded = false;
        }
    }
    private void Update()
    {
        if(HP == 0)
        {
            Destroy(this.gameObject);
            loss.gameObject.SetActive(true);
        }
        if(enemyCount <= 0)
        {
            win.gameObject.SetActive(true);
        }
        bool fire = Input.GetKeyDown(KeyCode.Return);
        if (fire)
        {
            Instantiate(bulletObject, new Vector3(this.transform.position.x, this.transform.position.y), transform.rotation * Quaternion.Euler(0f, 0f, 90f));
        }
        
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyBullet"))
        {
            if (!invuln)
            {
                HP--;
                StartCoroutine(Invuln());
            }
            Destroy(collision.gameObject);
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            if (!invuln)
            {
                HP--;
                StartCoroutine(Invuln());
            }
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Enemy") && !invuln)
        {
            HP--;
            StartCoroutine(Invuln());
        }
    }
    IEnumerator Invuln()
    {
        invuln = true;
        this.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f);
        yield return new WaitForSecondsRealtime(2);
        invuln = false;
        this.GetComponent<SpriteRenderer>().color = new Color(256f, 256f, 256f);
    }
}
