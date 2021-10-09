using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Amerike/Variables/Float")]
public class FloatVariable : ScriptableObject
{
    public string VariableDescription;
    public float Value;

    public void SetValue(float value)
    {
        Value = value;
    }
}
