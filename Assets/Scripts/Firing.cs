using UnityEngine;
using System.Collections;

public class Firing : MonoBehaviour {
	public GameObject bullet;
	public GameObject barrel;
	public float speed = 20f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxis("Strike") > 0){
			GameObject bulletClone = (GameObject) Instantiate(bullet, barrel.transform.position, barrel.transform.rotation);
			bulletClone.GetComponent<Rigidbody>().velocity = barrel.transform.forward * speed;
		}
	}
}
