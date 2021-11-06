using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeAnimation : MonoBehaviour
{
    public GameObject pivotPoint;
    private Vector3 position = new Vector3();
    [SerializeField] public float explosionForce = 3f;
    [SerializeField] public float timeToExplode = 2f;
    private float distanceToPivot;
    void Start()
    {
        TestEventManager.current.OnExplodeScene += animateObject;
        distanceToPivot = Vector3.Distance(pivotPoint.transform.position, this.transform.position);
        position = this.transform.position - pivotPoint.transform.position;
        position = position.normalized * (distanceToPivot + explosionForce);
    }

    public void animateObject()
    {
        iTween.MoveTo(this.gameObject, iTween.Hash("position", position, "islocal", true, "time", timeToExplode));
    }
}
