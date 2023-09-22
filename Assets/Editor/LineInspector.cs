using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CurvedRoad))]
public class LineInspector : Editor
{
    private void OnSceneGUI()
    {
        CurvedRoad road = (CurvedRoad)target;
        Transform handleTransforms = road.transform;
        Quaternion handleRotations = Tools.pivotRotation == PivotRotation.Local ?
            handleTransforms.rotation : Quaternion.identity;
        Vector3 p0 = handleTransforms.TransformPoint(road.p0);
        Vector3 p1 = handleTransforms.TransformPoint(road.p1);
        Handles.color = Color.white;
        Handles.DrawLine(p0,p1);
        Handles.DoPositionHandle(p0, handleRotations);
        Handles.DoPositionHandle(p1, handleRotations);
    }
}
