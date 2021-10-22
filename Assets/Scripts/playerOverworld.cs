using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerOverworld : MonoBehaviour
{
    private float xValue;
    private float yValue;
    private Rigidbody2D rigid;
    public int speed = 10; 
    private void Start()
    {
    }
    void FixedUpdate()
    {
        rigid = this.GetComponent<Rigidbody2D>();
        xValue = Input.GetAxis("Horizontal");
        yValue = Input.GetAxis("Vertical");
        rigid.AddForce(new Vector2(xValue * speed, yValue * speed), ForceMode2D.Impulse);
    }
}
