using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatableData : ScriptableObject
{
    internal event System.Action OnValuesUpdated;
    internal bool AutoUpdate = true;

#if UNITY_EDITOR

    protected virtual void OnValidate()
    {
        if (AutoUpdate)
            UnityEditor.EditorApplication.update += NotifyOfUpdatedValues;
    }

    public void NotifyOfUpdatedValues()
    {
        UnityEditor.EditorApplication.update -= NotifyOfUpdatedValues;
        if (OnValuesUpdated != null)
            OnValuesUpdated();
    }

#endif
}
