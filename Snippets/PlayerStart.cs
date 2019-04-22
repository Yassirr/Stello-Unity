using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerStart : MonoBehaviour {

	//This script is responsible for spawning (instatiating) player prefab to the scene with few VFX after 1 second.

	public GameObject Player;
	public GameObject PlayerStartFx;

	// Use this for initialization
	void Start () 
	{
		Invoke("PlayerStartFunction",1f);
	}

	void PlayerStartFunction()
	{
        Instantiate(PlayerStartFx, transform.position, Quaternion.identity);
        Instantiate(Player, transform.position, Quaternion.identity);
    }


}
