using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {
	public float damage = 50f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision){
		collision.gameObject.SendMessage ("Damage", damage, SendMessageOptions.DontRequireReceiver);
	}
}