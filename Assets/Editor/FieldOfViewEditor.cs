using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(FieldOfView))]
public class FieldOfViewEditor : Editor
{
    float playerAngle;
    FieldOfView fow;
    Transform playerHead;

    void OnSceneGUI()
    {
        fow = (FieldOfView)target;
        playerAngle = fow.playerAngle;
        //playerHead = fow.GetComponent<FieldOfView>().playerHead;
        Handles.color = Color.white;
        Handles.DrawWireArc(fow.transform.position, Vector3.forward, Vector3.right, 360, fow.viewRadius);

        Vector3 viewAngleA = fow.DirFromAngle(-fow.viewAngle / 2 + playerAngle, false);
        Vector3 viewAngleB = fow.DirFromAngle(fow.viewAngle / 2 + playerAngle, false);
        Vector3 viewAngleS = fow.DirFromAngle(playerAngle, false);

        Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleA * fow.viewRadius);
        Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleB * fow.viewRadius);
        Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleS * fow.viewRadius);

        /*
        Handles.color = Color.red;
        foreach(Transform visibleTarget in fow.visibleTargets)
        {
            Handles.DrawLine(fow.transform.position, visibleTarget.position);
        }
        */
    }

}
