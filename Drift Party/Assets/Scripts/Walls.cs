using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour
{
    public GameObject Teleportlocation;
    public void OnTriggerEnter(Collider col)
    {
        col.transform.position = Teleportlocation.transform.position;
    }
}
