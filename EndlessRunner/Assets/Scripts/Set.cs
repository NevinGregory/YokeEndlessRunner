using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set : MonoBehaviour
{
    public List<Obstacle> obstacles = new List<Obstacle>();
    public GameObject obstaclePrefab;

    public int speed;
    private int numHeavies, id;

    private void Awake()
    {
        id = 1;
        transform.position = new Vector3(0, 0, 150);

        for (int i = -5; i <= 5; i+=5) {
            GameObject ob = Instantiate(obstaclePrefab, transform) as GameObject;
            obstacles.Add(ob.GetComponent<Obstacle>());
            ob.GetComponent<Obstacle>().Init(new Vector3(i, 0, 0), id);
            id++;
        }
    }

    private void Update()
    {
        transform.Translate(0, 0, -speed * Time.deltaTime);
    }

    public void newHeavy()
    {
        numHeavies++;
    }

    public int getHeavies()
    {
        return numHeavies;
    }
}
