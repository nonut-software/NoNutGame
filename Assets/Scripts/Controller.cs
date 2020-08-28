using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Controller : MonoBehaviour
{
    public Gun gun;
    public RigidbodyFirstPersonController rfpc;
    public float speedCost;
    public float fireRateCost;
    public float damageCost;
    public float healthCost;
    Playerstats money;
    private void Start()
    {
       money = rfpc.GetComponent<Playerstats>();
        FindObjectOfType<AudioManager>().Play("MainTheme");
        
    }

    public void IncSpeed()
    {
        if ( money.GetMoney()>= speedCost)
        {
            money.AddMoney(-speedCost);
            rfpc.movementSettings.ForwardSpeed++;
            rfpc.movementSettings.BackwardSpeed++;
            rfpc.movementSettings.StrafeSpeed++;
        }
        
    }

    public void IncFireRate()
    {
        if (money.GetMoney() >= fireRateCost)
        {
            money.AddMoney(-fireRateCost);
            gun.fireRate++;
        }
    }

    public void IncHealth()
    {
        if (money.GetMoney() >= healthCost)
        {
            money.AddMoney(-healthCost);
            money.health = money.health + 50;
            if (money.health > 100)
                money.health = 100;
        }
    }

    public void IncDamage()
    {
        if (money.GetMoney() >= damageCost)
        {
            money.AddMoney(-damageCost);
            gun.damage++;
        }
    }
}

