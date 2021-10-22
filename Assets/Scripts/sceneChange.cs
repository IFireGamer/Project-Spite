using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneChange : MonoBehaviour
{
    public string scene;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(Scene(collision, scene));
        }
    }

    IEnumerator Scene(Collider2D collision, string sceneName)
    {
        collision.GetComponentInChildren<Camera>().GetComponentInChildren<Animator>().SetBool("Exit", false);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneName);
        
    }
    
}
