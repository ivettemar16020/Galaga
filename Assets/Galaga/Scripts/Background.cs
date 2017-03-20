using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {

	//Inicializar variables
	public float minX;
	public float maxX; 
	public GameObject PrefabStar;
	public int cantStar; 

	Vector2 posEstrella; 
	GameObject[] estrellas; 

	void Awake(){

		estrellas = new GameObject[cantStar];

		for(int i = 0; i < estrellas.Length; i++){
			estrellas[i] = (GameObject) Instantiate(PrefabStar);
			estrellas[i].SetActive(false);
		}
		//Param(nomnreDeLaFuncion en string, tiempo, rangoDeRepeticion)
		InvokeRepeating("ActEstrellas", 1, 0.1f);
	}

	//Se debe ejecutar esta funcion en una frecuencia fija
	void ActEstrellas(){
		//Vector que tiene posicion aleatoria en el eje x y la misma en el eje y
		posEstrella = new Vector2(Random.Range(minX, maxX), transform.position.y);
		for(int i = 0; i<estrellas.Length; i++){
			if(!estrellas[i].activeInHierarchy){
				estrellas[i].SetActive(true);
				estrellas[i].transform.position = posEstrella;
				break;			
			}
		}
	}

}
