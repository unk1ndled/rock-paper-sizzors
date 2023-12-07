using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistAndObject : MonoBehaviour
{
    public GameObject go;
    public float dist;

    public DistAndObject(GameObject go, float dist) {
        this.dist = dist;
        this.go = go;
    }
    public DistAndObject() { }
}
