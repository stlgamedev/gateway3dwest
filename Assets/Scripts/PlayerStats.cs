using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerStats : Stats {

	public Slider healthSlider;
	public Slider staminaSlider;
	public Slider manaSlider;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	protected override void FixedUpdate () {
		base.FixedUpdate ();
	}

	public override void Damage (float damage){
		base.Damage (damage);
		healthSlider.value = health;
	}

	public override bool SpellCast(float depletion){
		bool ret = base.SpellCast (depletion);
		manaSlider.value = mana;
		return ret;
	}

	public override void StaminaUse(float fatigue){
		base.StaminaUse (fatigue);
		staminaSlider.value = stamina;
	}
}
