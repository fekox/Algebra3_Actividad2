using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CustomMath;

public class EjerciciosVector3_4 : MonoBehaviour
{
    [SerializeField]
    private Color _color;

    [SerializeField]
    private Vec3 VectorA;

    [SerializeField]
    private Vec3 VectorB;

    private Vec3 VectorC;
    void Update()
    {
        VectorC = Vec3.Cross(VectorA, VectorB);
        VectorC.x *= -1;
        VectorC.z *= -1;

        Debug.DrawLine(new Vec3(0, 0, 0), new Vec3(VectorA.x, VectorA.y, VectorA.z), color: Color.white);
        Debug.DrawLine(new Vec3(0, 0, 0), new Vec3(VectorB.x, VectorB.y, VectorB.z), color: Color.black);
        Debug.DrawLine(new Vec3(0, 0, 0), new Vec3(VectorC.x, VectorC.y, VectorC.z), _color);
    }

    void OnDrawGizmos()
    {
        Handles.Label(new Vec3(VectorA.x + 2, VectorA.y, VectorA.z), "X = " + VectorA.x);
        Handles.Label(new Vec3(VectorA.x + 2, VectorA.y - 2, VectorA.z), "Y = " + VectorA.y);
        Handles.Label(new Vec3(VectorA.x + 2, VectorA.y - 4, VectorA.z), "Z = " + VectorA.z);

        Handles.Label(new Vec3(VectorB.x - 8, VectorB.y, VectorB.z), "X = " + VectorB.x);
        Handles.Label(new Vec3(VectorB.x - 8, VectorB.y - 2, VectorB.z), "Y = " + VectorB.y);
        Handles.Label(new Vec3(VectorB.x - 8, VectorB.y - 4, VectorB.z), "Z = " + VectorB.z);

        Handles.Label(new Vec3(VectorC.x + 2, VectorC.y, VectorC.z), "X = " + VectorC.x);
        Handles.Label(new Vec3(VectorC.x + 2, VectorC.y - 8, VectorC.z), "Y = " + VectorC.y);
        Handles.Label(new Vec3(VectorC.x + 2, VectorC.y - 16, VectorC.z), "Z = " + VectorC.z);

        Handles.Label(new Vec3(2, 0, 0), "X = " + 0);
        Handles.Label(new Vec3(2, -2, 0), "Y = " + 0);
        Handles.Label(new Vec3(2, -4, 0), "Z = " + 0);
    }
}
