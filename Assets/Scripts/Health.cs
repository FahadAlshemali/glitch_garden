using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] GameObject deathVFX;
    [SerializeField] float vFXLifeTime = 1f;
    // Start is called before the first frame update
    
    public void DealDamage(float damage)
    {
        health -= damage;
        if(health <=0)
        {
            DeathTriggerVFX();
            Destroy(gameObject);
        }
    }

    private void DeathTriggerVFX()
    {
        if (!deathVFX) { return; }
        GameObject deathVFXObject = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(deathVFXObject, vFXLifeTime);

    }

}
