const numeros = [15,26,58,60,122,33]
const palabra = ["a","bdc","c","dds","eew"]
/** == solo compara valor y === compara valor y tipo */
/** Include Encuentra el numero */
const resul = numeros.includes(58)
console.log(resul)
/** Some  Encuentra el numero */
const numeros2 = numeros.some(num => num === 58) 
console.log(numeros2);
/** Found Develve los numeros encontrados */
const enc = numeros.find(n => n < 26);
console.log(enc);
/** every devuelve si se cumple la verdad */
const dentro = (numeros) => numeros < 40?console.log(array2.every(dentro)):console.log("Error")
/** reduce */
/** Suma los valores del array; a se va acumulando, b el valor actual */
const sumArr = numeros.reduce(
    (a, b) => a + b,
    0,
  );
  console.log(sumArr);
/** filter filtra  */
const result = palabra.filter((n) => n.length > 1);
console.log(result);
/** map Muestra elementos */
numeros.map(element => console.log(element))
/** forEach Muestra cada número en la consola */
numeros.forEach(element => {
    console.log(element)
});