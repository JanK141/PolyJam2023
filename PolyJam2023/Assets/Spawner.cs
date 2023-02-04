using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn;

    private void Start()
    {
        Instantiate(objectToSpawn, gameObject.transform);
    }
}
