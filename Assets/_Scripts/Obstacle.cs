using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float angle=40;

    [SerializeField] GameObject[] boxesToDestroy;
    [SerializeField] GameObject[] firstBoxes;
    private void Update()
    {
        transform.Rotate(Vector3.right, angle * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Colon")
        {
            boxesToDestroy = GameObject.FindGameObjectsWithTag("Colon");
            foreach (GameObject box in boxesToDestroy)
            {
                Destroy(box);
            }
            firstBoxes = GameObject.FindGameObjectsWithTag("First");
            foreach (GameObject box in firstBoxes)
            {
                box.gameObject.AddComponent<BoxCollector>();
                box.AddComponent<Shooter>();
                box.GetComponent<Shooter>().SetAmountToShoot(2);
            }
            //PlayerController.instance.ColonParent.gameObject.AddComponent<BoxCollector>();
            //PlayerController.instance.ColonParent.gameObject.AddComponent<Shooter>();

        }
    }
}
