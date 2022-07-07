using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : Singleton<UIManager>
{
    
    [SerializeField] private TMP_Text amountPerSecondText;

    [Header("MenuUI")]
    [SerializeField] private Image hand;
    [SerializeField] private float handMoveRange=250f;
    [SerializeField] private TextMeshProUGUI tapToPlayText;
    [SerializeField] private GameObject TapMenuScreen;
    void Start()
    {
        AnimateMenu();
    }

    private void AnimateMenu()
    {
        hand.transform.DOLocalMoveX(handMoveRange, 0.8f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
        //tapToPlayText.transform.DOScale(1.2f, 0.5f).SetLoops(100000, LoopType.Yoyo).SetEase(Ease.InOutSine);
    }

    public void UpdateAmountPerSecondText(int amount)
    {
        amountPerSecondText.text = amount+"/sec";
    }
}
