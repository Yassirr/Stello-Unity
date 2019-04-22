using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
    public static int deaths = 0;
	//this is VFX that spawns everytime player respawns (after death, or when entering new level)
	public GameObject PlayerStartFx;

	//those 2 VFX are attached to the player to constantly spawn particles, its a small detail.
	public GameObject playerConstantFX;
	public GameObject playerConstantFX2;

	//this is object in the scene which determines where player will spawn
	GameObject playerStartObject;

	//this is to check if player is present in the scene
	bool playerLocation;

	//this is simple VFX, it spawns everytime when player dies
	public GameObject deathFX;
    public Text countText;
    public int count;

	void Start () 
	{
		playerLocation = true;
		playerStartObject = GameObject.FindGameObjectWithTag("playerStart");
        ScreenWidth = Screen.width;
        count = 0;
        SetCountText();
	}

	void FixedUpdate () 
	{
		if(playerLocation == true)
		{
			//if player goes below screen it will count as death and player will spawn again, you can change value -6 
			if(gameObject.transform.position.y <= -6)
			{
				gameObject.GetComponent<TrailRenderer>().enabled = false;
				Invoke("playerStartFunction",1f);
				playerLocation = false;
                count = count + 1;
                SetCountText();
            }
		}
	}

	//this is function which disables all VFX attached to player upon death
	void playerTouchedenemy()
	{
		gameObject.GetComponent<TrailRenderer>().enabled = false;
		Invoke("playerStartFunction",1f);
		playerLocation = false;
	}

	//this enables all VFX when player being spawn, usally after death
	void playerStartFunction()
	{
		gameObject.GetComponent<TrailRenderer>().enabled = true;
		gameObject.transform.position = playerStartObject.transform.position;
		Instantiate(PlayerStartFx,playerStartObject.transform.position,Quaternion.identity);
		playerLocation = true;
	}

	//colliders
	void OnTriggerEnter(Collider other)
	{
		//this is being executed when player collide with "portal" tag which is entrance to next level
		if(other.gameObject.tag == "portal")
		{
			gameObject.GetComponent<Collider>().enabled = false;
			gameObject.GetComponent<Renderer>().enabled = false;
			gameObject.GetComponent<Rigidbody>().isKinematic = true;
			gameObject.GetComponent<Rigidbody>().useGravity = false;
			gameObject.GetComponent<TrailRenderer>().time = 0;
			//playerConstantFX.GetComponent<ParticleSystem>().emissionRate = 0;
			playerConstantFX2.SetActive(false);
		}

		//this is executed when player collide will enemy with "spiky" tag 
		if(other.gameObject.tag == "spiky")
		{
			Instantiate(deathFX,gameObject.transform.position,Quaternion.identity);
			gameObject.GetComponent<TrailRenderer>().enabled = false;
			gameObject.transform.position = new Vector3 (0,100,0);
			Invoke("playerStartFunction",1f);
            count = count + 1;
            SetCountText();

        }
	}

    //this function is responsible for player bounce off the floor, you can change 2000 value to whatever you want
    void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.tag == "Floor")
		{
				GetComponent<Rigidbody>().AddForce(0,2000 * Time.deltaTime,0);
		}

	}

    void SetCountText()
    {
        countText.text = "" + count.ToString ();
    }

    private float ScreenWidth;

	//these are simple controls for both Touch Screen and keyboard
	void Update()
	{
        int i = 0;
        //loop over every touch found
        while(i < Input.touchCount)
        {
            if (Input.GetTouch(i).position.x > ScreenWidth / 2)
            {
                GetComponent<Rigidbody>().AddForce(new Vector3(50f * Time.deltaTime, 0, 0));
            }
            if (Input.GetTouch(i).position.x < ScreenWidth / 2)
            {
                GetComponent<Rigidbody>().AddForce(-50f * Time.deltaTime, 0, 0);
            }
            ++i;
        }


		if (Input.GetKey(KeyCode.LeftArrow))
		{
			GetComponent<Rigidbody>().AddForce(-50f * Time.deltaTime,0,0);
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			GetComponent<Rigidbody>().AddForce(new Vector3(50f * Time.deltaTime,0,0));
		}
	}

}
