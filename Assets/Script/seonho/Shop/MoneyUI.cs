using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyUI : MonoBehaviour
{
    public TMP_Text moneyText; // �Ӵ� �ؽ�Ʈ UI
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameManager.instance;
        UpdateMoneyText();
    }

    void Update()
    {
        UpdateMoneyText();
    }

    private void UpdateMoneyText()
    {
        moneyText.text = "Money: " + gameManager.playerMoney.ToString();
    }
}