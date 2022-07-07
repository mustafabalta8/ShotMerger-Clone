using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColonManager : Singleton<ColonManager>
{
    public int colon = 1;

    private BoxCollector[] collectors;
    private int totalAmountPerSecond;

    [SerializeField] private int[] amountToShoot = new int[10];
    [SerializeField] private int[] amountToShootMinus = new int[10];

    [SerializeField] private int[] amountToMultiply = new int [10];
    [SerializeField] private int[] amountToMultiplyMinus = new int[10];

    [SerializeField] private int[] totalAmounts = new int[10];
    [SerializeField] private int[] totalAmountsMinus = new int[10];

    private void Start()
    {
        for (int i = 0; i < amountToShoot.Length; i++)
        {
            amountToShoot[i] = 1;
        }
        for (int i = 0; i < amountToShootMinus.Length; i++)
        {
            amountToShootMinus[i] = 1;
        }
        for (int i=0;i<amountToMultiply.Length;i++)
        {
            amountToMultiply[i] = 1;
        }
        for (int i = 0; i < amountToMultiplyMinus.Length; i++)
        {
            amountToMultiplyMinus[i] = 1;
        }
    }
    public int TotalAmountPerSecond { get => totalAmountPerSecond; set => totalAmountPerSecond = value; }

    public int[] AmountToMultiply { get => amountToMultiply; set => amountToMultiply = value; }
    public int[] AmountToMultiplyMinus { get => amountToMultiplyMinus; set => amountToMultiplyMinus = value; }
    public int[] TotalAmounts { get => totalAmounts; set => totalAmounts = value; }
    public int[] TotalAmountsMinus { get => totalAmountsMinus; set => totalAmountsMinus = value; }

    public void UpdateAmountPerSeconds(int colonIndex, int additionToAmount, int additionToMultipliers)
    {
        //collectors = FindObjectsOfType<BoxCollector>();
        switch (colonIndex)
        {
            case 0:
                UpdateColonShootInfo(colonIndex, additionToAmount, additionToMultipliers);
                break;
            case 1:
                UpdateColonShootInfo(colonIndex, additionToAmount, additionToMultipliers);
                break;
            case 2:
                UpdateColonShootInfo(colonIndex, additionToAmount, additionToMultipliers);
                break;
            case 3:
                UpdateColonShootInfo(colonIndex, additionToAmount, additionToMultipliers);
                break;
            case 4:
                UpdateColonShootInfo(colonIndex, additionToAmount, additionToMultipliers);
                break;
            case 5:
                UpdateColonShootInfo(colonIndex, additionToAmount, additionToMultipliers);
                break;

            //COLONS OF LEFT SIDE
            case -1:
                UpdateLeftColonsShootInfo(colonIndex, additionToAmount, additionToMultipliers);
                break;
            case -2:
                UpdateLeftColonsShootInfo(colonIndex, additionToAmount, additionToMultipliers);
                break;
            case -3:
                UpdateLeftColonsShootInfo(colonIndex, additionToAmount, additionToMultipliers);
                break;
            case -4:
                UpdateLeftColonsShootInfo(colonIndex, additionToAmount, additionToMultipliers);
                break;
            case -5:
                UpdateLeftColonsShootInfo(colonIndex, additionToAmount, additionToMultipliers);
                break;
        }
    }

    private void UpdateColonShootInfo(int colonIndex, int additionToAmount, int additionToMultipliers)
    {
        amountToMultiply[colonIndex] *= additionToMultipliers;
        amountToShoot[colonIndex] += additionToAmount;
        totalAmounts[colonIndex] = amountToShoot[colonIndex] * amountToMultiply[colonIndex];
        print(colonIndex + ": " + totalAmounts[colonIndex]);
        CalculateTotalAmountPerSecond();


    }
    private void UpdateLeftColonsShootInfo(int colonIndex, int additionToAmount, int additionToMultipliers)
    {
        //AmountToMultiplyMinus 0'ýncý index kullanýlmýyor
        colonIndex = Mathf.Abs(colonIndex);
        AmountToMultiplyMinus[colonIndex] *= additionToMultipliers;
        amountToShootMinus[colonIndex] += additionToAmount;
        totalAmountsMinus[colonIndex] = amountToShoot[colonIndex] * amountToMultiply[colonIndex];
        print(-colonIndex + ": " + totalAmounts[colonIndex]);
        CalculateTotalAmountPerSecond();
    }
   // float totalAmount;
    private void CalculateTotalAmountPerSecond()
    {
        int temp=0;
        for(int i = 0; i < totalAmounts.Length; i++)
        {
            if (totalAmounts[i] != 1)
            {
                temp += totalAmounts[i];
            }
            if (totalAmountsMinus[i] != 1)
            {
                temp += totalAmountsMinus[i];
            }
        }

        UIManager.instance.UpdateAmountPerSecondText(temp);
    }


}
