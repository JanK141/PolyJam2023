using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Int Variable", menuName ="Variables/Int")]
public class IntVariable : ScriptableObject
{
    [SerializeField] private int variable;
    private int _value = 0;
    public event Action OnValueChange;

    public int Value
    {
        get => _value;
        set
        {
            _value = value;
            OnValueChange?.Invoke();
        }
    }

    public int OriginalValue => variable;

    public void ResetToOrigin() => _value = variable;

    private void OnValidate() => ResetToOrigin();
}
