using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Amerike/Variables/Bool")]
public class BoolVariable : ScriptableObject
{
    public string VariableDescription;
    public bool Value;

    public void SetValue(bool value)
    {
        Value = value;
    }
}
