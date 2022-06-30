using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincibility : MonoBehaviour
{
    public float invincibilityLength;
    private float invincibilityCounter;

    public void Hurt()
    {
        if (invincibilityCounter <= 0)
        {
            invincibilityCounter = invincibilityLength;
        }

    }

    public void Update()
    {
        if (invincibilityCounter > 0)
        {
            invincibilityCounter -= Time.deltaTime;
        }
    }
}
