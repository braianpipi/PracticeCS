using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    //Caracteristicas importantes para considerar de una bala es que tiene que tener una velocidad y un tiempo de vida. 
    public float velocidadBala = 10f;
    public float vidaBala = 5f;
    //Aca genero el objeto para el Instiate del efecto de explosion
    public GameObject efectoExplosion;
    

    //Para trabajar la forma de la bala utilizo boton izquierdo -> Efects -> Trail : Aca modifica la curva de Trail Renderer y mueve el eje hacia los costados , luego le agrega color. Le cambia el material y le pone uno default-line.Le baja el tiempo de duracion .
    //El problema de llamar el metodo en el Start hace que las balas que salen de la plataforma no incorporen el ciclo de vida en tiempo, por ende se llama el metodo onEnable().
    //void Start()

    //Metodo OnEnable() lo que hace es cada vez que se activa o desactiva algo. 
        void OnEnable()
    {
        //Aca se instancia el metodo de vida de la bala para que se ejecute apenas se crea el objeto.
        //Destroy(this.gameObject, vidaBala);
        //Esto se desactiva porque se usa el ObjectPolled
        //Y para desactivar el objeto pooler tengo que crear un nuevo metodo 

        //Invoke sirve para llamar al metodo con otro parametro de tiempo, este caso el tiempo de la vida de la bala.
        Invoke("Desactivar", vidaBala);

    }

    void Desactivar()
    {
        gameObject.SetActive(false);
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
        //Esto se desactiva porque se usa el ObjectPolled
        //Destroy(this.gameObject);

        //Aca llama al metodo instantiate para que genere un efecto explosion
        //Esto se desactiva porque se usa el ObjectPolled
        //Instantiate(efectoExplosion, collision.transform.position, Quaternion.identity);

        //Creamos una copia de un efecto de explosion de una bala, en el lugar que hayas colisionado, y el Quaternion.identity es que tiene rotacion nula.
        //Para crear un destello se crea un prefab, y boton izquierdo. Buscar efectos y elegir el de destellos todo en el lugar donde estan los prefabs -
        //tener en cuenta que el collision.gameObject.trasnform.position lo instancia en el medio de todos los objetos 
        //Este proceso de instanciar y destruir cosas tiene de malo que consume muchos recursos.Para reemplazar esto se usa un Pool de Objetos.
        //Para esto arrastramos un objeto vacio a la escena llamado Object Pooler y le asigna el script de ObjectPooler 

        // En el inspector se genera una lista para agregar los objetos que va a hacer un pool. 
        //Identificar el elemento prefab para hacer el pool
        
        //La cantidad de objetos para el pool y por el ultimo el tipo . 
        //Se agrega codigo en shoot.cs para activarlo y aca para desactivarlo

        gameObject.SetActive(false);


        GameObject efecto = ObjectPooler.SharedInstance.GetPooledObject(ObjectType.Destello);
        efecto.transform.position = collision.contacts[0].point;
        efecto.transform.rotation = Quaternion.LookRotation(collision.contacts[0].normal);
        efecto.SetActive(true);

        SoundManager.instance.PlaySound(SoundType.IMPACTO_1, 1f);
    }
}
