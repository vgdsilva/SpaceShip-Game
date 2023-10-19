using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarfighterController : StarshipsController
{
    Vector2 ShipMovement;
    Rigidbody2D _shipRigidbody2D;


    public override void OnStartShip()
    {
        base.OnStartShip();

        _shipRigidbody2D = GetComponent<Rigidbody2D>();
    }

    public override void OnUpdateShip()
    {
        base.OnUpdateShip();
    }

    public override void HandleShipMovement()
    {
        ShipMovement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        _shipRigidbody2D.velocity = ShipMovement.normalized * ShipVelocity;
    }

    public override void HandleLaserShooting()
    {
        if ( Input.GetButtonDown("Fire1") )
        {
            ShootLaser();
        }
    }
}
