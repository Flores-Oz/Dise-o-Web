const numeros=[15,26,58]
console.log(numeros)
//numeros.pop()
//numeros.shift()
//const numbers=[...numeros,155] /*Para agregar un nuevo Elemento*/
//numeros.splice(0,1) /*Eliminar un Elemento*/ 
const nuevosnumeros = numeros.filter(
    function(n){
        if(n!==58)
            return n
    })
console.table(numeros)
console.table(nuevosnumeros)
const nuevosNumeros3 = numeros.filter(n=>n!==58)
console.table(nuevosNumeros3)
//Actualizar un ELmento
//numeros[1] = 16
console.table(numeros)
const nuevosnumeros2 = numeros.map(
    function(n){
        if (n===26){
            return 36
        }
        return n
    }
)
console.table(nuevosnumeros2)
const nuevosNumeros4 = numeros.map(n=>n===26?36:n)
console.table(nuevosNumeros4)