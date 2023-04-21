using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomMath;
using Unity.VisualScripting;
using System.Numerics;
using System.Runtime.ConstrainedExecution;

public class Activity_Planes 
{
    //Plane toSeeTheFunctions;
    //Vector3 a;

    //Cuando la locura gana la batalla: https://github.com/Unity-Technologies/UnityCsReference/blob/master/Runtime/Export/Geometry/Plane.cs

    public struct MrPlane 
    {
        private Vec3 var_Normal;

        private float var_Distance;

        public Vec3 normal //Retorna el vector normal de un plano.
        {
            get { return var_Normal; }

            set { var_Normal = value; }
        }

        public float distance //Retorna la distancia medida desde el plano hasta el origen, a lo largo de la normal del Plano.
        {
            get { return var_Distance; }

            set { var_Distance = value; }
        }

        //Retorna una copia del plano con sus caras en la direccion opuesta.
        public MrPlane flipped 
        {
            get 
            { 
                return new MrPlane(-var_Normal, -var_Distance); 
            }
        } 


        //Crear un Plano: https://docs.unity3d.com/ScriptReference/Plane-ctor.html


        public MrPlane(Vec3 inNormal, Vec3 inPoint) //Crea un plano en base a una normal y un punto.
        {
            var_Normal = Vec3.Normalize(inNormal); //La normal se normaliza.
            var_Distance = 0f - Vec3.Dot(var_Normal, inPoint); //La distancia es igual al producto punto entre la normal y el punto del vec3.
        }

        public MrPlane(Vec3 inNormal, float d) //Crea un plano en base a una normal y un float.
        {
            var_Normal = Vec3.Normalize(inNormal); //La normal se normaliza.
            var_Distance = d; //La distacia es igual al float (la distancia se mide desde el Plano hasta el origen, a lo largo de la normal del Plano.). 
        }

        public MrPlane(Vec3 a, Vec3 b, Vec3 c) //Crea un plano en base a 3 vec3.
        {
            var_Normal = Vec3.Normalize(Vec3.Cross(b - a, c - a)); //La normal es igual al producto cruz de los 3 vectores normalizado.
            var_Distance = 0f - Vec3.Dot(var_Normal, a); //La distancia es igual al producto punto de la normal y a.
        }


        //https://docs.unity3d.com/ScriptReference/Plane.ClosestPointOnPlane.html
        public Vec3 ClosestPointOnPlane(Vec3 point) //Retorna un punto en el plano que est� m�s cerca del punto dado.
        {
            var num = Vec3.Dot(var_Normal, point) + var_Distance; //Obtenes la distancia a la que se encuentra el punto del plano.
            return point - (var_Normal * num); //Retorna el punto dentro del plano que se encuentra mas cerca del punto que le dimos.
        }

        public void Flip() //Hace que el plano mire en la direccion opuesta.
        {
            var_Normal = -var_Normal;
            var_Distance = -var_Distance;
        }


        //https://docs.unity3d.com/ScriptReference/Plane.GetDistanceToPoint.html
        public float GetDistanceToPoint(Vec3 point) //Retorna una distancia desde el plano hasta el punto dado.
        {
            return Vec3.Dot(var_Normal, point) + var_Distance; //Obtenes la distancia a la que se encuentra el punto del plano.
        }


        //https://docs.unity3d.com/ScriptReference/Plane.GetSide.html
        public bool GetSide(Vec3 point) //Retorna si un punto se encuentra dentor del lado positivo del plano o no.
        {
            return Vec3.Dot(var_Normal, point) + var_Distance > 0.0f; //Si el resultado del producto punto mas la distancia es mayor a zero retorna true
                                                                      //(ya que se encuentra dentro del lado positivo), sino retorna false.
        }


        public bool SameSide(Vec3 inPt0, Vec3 inPt1) //Retorna si dos puntos se encuentran del mismo lado del plano.
        {
            var distanceToPoint0 = GetDistanceToPoint(inPt0); //Calculo la distancia al punto 0;
            var distanceToPoint1 = GetDistanceToPoint(inPt1); //Calculo la distancia al punto 1;

            if (distanceToPoint0 >= 0.0f && distanceToPoint1 >= 0.0f) //Si la distancia de los dos puntos es mayor o igual a zero retorno true;
            {
                return true;
            }

            else //Si no retorno false.
            {
                return false;
            }
        }

    }
}
