using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{

    public Rigidbody rb;
    public Transform parent;
    public float destroyDelay = 4f;
    public GameObject fallingPlatformPrefab;
    private bool isFalling = false;

    private Vector3 spawnPos;
    private Quaternion spawnRotation;

    private void Start()
    {
        rb.useGravity = false;
        rb.isKinematic = true;
        isFalling = false;
        spawnPos = transform.position;
        spawnRotation = transform.rotation;
    }

    private void Fall()
    {
        isFalling = true;
        rb.isKinematic = false;
        rb.useGravity = true;
        Invoke("SpawnPlatform", destroyDelay);
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (!isFalling)
            {
                Fall();
            }
        }
    }

    void SpawnPlatform()
    {
        var obj = Instantiate(fallingPlatformPrefab);
        obj.transform.parent = parent;
        obj.transform.position = spawnPos;
        obj.transform.rotation = spawnRotation;
        GameObject.Destroy(gameObject);
    }
}