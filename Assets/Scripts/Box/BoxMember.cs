using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMember : MonoBehaviour
{
    [SerializeField] private Location location;

    public Location Location { get => location; }
    public GameObject OtherMember { get => otherMember; set => otherMember = value; }

    [SerializeField] private MultiplierBox multiplierBox;

    [SerializeField] GameObject otherMember;

    private void Start()
    {
        multiplierBox = transform.parent.gameObject.GetComponent<MultiplierBox>();
    }

    public void SetPosition()
    {
        otherMember.AddComponent<BoxCollector>();
        otherMember.tag = "Colon";
        gameObject.AddComponent<BoxCollector>();
        multiplierBox.transform.parent = PlayerController.instance.ColonParent;
        if (Location == Location.Left)
        {
            multiplierBox.gameObject.transform.position += new Vector3(.5f, 0, 1f);  
        }
        else if(Location == Location.Right)
        {
            multiplierBox.gameObject.transform.position += new Vector3(-.5f, 0, 1f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Colon")
        {
            if(Location == Location.Left)
            {

            }
        }
    }











    public bool isActive=false;
    private void Update()
    {
        //if (isActive)
            //HandleShooting();
    }
    
}
