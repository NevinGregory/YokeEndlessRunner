using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudienceSpawn : MonoBehaviour
{
    public GameObject[] spawnableAudience;
    public int rot;
    void Start()
    {
        Instantiate(spawnableAudience[Random.Range(0, spawnableAudience.Length)], transform.position, Quaternion.Euler(0,rot,0), transform);
    }
}
