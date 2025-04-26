using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Shoot : MonoBehaviour
{
    //Es una variable tipo GameObject que guarda una referencia a ese prefab para poder crear instancias de él en tiempo de ejecución, es decir que pueda clonar a traves de codigo .
    public GameObject prefabBala;
    // "voy a arrastrar desde la escena un objeto (por ejemplo un Empty GameObject) que me sirva como punto de referencia para saber dónde instanciar o mover otros objetos."
    public Transform spawnPoint;

    private void Update()
    {
        //Input.GetMouseButtonDown(0)Es una función que se usa para detectar cuándo el usuario hace clic con el mouse, justo en el momento en que presiona el botón.El boton cero en el mouse es el click izquierdo.
        if (Input.GetMouseButtonDown(0))
        {
            //Este metodo lo que haces es crear la bala en el punto exacto DESDE DONDE la voy a disparar
            DispararBala();

            //Aca se agrega el singleton de sonido
            //Se instancia el singleton y en el PlaySound se pasan los parametros (el tipo de sonido , el volumen)
            SoundManager.instance.PlaySound(SoundType.DISPARO_1, 2f);
        }


        void DispararBala()
        {
            //Aca voy a pedir que la bala se instancie y se genere una copia, es decir duplicame un objeto en un lugar especifico y con una rotacion especifica.
            //Instantiate(objetoOriginal); // Solo clona el objeto
            //Instantiate(objetoOriginal, posicion, rotacion); // Clona en un lugar específico
            //Es decir cuando ejecuto el intantiate me crea la bala en el punto que le digo y con la rotacion .
            //Instantiate(prefabBala, spawnPoint.position, spawnPoint.rotation);

            //En el inspector se agrega un objeto vacio(ObjectEmpty) a la camara con el nombre spawnpoint y se lo coloca un poco por delante del player. Desde aca es de donde saldrian las balas.En el mismo inspector se le adjudica el objeto vacio al spawnpoint solicitado en el inspector .
            // Creo la bala en el inspector en objeto 3D, creo una carpeta Prefab, cargo la bala ahi , la borro de la scena y despues la cargo en el inspector donde pide el elemento el script shoot.

            //Vamos a utilizar el metodo pool de objetos
            //Para esto solo le decimos al pool que las active
            //¡Implementacion del pool de objetos!
            GameObject objeto = ObjectPooler.SharedInstance.GetPooledObject(ObjectType.Bala);
            objeto.transform.position = spawnPoint.position;
            objeto.transform.rotation = spawnPoint.rotation;
            //
            objeto.SetActive(true);

            //Si activamos el Should Expand en el inspector permite que se generen mas objetos una vez alcanzado el limite del pool 

        }

    }
}