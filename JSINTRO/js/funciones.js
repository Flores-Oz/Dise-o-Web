//Function Declaration
function suma(f1=0,n2=0){
    return f1+n2
}
console.log(suma(56,9))

const suma2 = function(n1=0,n2=0){
    return n1+n2
}
console.log(suma2(8,9))

/*const suma3(n3=0,n4=0)=>{
    return n1+25
}
console.log(suma3(25,33))*/

const suma4=n3 => n3+25
console.log(suma4(33))

const claveNumerica=123
const claveAlfa='abc'

claveNumerica === 123?
claveAlfa==='abc'?console.log('100%'):console.log('Error en la Clave Numerica'):
console.log('Error')