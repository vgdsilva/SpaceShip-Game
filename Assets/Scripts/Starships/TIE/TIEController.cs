using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TIEController : StarshipsController
{

    [Header("TIE Laser Status")]
    public float maxTimeBetweenLasers;
    public float actualTimeOfTheLasers;


    public override void OnStartShip()
    {
        base.OnStartShip();
    }

    public override void OnUpdateShip()
    {
        base.OnUpdateShip();
    }

    public override void HandleLaserShooting()
    {
        //Descontar alguns segundos do tempo atual
        actualTimeOfTheLasers -= Time.deltaTime;

        //quando o tempo atual chegar em zero atire um novo laser
        if (actualTimeOfTheLasers <= 0)
        {
            //atirou os lasers
            ShootLaser();

            //agora o tempo atual é igual ao tempo maximo e o update ira ficar 
            actualTimeOfTheLasers = maxTimeBetweenLasers;
        }
    }

    public override void HandleShipMovement()
    {
        transform.Translate(Vector3.up * ShipVelocity * Time.deltaTime);
    }
}
