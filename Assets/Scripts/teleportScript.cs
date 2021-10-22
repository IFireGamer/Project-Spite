using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportScript : MonoBehaviour
{
    public Transform end;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(Teleport(collision));
        }
    }
    IEnumerator Teleport(Collider2D collision)
    {
        collision.GetComponentInChildren<Camera>().GetComponentInChildren<Animator>().SetBool("Exit", false);
        yield return new WaitForSeconds(1);
        collision.transform.position = end.position;
        collision.GetComponentInChildren<Camera>().GetComponentInChildren<Animator>().SetBool("Exit", true);
        yield return new WaitForSeconds(1);
    }
}
