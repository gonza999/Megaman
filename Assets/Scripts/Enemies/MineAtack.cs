using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineAtack : MonoBehaviour
{
    private float waitedTime;

    public float waitTimeToAtack = 3;

    public Animator animator;

    public GameObject bulletPrefab;

    public Transform launchSpawnPoint;

    private void Start()
    {
        waitedTime = waitTimeToAtack;
    }

    private void Update()
    {
        if (waitedTime <= 0)
        {
            waitedTime = waitTimeToAtack;
            animator.Play("Atack");
            Invoke("LaunchBullet", 0.2f);
        }
        else
        {
            waitedTime -= Time.deltaTime;
        }
    }

    public void LaunchBullet()
    {
        GameObject newBullet;
        newBullet = Instantiate(bulletPrefab, launchSpawnPoint.position, launchSpawnPoint.rotation);
    }
}
