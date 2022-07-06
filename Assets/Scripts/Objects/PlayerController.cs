using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Singleton<PlayerController>
{
    [Header("Movement")]
    [SerializeField] private Vector3 movementDirection;
    [SerializeField] private float forwardSpeed;
    [SerializeField] private float swerveSpeed;
    [SerializeField] private float sideMovementLimit;

    [Header("Colon")]
    [SerializeField] private Transform colonParent;

    void Start()
    {
        //StartCoroutine(Shoot());
    }
    [Header("Shooting")]
    [SerializeField] private float shootSpeed=1;
    private float shootTime = 0;

    public Transform ColonParent { get => colonParent; }

    void Update()
    {


        MoveForward();
        HandleSideMove();
        //HandleShooting();
    }

    private void HandleShooting()
    {
        shootTime += Time.deltaTime;
        if (shootTime > shootSpeed)
        {
            Shoot2();
            shootTime = 0;
        }
    }

    private void MoveForward()
    {
        transform.Translate(movementDirection * Time.deltaTime * forwardSpeed);//

    }
    private void HandleSideMove()
    {

        float swerveAmount = swerveSpeed * InputManager.instance.MoveFactorX * Time.deltaTime;

        var currentPos = transform.position;
        currentPos.x += swerveAmount;
        currentPos.x = Mathf.Clamp(currentPos.x, -sideMovementLimit, sideMovementLimit);

        transform.position = currentPos;//Mathf.SmoothDamp??

    }
    private IEnumerator Shoot()
    {
        while(GameManager.GameState == GameStates.InGame)
        {
            GameObject newBullet = ObjectPooler.instance.GetPooledObject();
            //newBullet.transform.position = bulletPoint1.position;
            newBullet.SetActive(true);
            yield return new WaitForSeconds(shootSpeed);
        }       
    }
    private void Shoot2()
    {
            GameObject newBullet = ObjectPooler.instance.GetPooledObject();
            //newBullet.transform.position = bulletPoint1.position;
            newBullet.SetActive(true);
            
    }


}
