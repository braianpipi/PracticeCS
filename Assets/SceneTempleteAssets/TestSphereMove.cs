using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
using static UnityEditor.PlayerSettings;
using UnityEngine.XR;
using System.Timers;

/*
 * TestEspheresMove.cs
 * Este script controla el movimiento de dos esferas distintas usando Update y FixedUpdate.
 * 
 * - En el método Update(): se traslada una esfera manualmente usando Transform.Translate,
 *   ideal para movimientos simples y directos que no requieren física.
 * 
 * - En el método FixedUpdate(): se aplica una fuerza con Rigidbody.AddForce a otra esfera,
 *   lo cual permite un movimiento basado en física (aceleración, colisiones, etc.).
 * 
 * Importante: Las referencias a las esferas deben asignarse desde el Inspector.Pero pueden estar instanseadas en cualquier GameObject(no es lo recomendable, pero al ser nombrada una vez sola atribuye para ambos objetos las cualidades, es decir, no tiene que ser agregado a cada objeto)
 */

public class TestSphereMove : MonoBehaviour
{
    public Transform esferaUpdate;
    public Rigidbody esferaFixed;
    public float velocidad = 5f;
    public float fuerza = 50f;

    private void Update()
    {
        //Mueve la esferaUpdate usando transformacion directa (como si se teletransportara, practicamente no choca)
        //Se ejecuta una vez por cada frame que se dibuja en pantalla(depende de los FPS).
        //Es decir: si tenés 60 FPS, se llama 60 veces por segundo.
        esferaUpdate.Translate(Vector3.right * velocidad * Time.deltaTime);    
        //La esfera cirucla mas rapido y en forma continua sin cambiar rumbo
        
    }
    private void FixedUpdate()
    {
        //Mueve la esferafixed usando fuerza fisica, hay que agregar un componente Rigibody
        //Se ejecuta a intervalos constantes, por defecto 50 veces por segundo(no importa los FPS).
        //Es parte del sistema de física de Unity.
        //El fixed sirve para aplicar fuerza fisica sobre el Rigidbody del objeto
        esferaFixed.AddForce(Vector3.left * fuerza * Time.fixedDeltaTime);
        //la esfera se mueve mas lenta pero con mejor coordinacion y queda se adecua al choque
    }
}
