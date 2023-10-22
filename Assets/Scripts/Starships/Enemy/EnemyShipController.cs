using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipController : StarshipsController
{
    [Header("Laser Status")]
    public float maxTimeBetweenLasers = 1;
    public float actualTimeOfTheLasers = 0;

    [Header("Life Bar")]
    [SerializeField] EnemyHealthBar healthBar;

    void Start()
    {
        healthBar = GetComponentInChildren<EnemyHealthBar>();
    }

    void Update()
    {
        if ( ShipLife <= 0 )
        {
            Destroy(transform.gameObject);
            return;
        }

        HandleShipMovement();
        HandleLaserShooting();
    }

    public override void HandleLaserShooting()
    {
        //Descontar alguns segundos do tempo atual
        actualTimeOfTheLasers -= Time.deltaTime;

        //quando o tempo atual chegar em zero atire um novo laser
        if ( actualTimeOfTheLasers <= 0 )
        {
            //atirou os lasers
            Instantiate(ShipLaser, GunRight.position, Quaternion.Euler(0f, 0f, 180f));
            Instantiate(ShipLaser, GunLeft.position, Quaternion.Euler(0f, 0f, 180f));

            //agora o tempo atual é igual ao tempo maximo e o update ira ficar 
            actualTimeOfTheLasers = maxTimeBetweenLasers;
        }
    }

    public override void HandleShipMovement()
    {
        transform.Translate(Vector3.up * ShipVelocity * Time.deltaTime);
    }

    public override void ReciveDamage(float Damage)
    {
        base.ReciveDamage(Damage);
        healthBar.UpdateHealthBar(Damage, maxHealth);
    }
}
