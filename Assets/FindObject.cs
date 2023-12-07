using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindObject : MonoBehaviour
{
    public Dictionary<GameObject, float> FindClosestEnemy(string targetName)
    {
        
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag(targetName);
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        Dictionary<GameObject, float> closestWithDistance = new Dictionary<GameObject, float>() { { closest, distance } };
        return closestWithDistance;
    }
}
