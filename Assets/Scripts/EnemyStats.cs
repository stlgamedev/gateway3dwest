using UnityEngine;
using System.Collections;

public class EnemyStats : Stats {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	protected override void FixedUpdate () {
		base.FixedUpdate ();
	}

	public override void Damage(float damage){
		base.Damage (damage);
	}

	public override bool SpellCast(float depletion){
		bool ret =base.SpellCast (depletion);
		return ret;
	}

	public override void StaminaUse(float fatigue){
		base.StaminaUse (fatigue);
	}
}
