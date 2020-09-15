using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    public List<GameObject> obstacleTypes;

    private readonly Vector3[] dirs = {new Vector3(-5,0,0),new Vector3(0,0,0),new Vector3(5,0,0)};
    private int id;

    void Awake()
    {
        //Generating Random obstacle from pool
        int randInd = Random.Range(0, obstacleTypes.Count);
        if (obstacleTypes[randInd] != null)
        {
            GameObject clone = obstacleTypes[randInd];
            if (clone != null && clone.CompareTag("H_Defender") && GetComponentInParent<Set>().getHeavies() == 3)
            {
                while(!clone.CompareTag("H_Defender"))
                {
                    randInd = Random.Range(0, obstacleTypes.Count);
                    clone = obstacleTypes[randInd];
                }
            }
            Instantiate(clone, new Vector3(transform.position.x, clone.transform.position.y, transform.position.z), clone.transform.rotation, transform);
        }
    }

    public void Init(Vector3 pos, int id)
    {
        //Setting location
        transform.localPosition = pos;
        this.id = id;
    }
}
