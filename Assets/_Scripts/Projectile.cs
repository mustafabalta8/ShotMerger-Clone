using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Projectile : MonoBehaviour
{
    [SerializeField] private int maxRange = 20;
    [SerializeField] private float velocity = 1.2f;

    private void OnEnable()
    {
        transform.DOMoveZ(transform.position.z + maxRange, velocity).OnComplete(() => ReturnToPool());
    }

    void ReturnToPool()
    {
        gameObject.SetActive(false);
        //transform.position = Vector3.zero;
    }
}
