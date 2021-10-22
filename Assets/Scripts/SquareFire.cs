using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareFire : MonoBehaviour
{
    private BossScript boss;
    private Player player;
    public enemyBullet bullet;
    public int speed = 10;
    public int rate = 2;
    // Start is called before the first frame update
    void Start()
    {
        boss = this.GetComponent<BossScript>();
        player = boss.player;
        StartCoroutine(Fire());
    }

    // Update is called once per frame
    public IEnumerator Fire()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(1);
            enemyBullet newBullet = Instantiate(bullet, this.transform);
            newBullet.GetComponent<Rigidbody2D>().AddForce((player.transform.position - transform.position)*speed);
            yield return new WaitForSecondsRealtime(rate);

        }
    }
}
