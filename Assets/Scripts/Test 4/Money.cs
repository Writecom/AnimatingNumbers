using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    public NumberCounter4 numberCounter;
    public int newMoney;
    public NumberCounterUpdater4 numberCounterUpdater4;

    private void Start()
    {
        //numberCounterUpdater4.SetValue5(_money);
        //int newMoney = NumberCounter4.Money;
    }

    public void addMoney()
    {
        newMoney += 100;
        numberCounterUpdater4.SetValue5(newMoney);
    }

    public void removeMoney()
    {
        newMoney -= 100;
        numberCounterUpdater4.SetValue5(newMoney);
    }
}
