using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonWithDamage : MonoBehaviour
{
 
    public HealthController healthController;
    public int damage = 10;

    public void ButtonPress()
    {
        healthController.TakeDamage(damage);
    }

}
