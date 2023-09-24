using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixManager : MonoBehaviour
{
    [SerializeField] GameObject[] rings;

    public int noOfRings = 10;

    public float ringDistance = 5f;

    private float yPos;

    private void Start()
    {
        for (int i = 0; i < noOfRings; i++)
        {
            if (i==0)
            {
                SpawnRing(0);
            }

            else
            {
                SpawnRing(Random.Range(1,rings.Length-1));
            }
        }

        //LevelComplete Ring Spawn
        SpawnRing(rings.Length - 1);
    }

    public void SpawnRing(int index)
    {
        GameObject newRing = Instantiate(rings[index],new Vector3(transform.position.x,yPos,transform.position.z),Quaternion.identity);

        yPos -= ringDistance;

        newRing.transform.parent = transform;
    }
}
