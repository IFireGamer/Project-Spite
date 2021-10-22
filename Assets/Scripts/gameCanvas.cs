using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameCanvas : MonoBehaviour
{
    public Player player;
    public BossScript[] bosses;
    public Text number;
    public Text countdownLabel;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountDown());
    }

    // Update is called once per frame
    IEnumerator CountDown()
    {
        for(int i = 3; i > 0; i--)
        {
            number.text = i.ToString();
            yield return new WaitForSeconds(1);
            
        }
        foreach(BossScript boss in bosses)
        {
            boss.gameObject.SetActive(true);
        }
        player.enabled = true;
        number.gameObject.SetActive(false);
        countdownLabel.gameObject.SetActive(false);
    }
}
