/*
 * Para crear un nuevo asset y añadirlo hay que hacer varias cosas
 * 
 * 
 * 1 añadir una version con transparencia y otra sin al build manager
 * 2 crear en el build menu un set index 
 * 3 añadirle a la estructura el node updater rigidbody , destroy function y collider
 * 4 añadirle dependeiendo del tamaño al prefab transparente el prevew prefab size , quitarle el collider y el nav mesh modifier
 * 5 añadir en el buildmanager , structure cost,  su coste en oro y sus variables.
 * 6 añadir en el build manager priceupdate y update price UI
 * 7 Añadirle la funcion al script destroy structure
 * 8 BuildMenu , añadirlo a la corrutina para comprobar si tiene suficiente oro o no y añadirle al build menu los botones
 * 9 crear el boton y añadirle las correspondientes funciones y añadirle al builmanager los textos
 * 
 */