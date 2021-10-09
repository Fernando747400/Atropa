using UnityEngine;

public class Grabbable : MonoBehaviour
{
    private Vector3 initialPosition;
    private Vector3 initialRotation;
    void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation.eulerAngles;
    }

    public void droppObject()
    {
        if (transform.parent != null)
        {
            transform.parent = null;
            transform.position = initialPosition;
            transform.rotation = Quaternion.Euler(initialRotation);
        }
    }
}
