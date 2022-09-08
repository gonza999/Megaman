using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineroAtack : MonoBehaviour
{
    public GameObject player;
    private float wait=0;
    public float starwait = 2;
    public Animator animator;
    public static bool atack=false;
    public Transform launchSpawnPoint;
    public GameObject bulletPrefab;

    private void Start()
    {
        wait = starwait;
    }
    private void Update()
    {
        if (atack)
        {
            animator.SetBool("Atack",true);
            Invoke("LaunchBullet", 0.5f);
            atack = false;
        }
        else
        {
            wait -= Time.deltaTime;
        }
        if (wait<=0)
        {
            wait = starwait;
            atack = true;
        }
    }

    public void LaunchBullet()
    {
        GameObject newBullet;
        newBullet = Instantiate(bulletPrefab, launchSpawnPoint.position, launchSpawnPoint.rotation);
        animator.SetBool("Atack", false);
    }
}
