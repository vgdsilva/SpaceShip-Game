using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StarshipsLaserController : MonoBehaviour
{
    public float LaserSpeed;
    public float LaserDamage = 10;

    public abstract void HandleHitDamage(Collider2D collision, float Damage);

    void Start()
    {
        
    }

    void Update()
    {
        HandleLaserMovement();
    }

    void HandleLaserMovement()
    {
        transform.Translate(Vector3.up * LaserSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HandleHitDamage(collision, LaserDamage);
        Destroy(this.gameObject);
    }
}
