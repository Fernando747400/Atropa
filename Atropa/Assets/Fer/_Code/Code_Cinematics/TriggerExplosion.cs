using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerExplosion : MonoBehaviour
{
    public CinematicController cinematics;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player")
        {
            cinematics.explodeHouses();
        }
    }
}