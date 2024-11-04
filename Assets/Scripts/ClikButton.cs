using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClikButton : MonoBehaviour
{
    public Game Game;

    public Vector3 touchPosition;

    void OnMouseDown()
    {
        touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        touchPosition.z = 0; 
        Game.balance += Game.clickMoney;
        Debug.Log("Объект был кликнут!");
        Game.Balance.text = Game.balance.ToString("0");
        Game.ClickToSpawn();
        Game.UpgradeColor();
    }

}
