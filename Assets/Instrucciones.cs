/*
 * Para crear un nuevo asset y a�adirlo hay que hacer varias cosas
 * 
 * 
 * 1 a�adir una version con transparencia y otra sin al build manager
 * 2 crear en el build menu un set index 
 * 3 a�adirle a la estructura el node updater rigidbody , destroy function y collider
 * 4 a�adirle dependeiendo del tama�o al prefab transparente el prevew prefab size , quitarle el collider y el nav mesh modifier
 * 5 a�adir en el buildmanager , structure cost,  su coste en oro y sus variables.
 * 6 a�adir en el build manager priceupdate y update price UI
 * 7 A�adirle la funcion al script destroy structure
 * 8 BuildMenu , a�adirlo a la corrutina para comprobar si tiene suficiente oro o no y a�adirle al build menu los botones
 * 9 crear el boton y a�adirle las correspondientes funciones y a�adirle al builmanager los textos
 * 
 */