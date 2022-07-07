using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaserBox : MonoBehaviour
{
    [SerializeField] private int amountToIncrease = 1;

    [Header("Shooting")]
    [SerializeField] private float amountToShoot = 1;

    private float shootTime = 0;

    public int AmountToIncrease { get => amountToIncrease; set => amountToIncrease = value; }

    private void HandleShooting()
    {
        shootTime += Time.deltaTime;
        if (shootTime > 1 / amountToShoot)
        {
            Shoot();
            shootTime = 0;
        }
    }
    private void Shoot()
    {
        GameObject newBullet = ObjectPooler.instance.GetPooledObject();
        newBullet.transform.position = transform.position;
        newBullet.SetActive(true);

    }
}
