using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alertScript : MonoBehaviour
{
    public Animator alert;
    private bool once = false;
    public string[] newText = new string[] { "Hello, I am a \nnew person" };
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            alert.gameObject.SetActive(true);
            alert.SetBool("Exit", false);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            alert.SetBool("Exit", true);
            
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")&&Input.GetKey("e")&& !once)
        {
            once = true;
            StartCoroutine(collision.gameObject.GetComponentInChildren<Camera>().GetComponentInChildren<canvasScript>().Textbox(newText));
        }
    }
}
