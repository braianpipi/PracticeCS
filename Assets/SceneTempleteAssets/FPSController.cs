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

    //Esto permite que aparezca un pseudo titulo en el instructor para referenciar un valor que pueda variar
    [Header("Movimiento de Camara")]
    //3 cosas necesito para mover la camara, una referencia hacia donde esta la camara, otra la sensibilidad del mouse y la ultima es hasta donde voy a poder rotar la camara con el mouse. 
    public Transform camTransform;
    //Aca se agrega la variable que va a ir variando desde el inspector
    public float mouseSensitivityX = 2f ;
    public float mouseSensitivityY = 2f;
    //esta variable es para que gire verticalmente el personaje la vision y las variables que son privadas no aparecen en el inspector.
    private float verticalRotation = 0f;



    // Update is called once per frame
    void Update()
    {
        MoverJugador();
        MoverCamaraMousse();
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

    void MoverCamaraMousse()
    {
        //Aca tomamos a traves de comandos preseteados el valor que toman el movimiento del mouse de manera horizontal.
        //float mouseX = Input.GetAxis("Mouse X");
        //Aca tomamos a traves de comandos preseteados el valor que toman el movimiento del mouse de manera vertical.
        //float mouseY = Input.GetAxis("Mouse Y");


        //Aca lo coloco pero ya multiplicado por la sensilibidad que seteamos desde el innspector:
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivityX;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivityY; 


        AplicarRotacion (mouseX, mouseY);



        //Clamp es un método para limitar valores
        //Mathf.Clamp(valor, minimo, maximo);
        //Aca lo puso en menos para que reste al valor y no se pase;
        //verticalRotation -= mouseY;
        //verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);


        //localRotation es una propiedad de Unity muy usada cuando querés controlar la rotación de un objeto respecto a su padre dentro de la jerarquía.
        //Unity internamente usa quaternions para manejar rotaciones (porque son más estables y evitan errores como el gimbal lock). Pero para que sea más cómodo para vos, te deja usar Euler.
        // Euler se refiere a una forma de representar rotaciones en 3D usando tres ángulos: uno para cada eje (X, Y y Z).
        //camTransform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
        //que en Vector3.up lo que hace es que trabaja sobre la linea Y , es decir (0,1,0)
        //transform.Rotate(Vector3.up * mouseX);
    }

    void AplicarRotacion(float horizontal, float vertical)
    {
        verticalRotation -= vertical; //Invierte el mouse
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

        //Rotacion Vertical
        camTransform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

        //Rotacion Horizontal
        transform.Rotate(Vector3.up * horizontal);


    }



}
