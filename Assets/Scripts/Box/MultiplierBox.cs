using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplierBox : MonoBehaviour
{

    [SerializeField] private GameObject[] memberBoxes;
    [Header("Shooting")]
    [SerializeField] private int multiplierType = 2;
    [SerializeField] protected float amountToShoot = 2;
    protected float shootTime = 0;

    [SerializeField] private Location location;

    public Location Location111 { get => location; }

    private void Update()
    {
        /*foreach (var member in memberBoxes)
        {
            HandleShooting(member.transform);
        }*/
        //HandleShooting();
    }
    public void Set(Location location0)
    {
        //gameObject.AddComponent<BoxCollector>();
        transform.parent = PlayerController.instance.ColonParent;
        memberBoxes[0].AddComponent<BoxCollector>();
        memberBoxes[1].AddComponent<BoxCollector>();
        if (location0 == Location.Left)
            transform.position = transform.position + new Vector3(0.5f, 0, 0);
        else
        {
            transform.position = transform.position + new Vector3(-0.5f, 0, 0);
        }
    }
    
    public void ActivateMembers()
    {
        if (Location111 == Location.Left)
        {
            transform.localPosition = transform.localPosition + new Vector3(0.5f, 0, 1f);
            //memberBoxes[0].transform.localPosition = transform.localPosition + new Vector3(0.5f, 0, 0);
        }
        else if (Location111 == Location.Right)
        {
            transform.localPosition = transform.localPosition + new Vector3(-0.5f, 0, 1f);
            //memberBoxes[0].transform.localPosition = transform.localPosition + new Vector3(-0.5f, 0, 0);
        }
        //StartCoroutine(Shoot2());
        foreach (var member in memberBoxes)
        {
            member.transform.parent = PlayerController.instance.ColonParent;
            /*member.transform.localPosition = new Vector3(Mathf.Round(member.transform.localPosition.x),
                member.transform.localPosition.y, member.transform.localPosition.z);*/
            member.gameObject.AddComponent<BoxCollector>();
            
            if (member.GetComponent<MultiplierBox>().Location111 == Location.Left)
            {
                member.transform.localPosition = transform.localPosition + new Vector3(0.5f, 0, 1f);
            }
            else if (member.GetComponent<MultiplierBox>().Location111 == Location.Right)
            {
                member.transform.localPosition = transform.localPosition + new Vector3(-0.5f, 0, 1f);
            }



            //member.GetComponent<MultiplierBox>().StartCoroutine(Shoot2());
        }
        
    }
    protected void HandleShooting()
    {
        shootTime += Time.deltaTime;
        if (shootTime > 1f / amountToShoot)
        {
            Shoot();
            shootTime = 0;
        }
    }
    protected void Shoot()
    {
        GameObject newBullet = ObjectPooler.instance.GetPooledObject();
        newBullet.transform.position = transform.position;
        newBullet.SetActive(true);

    }
    public IEnumerator Shoot2()
    {
        while (GameManager.GameState == GameStates.InGame)
        {
            GameObject newBullet = ObjectPooler.instance.GetPooledObject();
            //newBullet.transform.position = bulletPoint1.position;
            newBullet.SetActive(true);
            yield return new WaitForSeconds(1f / amountToShoot);
        }
    }
}

