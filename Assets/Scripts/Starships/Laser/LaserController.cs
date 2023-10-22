using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    [Header("Laser Status")]
    public float LaserSpeed = 10;
    public float LaserDamage = 10;

    public string TargetCollision = "Player";



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * LaserSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TargetCollision))
        {
            collision.gameObject.GetComponent<StarshipsController>().ReciveDamage(LaserDamage);
            Debug.Log($"{TargetCollision} Recive {LaserDamage}");
            Destroy(transform.gameObject);
        }
    }
}


