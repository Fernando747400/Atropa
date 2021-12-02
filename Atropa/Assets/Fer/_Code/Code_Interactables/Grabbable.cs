using UnityEngine;

public class Grabbable : MonoBehaviour
{
    private Vector3 initialPosition;
    private Vector3 initialRotation;
    private GameObject initialParent;
    void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation.eulerAngles;
        initialParent = this.transform.parent.gameObject;
    }

    public void droppObject()
    {
        if (transform.parent != null)
        {
            transform.parent = initialParent.transform;
            transform.position = initialPosition;
            transform.rotation = Quaternion.Euler(initialRotation);
        }
    }
}
