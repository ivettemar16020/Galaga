using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estrella : MonoBehaviour {

	//Instanciar variables
	public float velMin, velMax;
	public float limite;  

	float velocidad; 

	void Awake(){
		//Velocidad aleatoria para las estrellas
		velocidad = Random.Range(velMin, velMax);
	}

	void FixedUpdate(){
		transform.Translate(Vector2.down * velocidad);

		//limite en pantalla, para que se puedan reutilizar
		if(transform.position.y <= limite)
		{
			gameObject.SetActive(false);
		}
	}
	//Se ejecuta una vez siempre y cuando el GameObject se desactiva
	void onDisable(){
		velocidad = Random.Range(velMin, velMax);
	}
}
