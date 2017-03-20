using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	int punteo;
	//Funcion que se ecarga de matar a los enemigos cuando la bala los toca
    void OnTriggerEnter2D(Collider2D obj){
    	var name = obj.gameObject.name;

    	if (name.Contains("bala(Clone)")){
    		Destroy(gameObject);
    		obj.gameObject.SetActive(false);
            punteo = punteo + 10;
    		GameObject puntos = GameObject.Find("Score");
            puntos.GetComponent<TextMesh>().text = "Score: " + punteo;
           
            }
   	}
}
