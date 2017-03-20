using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ControlJug : MonoBehaviour {

	// Instanciar objetos a utilizar
	public GameObject balaPrefab; //Bala del jugador
	public float velocidad; //Velocidad del jugador
	public int vida; //Vida del jugador
	//public int damaged; //Daño que causa la bala
	public int cantBalas;
	public Transform canon;

	Rigidbody2D rb2D;
	Vector2 mov; 
	bool vivo; //Pregunta si sigue con vida
	//Se creara una coleccion de las balas para no malgastar memoria RAM,
	//Cuando la bala haya recorrido la pantalla, se debe volver a agregar a la coleccion 
	GameObject[] balas;

	void Awake(){
		rb2D = GetComponent<Rigidbody2D>();
		balas = new GameObject[cantBalas];

		for(int i = 0; i<balas.Length; i++){
			balas[i] = (GameObject) Instantiate(balaPrefab);
			balas[i].SetActive(false);
		}
	}

	//Constantemente chequea si se presionaron las teclas
	void Update(){
		//Verificar si esta vivo
		if (vida > 0){
			vivo = true;
		}
		else 
		{
			vivo = false; 
		}

		//Si esta muerto regresa y no sigue ejecutando lo que sigue en el codigo
		if(!vivo) return; 

		mov = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

		if(Input.GetButtonDown("Jump")){
			Disparar();

		if(Input.GetKey(KeyCode.R)) {
           //Se reinicia el juego al presionar la tecla R
           SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
		}
	}
	//Aqui se colocaran todos los objetos que se muevan 
	//Esta funcion se ejecuta en una frecuencia constante
	void FixedUpdate(){
		transform.Translate(mov * velocidad);
		Limites();
	}

	//Funcion que define los limites de moviimiento del jugadore
	void Limites(){
		Vector2 posLimit = transform.position;
		posLimit.x = Mathf.Clamp(posLimit.x, -18.5f , 18.5f); //Agarra el valor de x y lo limita a lo que se le indica
		posLimit.y = Mathf.Clamp(posLimit.y, -10, 10);

		transform.position = posLimit;
	}

	//Funcion que se encarga del disparo de balas
	void Disparar(){
		for(int i = 0; i<balas.Length; i++){
			//Pregunta si la bala esta desactivada
			if(!balas[i].activeInHierarchy){
				balas[i].SetActive(true);
				balas[i].transform.position = canon.position;
				break;
			}
		}
	}
	//Que sucede cuando la nave toca a los enemigos
    void OnTriggerEnter2D(Collider2D obj){
    	var name = obj.gameObject.name;

    	if (name.Contains("Enemy")){
    		vida = vida -1; 
    		GameObject cantVidas = GameObject.Find("Vida");
            cantVidas.GetComponent<TextMesh>().text = "" + vida;
            if (vida <= 0){
            	cantVidas.GetComponent<TextMesh>().text = "PERDISTE";
            }
    	}
    }

}
