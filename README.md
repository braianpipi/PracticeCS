# 🎮 Proyecto Unity - Movimiento de Esferas, Disparo y Gestión de Objetos

Este proyecto básico en Unity se ha expandido para incluir varias funcionalidades esenciales en el desarrollo de videojuegos. Además de los conceptos de movimiento de esferas y cámaras, hemos implementado la gestión de sonidos, el sistema de disparo de balas y el manejo eficiente de objetos a través de **Object Pooling**.

---

## ✅ Funcionalidades implementadas

### **Movimiento y Cámara**
- **Movimiento de esferas:** Utiliza `transform.Translate` y `Rigidbody.AddForce` para mover las esferas en la escena.
- **Comparativa entre `Update()` y `FixedUpdate()`:** Demuestra cómo se aplican ambos métodos para el control de la física de objetos.
- **Manejo de rotaciones:** Uso de `transform.localRotation` y ángulos en **Euler** para controlar la orientación de los objetos.
  
#### **Control de cámara desde dispositivos móviles:**
- Permite mover la cámara arrastrando el dedo sobre la pantalla.
- Utiliza `TouchPhase.Moved` y `deltaPosition` para capturar la dirección del gesto.

---

### **Disparo y Colisiones**

#### **Disparo de balas al hacer clic:**
- Las balas se disparan hacia adelante con una velocidad ajustable.
- Implementación de un tiempo de vida para las balas, las cuales se desactivan después de un cierto período para optimizar recursos.

#### **Colisiones de balas con efectos:**
- Al colisionar con otro objeto, se genera un efecto visual de explosión (destello).
- El uso de **Object Pooling** permite reutilizar los objetos de bala y efectos sin necesidad de destruirlos constantemente.

---

### **Gestión de Sonidos**
- **SoundManager** centraliza la gestión de los sonidos del juego.
- Permite reproducir efectos de sonido, como el impacto de las balas.
- Optimiza el manejo de recursos sonoros mediante la carga y reproducción eficiente de los audios.

---

### **Optimización de Recursos**
- **Object Pooling** para la reutilización de objetos como balas y efectos de colisión, reduciendo el consumo de memoria y mejorando el rendimiento.
- **SoundManager** para una gestión eficiente de los sonidos, evitando sobrecargar el sistema con múltiples instancias de audio.

---

## 🛠️ Tecnologías usadas

- **Unity** (versión recomendada: 2022 o superior)
- **Visual Studio** con integración Git
- **Git y GitHub** para el control de versiones

---

## 🚀 Primeros pasos

1. Clonar este repositorio:
   ```bash
   git clone <URL del repositorio>
