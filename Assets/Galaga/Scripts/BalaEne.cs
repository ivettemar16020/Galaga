using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaEne : MonoBehaviour {

	//Instanciar
	public float velBala;
	public float limite;

	void FixedUpdate(){
		//Movimiento de la bala hacia arriba
		transform.Translate(Vector2.down * velBala);
		// si la bala sobrepasa el limite vertical desactiva el gameObject
		if(transform.position.y >= limite){
			gameObject.SetActive(false);
		}
	}
}
