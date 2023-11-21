using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonWithDamage : MonoBehaviour
{
 
    public HealthController healthController;
    public float damage = 10f;

    public void ButtonPress()
    {
        healthController.TakeDamage(damage);
    }

}
