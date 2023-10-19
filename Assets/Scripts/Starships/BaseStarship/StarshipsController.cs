using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StarshipsController : MonoBehaviour
{
    [Header("Starship Components")]
    public GameObject ShipLaser;
    public Transform GunLeft;
    public Transform GunRight;

    [Header("Starship Status")]
    public float ShipLife = 100;
    public float ShipVelocity = 1;
    public float GunsDamage = 10;

    

    void Start() => OnStartShip();

    void Update() => OnUpdateShip();       


    public virtual void OnStartShip()
    {
        //laserController = ShipLaser.GetComponent<StarshipsLaserController>();
        //laserController.LaserDamage = GunsDamage;
    }

    public virtual void OnUpdateShip()
    {
        HandleShipMovement();
        HandleLaserShooting();

        if (ShipLife <= 0 )
        {

        }
    }
    public virtual void OnDestroyShip() { }


    public abstract void HandleShipMovement();
    public abstract void HandleLaserShooting();


    protected void ShootLaser()
    {
        Instantiate(ShipLaser, GunRight.position, GunRight.rotation);
        Instantiate(ShipLaser, GunLeft.position, GunLeft.rotation);
    }

    public void ReciveDamage(float Damage)
    {
        ShipLife -= Damage;
    }
}
