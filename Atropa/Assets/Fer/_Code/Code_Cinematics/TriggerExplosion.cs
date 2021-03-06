using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerExplosion : MonoBehaviour
{
    public CinematicController cinematics;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            cinematics.explodeHouses();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
