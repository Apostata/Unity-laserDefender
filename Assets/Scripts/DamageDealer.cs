using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
   [SerializeField] float damage = 10;

    public float Damage { get => damage; }

    public void Hit()
    {
        Destroy(gameObject);
    }
}
