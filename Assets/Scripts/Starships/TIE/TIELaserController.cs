using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TIELaserController : StarshipsLaserController
{

    public override void HandleHitDamage(Collider2D collision, float Damage)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<StarshipsController>().ReciveDamage(Damage);
            
        }
    }

}
