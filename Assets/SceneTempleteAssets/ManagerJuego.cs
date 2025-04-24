using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Para un singleton se necesita:
//- Que controle un ciclo de vida
//- No debe permitir mas de una instancia
//- Deber ser accesible globalmente.(Para que sea accesible globalmente usamos la palabra Static)

//Atributos "STATICS"
//- Son miembros estaticos y globales.
//- Se pueden acceder desde cualquier clase
//- Hacen que no es necesaria una instancia para utilizar el elemento .
//- Una clase estatica indica que se puede acceder desde cualquier lugar.
//- Un atributo estatico significa que su valor va a ser el mismo para todas las instancias de la clase.
//- Un metodo estatico signifca que se puede usar sin la necesidad de que exista la instancia de la clase que lo contiene.

public class ManagerJuego : MonoBehaviour
{
    //Creamos una copia de la Clase y con el "instancia" le decimos que esta copia va a ser unica.
    public static ManagerJuego instancia;

    //El metodo awake se llama antes que el start.
    private void Awake()
    {
        if (instancia == null)
        {
            //Si sos nulo, va a convertirte en la nueva copia.
            instancia = this;
            //
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            //Si ya existe, se destruye.
            Destroy(this);
        }
    }
    void Start()
    {
        
    }

}
