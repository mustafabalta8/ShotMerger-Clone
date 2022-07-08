using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaserBox : MonoBehaviour
{
    [SerializeField] private int amountToIncrease = 1;

    [SerializeField] private float amountToShoot = 1;

    
    public int AmountToIncrease { get => amountToIncrease; set => amountToIncrease = value; }

    
}
