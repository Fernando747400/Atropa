using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionAnimator : MonoBehaviour
{
    public GameObject pivotPoint;
    private Vector3 position = new Vector3();
    private Vector3 initialPosition = new Vector3();
    private float explosionForce = 10f;
    private float timeToExplode = 3f;
    private float distanceToPivot;
    void Start()
    {
        CinematicEventSystem.current.OnExplodeScene += animateExplosion;
        CinematicEventSystem.current.OnRollbackScene += rollbackExplosion;
        initialPosition = this.gameObject.transform.position;


        distanceToPivot = Vector3.Distance(pivotPoint.transform.position, this.transform.position);
        position = this.transform.position - pivotPoint.transform.position;
        position = position.normalized * (distanceToPivot + explosionForce);
    }

    public void animateExplosion()
    {
        iTween.MoveTo(this.gameObject, iTween.Hash("position", position, "time", timeToExplode));
    }

    public void rollbackExplosion()
    {
        iTween.MoveTo(this.gameObject, iTween.Hash("position", initialPosition, "time", timeToExplode));
    }

    public void OnEnable()
    {
        CinematicEventSystem.current.OnExplodeScene += animateExplosion;
        CinematicEventSystem.current.OnRollbackScene += rollbackExplosion;
    }

    public void OnDisable()
    {
        CinematicEventSystem.current.OnExplodeScene -= animateExplosion;
        CinematicEventSystem.current.OnRollbackScene -= rollbackExplosion;
    }
}
