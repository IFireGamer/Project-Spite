using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class canvasScript : MonoBehaviour
{
    public playerOverworld player;
    private void Start()
    {
        string[] str = new string[]{ "Hello World", "Sup pimps" };
        StartCoroutine(TextboxStart(str));
    }
    public IEnumerator Textbox(string[] text)
    {
        player.enabled = false;
        GetComponentInChildren<Animator>().gameObject.SetActive(true);
        
        GetComponentInChildren<Animator>().SetBool("Exit", false);
        for(int i = 0; i < text.Length; i++)
        {
            GetComponentInChildren<Animator>().GetComponentInChildren<Text>().text = text[i];
            while (!Input.GetKey(KeyCode.Return))
            {
                yield return new WaitForSeconds(0.01f);
            }
            if(i != text.Length-1)
            {
                GetComponentInChildren<Animator>().SetTrigger("Next");
                yield return new WaitForSeconds(.25f);
            }
            
        }
        

        GetComponentInChildren<Animator>().SetBool("Exit", true);
        player.enabled = true;
    }
    public IEnumerator TextboxStart(string[] text)
    {
        player.enabled = false;
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(Textbox(text));
    }
}
