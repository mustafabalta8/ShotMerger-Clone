using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplierBox : MonoBehaviour
{

    [SerializeField] private GameObject[] memberBoxes;
    [Header("Shooting")]
    [SerializeField] private int multiplierType = 2;
    [SerializeField] protected float amountToShoot = 1;
    protected float shootTime = 0;

    private void Update()
    {
        /*if (gameObject.tag == "Colon")
        foreach (var member in memberBoxes)
        {
            HandleShooting(member.transform);
        }*/      
    }
    private bool tripleBox = false;
    public void Set(Location location, int boxColon, int totalAmountToShoot)
    {
        gameObject.tag = "Colon";
        //gameObject.AddComponent<BoxCollector>();
        transform.parent = PlayerController.instance.ColonParent;
        foreach (var member in memberBoxes)
        {
            member.AddComponent<BoxCollector>();

            if (member.GetComponent<BoxMember>().Location == Location.Middle)
            {
                tripleBox = true;
            }
        }
        if (tripleBox)
        {
            if(location == Location.Left)
            {
                //middle boxColon + 1
                SetNewBoxToPlayer(boxColon +1);
                //right boxColon + 2
                memberBoxes[2].GetComponent<BoxCollector>().BoxColon = boxColon + 2;
                ColonManager.instance.UpdateAmountPerSeconds(boxColon + 2, 1, multiplierType);
            }
            else if (location == Location.Middle)
            {
                //left
                memberBoxes[0].GetComponent<BoxCollector>().BoxColon = boxColon - 1;
                ColonManager.instance.UpdateAmountPerSeconds(boxColon - 1, 1, multiplierType);
                //right
                memberBoxes[2].GetComponent<BoxCollector>().BoxColon = boxColon + 1;
                ColonManager.instance.UpdateAmountPerSeconds(boxColon + 1, 1, multiplierType);
            }
            else//Right
            {
                //left
                memberBoxes[0].GetComponent<BoxCollector>().BoxColon = boxColon - 2;
                ColonManager.instance.UpdateAmountPerSeconds(boxColon - 2, 1, multiplierType);
                //middle
                memberBoxes[1].GetComponent<BoxCollector>().BoxColon = boxColon - 1;
                ColonManager.instance.UpdateAmountPerSeconds(boxColon - 1, 1, multiplierType);
            }
        }
        else
        {
            if (location == Location.Left)
            {
                //right
                memberBoxes[1].GetComponent<BoxCollector>().BoxColon = boxColon + 1;
                ColonManager.instance.UpdateAmountPerSeconds(boxColon + 1, 1, multiplierType);
            }
            else// location right
            {
                //left
                memberBoxes[0].GetComponent<BoxCollector>().BoxColon = boxColon - 1;
                ColonManager.instance.UpdateAmountPerSeconds(boxColon - 1, 1, multiplierType);
            }
        }

        if (location == Location.Left)
            transform.position = transform.position + new Vector3(0.5f, 0, 0);
        else if (location == Location.Right)
        {
            transform.position = transform.position + new Vector3(-0.5f, 0, 0);
        }
    }

    private void SetNewBoxToPlayer(int boxColon)
    {
        memberBoxes[1].GetComponent<BoxCollector>().BoxColon = boxColon;
        ColonManager.instance.UpdateAmountPerSeconds(boxColon, 1, multiplierType);

        Shooter newShooter = memberBoxes[1].gameObject.AddComponent<Shooter>();
        if (boxColon >= 0)
            newShooter.SetAmountToShoot(ColonManager.instance.TotalAmounts[boxColon]);
        else
        {
            newShooter.SetAmountToShoot(ColonManager.instance.TotalAmountsMinus[-(boxColon)]);
        }
    }

    protected void HandleShooting(Transform member)
    {
        shootTime += Time.deltaTime;
        if (shootTime > 1f / amountToShoot)
        {
            Shoot(member);
            shootTime = 0;
        }
    }
    protected void Shoot(Transform member)
    {
        GameObject newBullet = ObjectPooler.instance.GetPooledObject();
        newBullet.transform.position = member.transform.position;
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

