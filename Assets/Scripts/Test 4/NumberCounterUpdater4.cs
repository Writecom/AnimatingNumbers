using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NumberCounterUpdater4 : MonoBehaviour
{
    public NumberCounter4 NumberCounter4;
    public TMP_InputField InputField3;

    /*
    public void SetValue4()
    {
        int value;

        if (int.TryParse(InputField3.text, out value))
        {
            NumberCounter4.Value = value;
        }
    }
    */

    public void SetValue5(int newMoney)
    {

        //newMoney = int.TryParse(InputField3.text, out newMoney); 
        NumberCounter4.Money = newMoney;
    }

}
