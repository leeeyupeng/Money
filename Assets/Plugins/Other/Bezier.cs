using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bezier
{
    Vector3 PointOnLineBezier(Vector3[] p,float t)
    {
        return (1 - t) * p [0] + t * p [1];
    }
    Vector3 PointOnSquareBezier(Vector3[] p,float t)
    {
        return (1 - t) * (1 - t) * p[0] + 2 * t * (1 - t) * p[1] + t * t * p[2];
    }
    Vector3 PointOnNBezier(Vector3[] p,float t)
    {
		return Vector3.zero;
    }
    Vector3 PointOnNBezier(List<Vector3> p,float t)
    {
        if (p.Count == 2)
            return PointOnLineBezier (p.ToArray(),t);
        if (p.Count == 3)
            return PointOnSquareBezier (p.ToArray (), t);

//        Vector3 v = p [p.Count - 1];
//        p.Remove ();
		return Vector3.zero;
    }
}
