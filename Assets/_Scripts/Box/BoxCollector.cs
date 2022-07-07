using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCollector : MonoBehaviour
{
    float newBoxCollectorZPosition;
    [SerializeField] private int totalAmountInColonToShoot=1;
    [SerializeField] private int boxColon = 0;

    public int BoxColon { get => boxColon; set => boxColon = value; }
    public int TotalAmountInColonToShoot { get => totalAmountInColonToShoot; set => totalAmountInColonToShoot = value; }

    private void Start()
    {
        newBoxCollectorZPosition = DetermineNewBoxCollectorZPosition();
    }
    private void OnTriggerEnter(Collider other)
    {     
        if (other.tag == "Box")//left box, right box, middle box TAGS ??
        {           

            other.tag = "Colon";
            // if other => 2x || 3x 
            if (other.GetComponent<BoxMember>())// Not sure if GetComponent works as BOOL
            {
                InteractWithMultiplierBox(other);
            }
            else if (other.GetComponent<IncreaserBox>())
            {
                InteractWithIncreaserBox(other);
            }
            Destroy(this);
            Destroy(gameObject.GetComponent<Shooter>());
        }

    }

    private void InteractWithMultiplierBox(Collider other)
    {
        float newBoxXValue = 0;
        other.GetComponent<BoxMember>().SecondMember.tag = "Colon";// it is important which line it runs

        other.gameObject.AddComponent<BoxCollector>();
        other.gameObject.GetComponent<BoxCollector>().BoxColon = BoxColon;
        //to continue

        if (other.GetComponent<BoxMember>().ThirdMember != null)
        {
            other.GetComponent<BoxMember>().ThirdMember.tag = "Colon";

            if (GetComponent<BoxMember>())
            {
                int randomNum = Random.Range(1, 3);
                if (randomNum == 1)
                    newBoxXValue = 0.5f;
                else
                    newBoxXValue = -0.5f;
            }
        }
        other.transform.parent.GetComponent<MultiplierBox>().transform.position = transform.position +
        new Vector3(newBoxXValue, 0, newBoxCollectorZPosition);

        other.transform.parent.GetComponent<MultiplierBox>().transform.parent = PlayerController.instance.ColonParent;
        other.transform.parent.GetComponent<MultiplierBox>().Set(other.GetComponent<BoxMember>().Location, BoxColon, totalAmountInColonToShoot);
    }

    private void InteractWithIncreaserBox(Collider other)
    {
        int increaserType = other.GetComponent<IncreaserBox>().AmountToIncrease;
        //other.GetComponent<IncreaserBox>()
        //other.transform.position = transform.position + new Vector3(0, 0, transform.localScale.z);
        if (increaserType == 1)
            other.transform.position = transform.position + new Vector3(0, 0, newBoxCollectorZPosition);
        else if (increaserType == 2)
            other.transform.position = transform.position + new Vector3(0, 0, newBoxCollectorZPosition + 0.5f);  //.5
        else if (increaserType == 3)
            other.transform.position = transform.position + new Vector3(0, 0, newBoxCollectorZPosition + 1f);    // 1

        
        other.transform.parent = PlayerController.instance.ColonParent;

        BoxCollector newBoxCollector = other.gameObject.AddComponent<BoxCollector>();
        newBoxCollector.BoxColon = BoxColon;
        ColonManager.instance.UpdateAmountPerSeconds(BoxColon, other.gameObject.GetComponent<IncreaserBox>().AmountToIncrease,1);
        //newBoxCollector.TotalAmountInColonToShoot = totalAmountInColonToShoot + increaserType; 

        Shooter newShooter = other.gameObject.AddComponent<Shooter>();
        if (BoxColon >= 0)
            newShooter.SetAmountToShoot(ColonManager.instance.TotalAmounts[BoxColon]);
        else
        {
            newShooter.SetAmountToShoot(ColonManager.instance.TotalAmountsMinus[-BoxColon]);
        }
    }

    private float DetermineNewBoxCollectorZPosition()
    {
        float baseValue = 1;
        if (GetComponent<IncreaserBox>())
        {
            int boxLenght = GetComponent<IncreaserBox>().AmountToIncrease;

            switch (boxLenght)
            {
                case 1:
                    baseValue = 1;
                    break;
                case 2:
                    baseValue = 1.5f;
                    break;
                case 3:
                    baseValue = 2;
                    break;
            }
            
        }
        return baseValue;
        
    }


}
