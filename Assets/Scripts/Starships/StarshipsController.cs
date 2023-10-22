using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public abstract class StarshipsController : MonoBehaviour
{
    [Header("Starship Components")]
    public GameObject ShipLaser;
    public Transform GunLeft;
    public Transform GunRight;

    [Header("Starship Life Status")]
    public float ShipLife;
    public float maxHealth = 100;

    [Header("Starship Status")]
    public float ShipVelocity = 1;
    public float GunsDamage = 10;


    private void Start()
    {
        ShipLife = maxHealth;
        ShipLaser.GetComponent<LaserController>().TargetCollision = LaserTypeTarget;
        ShipLaser.GetComponent<LaserController>().LaserDamage = GunsDamage;
    }

    private void Update()
    {
        
    }

    

    public string LaserTypeTarget = "Player";

    public abstract void HandleShipMovement();
    public abstract void HandleLaserShooting();

    public virtual void ReciveDamage(float Damage)
    {
        ShipLife -= (Damage / 10);
    }

    public void InitializeLaser()
    {

    }
}
