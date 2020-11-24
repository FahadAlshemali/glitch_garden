﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{
   

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        FindObjectOfType<Lives>().TakeLife();
        Destroy(otherCollider.gameObject);

    }
}
