using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    //Caracteristicas importantes para considerar de una bala es que tiene que tener una velocidad y un tiempo de vida. 
    public float velocidadBala = 10f;
    public float vidaBala = 5f;
    

    //Para trabajar la forma de la bala utilizo boton izquierdo -> Efects -> Trail : Aca modifica la curva de Trail Renderer y mueve el eje hacia los costados , luego le agrega color. Le cambia el material y le pone uno default-line.Le baja el tiempo de duracion .
    void Start()
    {
        //Aca se instancia el metodo de vida de la bala para que se ejecute apenas se crea el objeto.
        Destroy(this.gameObject, vidaBala);
    }

    void Update()
    {
        //Quiero decir que la posicion de la bala sea mas igual desde donde inicia y hacia dnde va transform.forward (que seria hacia adelante ) + multiplicado por la velocidad de la Bala y multiplicado por el tiempo .
        //Hace que cada frame la bala vaya un poco mas adelante.Es decir suma posicion adelante(forward) desde la posicion en la que esta.
        //Luego este script hay que asignarselo al prefab de la bala
        transform.position += transform.forward * velocidadBala * Time.deltaTime;
    }

    //Metodo de Unity para que detectar si la bala colisiona con algo
    private void OnCollisionEnter(Collision collision)
    {
        //Metodo de Unity para si coliciona con algo se va autodestruir
        //Para que la bala puede detectar la colision tiene que tener una propiedad fisica que es le rigidBody se lo agrega desde el inspector y se pone que no use la gravedad.
        Destroy(this.gameObject);  
    }
}
