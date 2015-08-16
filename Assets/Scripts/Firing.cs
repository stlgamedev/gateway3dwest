using UnityEngine;
using System.Collections;

public class Firing : MonoBehaviour {
	public bool shoot = false;
	private bool isLoaded = true;
	public float reloadTime = 0f;
	public GameObject bullet;
	public GameObject barrel;
	public float speed = 20f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		reloadTime -= Time.deltaTime;
	}

	public void Attacking(bool shot){
		shoot = shot;
		if(shoot && isLoaded){
			GameObject bulletClone = (GameObject) Instantiate(bullet, barrel.transform.position, barrel.transform.rotation);
			bulletClone.GetComponent<Rigidbody>().velocity = barrel.transform.forward * speed;
			reloadTime = 1f;
			isLoaded = false;
		}
		if (reloadTime <= 0) {
			isLoaded = true;
		}
	}
}
