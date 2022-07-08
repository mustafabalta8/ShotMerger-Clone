using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    [SerializeField] private int health=10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            health--;
            other.gameObject.SetActive(false);
            if (health < 0)
            {
                transform.parent.gameObject.SetActive(false);
            }
        }
        if (other.tag == "Colon")
        {
            GameManager.instance.RestartGame();
        }
    }
}
