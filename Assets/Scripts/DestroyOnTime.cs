using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTime : MonoBehaviour
{
    public float TempoEmTela;


    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, TempoEmTela);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
