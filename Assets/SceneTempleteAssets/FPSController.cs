using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FPSController : MonoBehaviour
{
    //Al ponerlo publico lo puedo modificar desde el inspector del juego subiendo o bajando la velocidad .
    public float speed = 5f;

    // Componente que permite mover el personaje sin usar física real.
    // Usa .Move() para desplazarse y detectar colisiones automáticamente.
    public CharacterController controller;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoverJugador();
    }

    void MoverJugador()
    {
        ////Con el comando imput le pide a traves del metodo GetKey que tecla se apreto y si le pasa que KeyCode es W avance el if o en el caso del UpArrow si toma la flecha hacia arriba.
        //if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        //{
        //    //En el Vector 3 paso las coordenadas en el orden X(de izquierda a derecha), Y (De arriba hacia Abajo), Z(Hacia adelante y Atras).
        //    //Esta línea teletransporta al objeto directamente a la posición (0, 0, 1) en el mundo. position = es un salto y es fijo.
        //    //
        //    //transform.position = new Vector3(0,0,1);
        //    //
        //    //Con el translate te trasladas hacia una posicion nueva 
        //    // Esta línea mueve el objeto desde su posición actual sumando ese vector.Translate() es un paso y es incremental.
        //    transform.Translate(new Vector3(0,0,0.1f));

        //    Debug.Log("Estamos Moviendo el jugador");
        //}
        //if(Input.GetKey(KeyCode.S)) {

        //    transform.Translate(new Vector3(0,0,-0.1f));
        //}

        //Esto interpreta un set de teclas ya estipulados por creacion de metodo de Unity (El cual se puede modificar desde la Interfaz en Edits -> Projects Settings -> Input Manager -> Axes (Aca estan todos los axis con las combinaciones prearmadas- tambien se pueden modificar)
        //Este metodo lee todo los valores estipulados.
        float movX = Input.GetAxis("Horizontal");
        float movY = Input.GetAxis("Vertical");

        //De esta forma se movia pero no tomaba fisicas de colision.
        //transform.Translate(movX,0, movY);

        //Este es el valor para calcular el movimiento :
        Vector3 movimiento = transform.right * movX + transform.forward * movY;
        
        //Con esto el controller se mueve 
        controller.Move(movimiento * speed * Time.deltaTime);
        //Hay que agregarselo desde el sector Inspector al el caractar controller y luego agregar el valor en el script
        //Y agregamos el componente RigidBody desde el inspector tmb. y en la parte que dice Constraints Freeze Position tocar que no rote en el X ni en el eje Z.
        //Para que vaya hacia abajo se pone menos al up. Y para retroseder el menos al forward
        //Vector2 movimiento = -transform.up * movX + -tramsform.forward * movY;

    }
}
