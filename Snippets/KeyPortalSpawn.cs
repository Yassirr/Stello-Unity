using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPortalSpawn : MonoBehaviour {

    public GameObject myObject;
    public GameObject imgObject;

    void OnTriggerEnter(Collider entity)
    {
        if (entity.tag == "Player")
        {
            myObject.SetActive(true);
            imgObject.SetActive(true);
        }
        else
        {
            myObject.SetActive(false);
            imgObject.SetActive(false);
        }
    }
}
