using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TestEventManager.current.OnExplodeScene += animateObject;
    }

    public void animateObject()
    {
        Vector3 position = new Vector3(this.transform.position.x * 2, this.transform.position.y * 5, this.transform.position.z * 6);
        iTween.MoveTo(this.gameObject, iTween.Hash("position", position, "islocal", true, "time", 2f));
    }
}
