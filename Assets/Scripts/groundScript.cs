using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundScript : MonoBehaviour
{
    // Start is called before the first frame update
    Player player;
    private void Start()
    {
        player = this.GetComponentInParent<Player>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            player.grounded = true;
            player.GetComponent<Animator>().SetTrigger("Grounded");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            player.grounded = false;
        }
    }

}
