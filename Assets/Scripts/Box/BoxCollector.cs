using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCollector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Box")//left box, right box, middle box 
        {
            
            other.tag = "Colon";
            //transform
            //other.GetComponent<BoxMember>().SetPosition();
            other.GetComponent<BoxMember>().OtherMember.tag = "Colon";
            other.transform.parent.GetComponent<MultiplierBox>().transform.position = transform.position + 
                new Vector3(0, 0, transform.localScale.z);
            other.transform.parent.GetComponent<MultiplierBox>().transform.parent= PlayerController.instance.ColonParent;
            other.transform.parent.GetComponent<MultiplierBox>().Set(other.GetComponent<BoxMember>().Location);

            /*
            if (other.GetComponent<MultiplierBox>())
            {              
                //other.GetComponent<MultiplierBox>().ActivateMembers();               
            }*/

            if (other.GetComponent<IncreaserBox>())
            {
                other.transform.position = transform.position + new Vector3(0, 0, transform.localScale.z);
                other.gameObject.AddComponent<BoxCollector>();
                other.transform.parent = PlayerController.instance.ColonParent;
            }



           Destroy(this);

        }

    }
}
