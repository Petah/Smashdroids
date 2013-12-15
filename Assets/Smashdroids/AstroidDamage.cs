using UnityEngine;
using System.Collections;

public class AstroidDamage : MonoBehaviour {
	
	private float health = 20;
		
	public void Update () {
		if (health < 0) {
			Destroy(gameObject);
		}
	}
		
	public void Damage(float damage) {
		health -= damage;
	}
		
}
