using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectFirstBox : MonoBehaviour
{

    bool isSelected=false;
    private void OnTriggerEnter(Collider other)
    {
        if (!isSelected && other.tag == "Box" || other.tag == "Colon")
        {
            isSelected = true;
            StartCoroutine(ChangeTag(other));
        }
    }
    IEnumerator ChangeTag(Collider other)
    {
        yield return new WaitForSeconds(.5f);
        other.tag = "First";
        print("first");
    }
}
