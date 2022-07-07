using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] private float amountToShoot = 1;
    private float shootTime = 0;
    private Vector3 shootingPosition;


    public void SetAmountToShoot(int value)
    {
        amountToShoot = value;
        StartCoroutine(Shoot2());
    }
    private void Start()
    {
        shootingPosition = transform.position;
    }

    void Update()
    {
        //HandleShooting();
    }

    private void HandleShooting()
    {
        shootTime += Time.deltaTime;
        if (shootTime > amountToShoot)
        {
            Shoot();
            shootTime = 0;
        }
    }
    private void Shoot()
    {
        GameObject newBullet = ObjectPooler.instance.GetPooledObject();
        newBullet.transform.position = shootingPosition;
        newBullet.SetActive(true);
    }

    private IEnumerator Shoot2()
    {
        while (GameManager.GameState == GameStates.InGame)
        {
            GameObject newBullet = ObjectPooler.instance.GetPooledObject();
            newBullet.transform.position = transform.position;
            newBullet.SetActive(true);
            yield return new WaitForSeconds(1/amountToShoot);
        }
    }
    
}
