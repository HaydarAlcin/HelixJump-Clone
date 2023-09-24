using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    private Transform _player;

    [SerializeField] List<GameObject> childRings;

    private float _radius = 100f;
    private float _force = 400f;

    private void Start()
    {
        _player=GameObject.FindGameObjectWithTag("Player").transform;

        //for (int i = 0; i < 8; i++)
        //{
        //    childRings[i] = transform.GetChild(i).gameObject;
        //}
    }

    private void Update()
    {
        if (transform.position.y>_player.position.y+0.2f) 
        {
            for (int i = 0; i < childRings.Count; i++)
            {
                childRings[i].GetComponent<Rigidbody>().isKinematic = false;
                childRings[i].GetComponent<Rigidbody>().useGravity = true;

                Collider[] colliders = Physics.OverlapSphere(transform.position, _radius);

                foreach (Collider newCollider in colliders)
                {
                    Rigidbody rb = newCollider.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        rb.AddExplosionForce(_force, transform.position, _radius);
                    }
                }
                childRings[i].transform.parent = null;
                Destroy(childRings[i].gameObject,2f);
            }
            this.enabled = false;
        }
    }
}
