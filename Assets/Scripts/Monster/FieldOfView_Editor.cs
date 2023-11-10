using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(FieldOfView))]
public class FieldOfView_Editor : Editor
{
    private void OnSceneGUI()
    {
        FieldOfView fov = (FieldOfView)target;
        Handles.color = Color.red;
        Handles.DrawWireArc(fov.transform.position, Vector3.up, Vector3.forward, 360, fov.viewRadius, 2);
        
        
        
        
        
        Vector3 viewAngleA = new Vector3(Mathf.Sin( -fov.viewAngle  * Mathf.Deg2Rad), 0, Mathf.Cos(-fov.viewAngle  * Mathf.Deg2Rad));
        Vector3 viewAngleB = new Vector3(Mathf.Sin( fov.viewAngle  * Mathf.Deg2Rad), 0, Mathf.Cos(fov.viewAngle  * Mathf.Deg2Rad));
        // readme에 참조한 그림처럼 양 옆 끝 direction vector를 가져온다.
        
        // 이제 구해온 viewAngle값들에 viewRadius 를 곱해주어서 그린다
        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngleB * fov.viewRadius,2 );
        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngleA * fov.viewRadius ,2);

        
    }
}
