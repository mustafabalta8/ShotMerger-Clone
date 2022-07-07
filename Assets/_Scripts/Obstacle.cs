using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float angle=40;
    private void Update()
    {
        transform.Rotate(Vector3.right, angle * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Colon")
        {
            print("game over");
        }
    }
}
