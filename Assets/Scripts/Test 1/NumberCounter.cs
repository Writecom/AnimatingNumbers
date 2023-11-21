using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NumberCounter : MonoBehaviour
{
    public TextMeshProUGUI Text;
    public int CountFPS = 30;
    public float Duration = 1f;
    public string NumberFormat = "N0";
    public int _value;

    //Det her er en property https://www.youtube.com/watch?v=qpbRrxaEzQE
    //Better practice, for hvis en variabel skal �ndre v�rdi �benbart
    //En m�de at overwrite p�
    //Vi bruger property, s� vi kan bruge vores UpdateText funktion til at definere vores v�rdi.
    //I andre lignende systemer, har vi sat en linje 'Text.text = int.ToString()' i vores Update method som h�rer med til vores MonoBehaviour class, hvor den s� tjekker for hver frame efter det. 
    //Dette er f.eks. tilf�ldet i vores MoneyCounter
    public int Value
    {
        //get funktionen bruges til at hente den v�rdi der skal �ndres i, i dette tilf�lde _value
        get
        {
            return _value;
        }

        //set funktionen bruges til at s�tte v�rdien for vores property
        set
        {
            UpdateText(value);
            _value = value;

        }
    }

    //Vi definerer vores Coroutine for l�sbarhed
    private Coroutine CountingCoroutine;

    //Denne funktion skal opdatere vores tekst element - skal lige finde ud af hvordan 
    private void UpdateText(int newValue)
    {
        if (CountingCoroutine != null)
        {
            StopCoroutine(CountingCoroutine);
        }

        CountingCoroutine = StartCoroutine(CountText(newValue));
    }

    //Denne IEnumerator laves, da det skal bruge stil en Coroutine
    //Vi bruger en Coroutine, da vi gerne vil have ting til at ske over flere frames, hvilket i dette tilf�lde er at animere tal der g�r op og ned.
    private IEnumerator CountText(int newValue)
    {
        {
            //definerer en WaitForSeconds, med vores vaiabel CountFPS
            WaitForSeconds Wait = new WaitForSeconds(1f / CountFPS);
            int lastValue = _value;
            int stepAmount;
            int difference = newValue - lastValue;

            if (difference < 0)

                //Mathf.FloorToInt(float f), returnerer den mindste integer ift float v�rdien
                stepAmount = Mathf.FloorToInt((difference) / (CountFPS * Duration));
            else
                //Mathf.CeilToInt returnerer den st�rste integer ift float v�rdien den tager imod
                stepAmount = Mathf.CeilToInt((difference) / (CountFPS * Duration));

            //et for loop, looper indtil vores int i er lige med Mathf.Abs(difference), hvilket svarer til antallet af tal, mellem tallet vi skifter fra, og skifter til
            //Mathf.Abs(float) returnerer den absolutte v�rdi af den float i dit input, hvilket i dette tilf�lde er vores difference int
            for (int i = 0; i < Mathf.Abs(difference); i++)
            {
                lastValue += stepAmount;
                if ((lastValue > newValue && difference > 0) || (lastValue < newValue && difference < 0))
                    lastValue = newValue;

                //Omdanner vores v�rdi til tekst
                Text.SetText(lastValue.ToString());

                //yield returns WaitForSeconds v�rdi, som er variablen Wait, som er sat �verst i vores method,
                //bestmmer hvor l�nge der skal ventes f�r den k�rer vores for loop igen
                yield return Wait;
            }
        }
    }
}
