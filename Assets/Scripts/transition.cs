using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class transition : MonoBehaviour
{
    // Start is called before the first frame update
    public string scene;
    public Animator screen;
    void Start()
    {
        StartCoroutine(waitUntilTransition());
    }

    // Update is called once per frame
    IEnumerator waitUntilTransition()
    {
        screen.SetBool("Bool", true);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(scene);
    }
}
