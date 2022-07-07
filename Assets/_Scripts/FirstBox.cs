using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstBox : Singleton<FirstBox>
{
    [SerializeField] GameObject firstCollectedBox;
    bool isActive = true;

    public GameObject FirstCollectedBox { get => firstCollectedBox; }

    private void OnTriggerEnter(Collider other)
    {
        if (isActive)
        {
            firstCollectedBox = other.gameObject;
            isActive = false;
        }
    }
}
