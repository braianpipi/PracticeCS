using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//MonoBehaviour es la clase base de Unity para los scripts que controlan el comportamiento de los objetos en la escena. Permite acceder al ciclo de vida del juego, como Start(), Update(), y eventos de física. Todos los scripts en C# que interactúan con GameObjects deben heredar de MonoBehaviour para utilizar funciones como Instantiate(), Destroy(), y manejar Coroutines.

public class TEST : MonoBehaviour
{

    //private void Awake()
    //{
    //El método Awake() se ejecuta una sola vez cuando el script se carga por primera vez, antes de que empiece el juego y antes del método Start(). Se usa para inicializar variables o estados que no dependen de otros objetos.Es ideal para configuraciones internas del propio componente.
    //}

    //Tipo de Variables
    //GameObject object;
    //Rigidbody rb;(Manejo de Fisicas)
    //Transform t;
    //ParticleSystem particulas; (Me imagino que viene por el lado del polled)


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Evitar utilizar cuestiones relacionadas a las fisicas

    }
    private void FixedUpdate()
    {
        
    }
}
