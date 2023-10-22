using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private Slider healthBar;

    public void UpdateHealthBar(float current, float max)
    {
        healthBar.value = current / max;
    }
}
