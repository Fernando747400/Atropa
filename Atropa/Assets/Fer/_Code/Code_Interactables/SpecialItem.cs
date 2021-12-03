using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialItem : MonoBehaviour
{
    public void useSpecialItem()
    {
        ProgressManager.current.foundObjects++;
        print(this.transform.parent.name + " " +ProgressManager.current.foundObjects.ToString());
        Destroy(this);
    }
}
