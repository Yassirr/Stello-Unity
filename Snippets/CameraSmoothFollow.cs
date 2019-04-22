using UnityEngine;
using System.Collections;

public class CameraSmoothFollow : MonoBehaviour {

	//This script is responsible for following player during gameplay
	//target - is the target prefab that camera will follow
	//this script assigns prefab with player tag automaticly 

	Transform target;
	public float smoothing = 5f;
	bool findPlayer = false;
	public float distance;
	public float height;


	
	void Start()
	{
		Invoke("PlayerFound",1.1f);
	}

	void FixedUpdate()
	{
		if (findPlayer == true)
		{
			target = GameObject.FindGameObjectWithTag ("Player").transform;
			transform.position = Vector3.Lerp (transform.position, new Vector3(target.position.x,height,distance),smoothing * Time.deltaTime);
		}

	}

	void PlayerFound()
	{
		findPlayer = true;
	}
}
