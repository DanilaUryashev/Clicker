using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [Header("MainParam")]
    public TMP_Text Balance;
    public int balance = 0;
    public TMP_Text LevelUpgrade;
    public int levelUpgrade=0;
    public TMP_Text UpgradePrice;
    public int upgradePrice =10;
    public TMP_Text ClickMoney;
    public int clickMoney =1;
    public GameObject buttonClk;
    public GameObject buttonUp;
    public GameObject StackMoney;
    public Image buttobImage;
    public ClikButton clickButton;

    void Start()
    {
        LoadGame();
        UpdateValue();
        buttobImage = buttonUp.GetComponent<Image>();
    }



    public void Upgrade()
    {
        if (balance >= upgradePrice) 
        {
            
            // Upgrade
            //lvl+1 clcMoney+ money-

            balance -= upgradePrice;
            levelUpgrade += 1;
            clickMoney =(int)Mathf.Round(clickMoney *1.35f);
            upgradePrice = (int)(upgradePrice *1.75f);
            UpdateValue();
            Debug.Log("Объект был 21кликнут!");
            UpgradeColor();
        }
    }
    public void ClickToSpawn()
    {
        
        GameObject spawnedObject = Instantiate(StackMoney, clickButton.touchPosition, Quaternion.Euler(0, 0, UnityEngine.Random.Range(0f, 360f)));
        Rigidbody2D rb = spawnedObject.GetComponent<Rigidbody2D>();
        spawnedObject.transform.SetParent(this.transform);
        spawnedObject.transform.localScale = Vector3.one;
        spawnedObject.SetActive(true);
        rb.AddForce(new Vector2(UnityEngine.Random.Range(-2f, 2f), UnityEngine.Random.Range(-2f, 2f)), ForceMode2D.Impulse);
     
    }
    private void SaveGame()
    {
        PlayerPrefs.SetInt("Balance", balance);
        PlayerPrefs.SetInt("UpgradePrice", upgradePrice);
        PlayerPrefs.SetInt("ClickMoney", clickMoney); 
        PlayerPrefs.SetInt("LevelUpgrade", levelUpgrade);
    }
    private void LoadGame()
    {
        balance = PlayerPrefs.GetInt("Balance");
        upgradePrice = PlayerPrefs.GetInt("UpgradePrice");
        clickMoney = PlayerPrefs.GetInt("ClickMoney");
        levelUpgrade = PlayerPrefs.GetInt("LevelUpgrade");
    }
    private void OnApplicationQuit()
    {
        SaveGame();
    }
    private void UpdateValue()
    {
        LevelUpgrade.text = "LV " + levelUpgrade.ToString();
        ClickMoney.text = "+" + clickMoney.ToString();
        UpgradePrice.text = "UPGRADE " + upgradePrice.ToString();
        Balance.text = balance.ToString();
    }
    public void UpgradeColor()
    {
        if (balance < upgradePrice)
        {
            buttobImage.color = Color.gray;
        }
        else
        {
            buttobImage.color = new Color(2f / 255f, 255f / 255f, 118f / 255f);
        }
    }
}
