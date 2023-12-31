using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float bounceForce=200f;
    [SerializeField] GameObject splashPrefab;

    AudioManager audioManager;

    private void Start()
    {
        audioManager=GameObject.FindObjectOfType<AudioManager>();
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (GameManager.gameOver == false || GameManager.levelComplete == false)
        {
            audioManager.Play("Land");
        }

        rb.velocity = new Vector3(rb.velocity.x, bounceForce * Time.deltaTime, rb.velocity.z);
        

        GameObject newSplash = Instantiate(splashPrefab,new Vector3(transform.position.x, collision.transform.position.y+ 0.185f, transform.position.z), Quaternion.Euler(90,0,0));

        newSplash.transform.localScale= Vector3.one*Random.Range(0.4f,1.3f);
        newSplash.transform.parent = collision.transform;

        string materialName=collision.gameObject.GetComponent<MeshRenderer>().material.name;

        if (materialName == "UnSafe (Instance)")
        {
            GameManager.gameOver = true;
            audioManager.Play("GameOver");
            
        }

        if (materialName == "LastRing (Instance)" && !GameManager.levelComplete)
        {
            GameManager.levelComplete = true;
            audioManager.Play("LevelWin");
            
        }

    }
}
