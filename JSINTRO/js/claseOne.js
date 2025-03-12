const nit='123'
const nombre='Daniel'
const cliente={
    nit,
    nombre,
    edad:"35"
}
/*Bloquear Objeto*/
/*Object.freeze(cliente)
/* Modificar, más no agregar ni eliminar */
Object.seal(cliente)
/*Modificar el valor de una Propiedad*/
cliente.nombre = "Oscar"
cliente.apellido = "Flores"
cliente.direccion = "Zona 1"
console.log(cliente.direccion)
delete cliente.direccion
/*
let edad = 45
let nombre="Oscar"
/*String es mas importante que number*/
/*
console.log(edad)
console.log(nombre)
*/
/*
const nit="123"
const nombre2="Vladimir"
const edad2=35
*/
console.table(cliente)
console.log(cliente)
/*Destructuting*/
/*const {nit,nombre,edad}=cliente
/*console.log(nit,nombre,edad) */
