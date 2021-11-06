using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionAnimator : MonoBehaviour
{
    public GameObject pivotPoint;
    private Vector3 position = new Vector3();
    private Vector3 initialPosition = new Vector3();
    [SerializeField] public float explosionForce = 3f;
    [SerializeField] public float timeToExplode = 2f;
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
        iTween.MoveTo(this.gameObject, iTween.Hash("position", position, "islocal", true, "time", timeToExplode));
    }

    public void rollbackExplosion()
    {
        iTween.MoveTo(this.gameObject, iTween.Hash("position", initialPosition, "islocal", true, "time", timeToExplode));
    }
}
