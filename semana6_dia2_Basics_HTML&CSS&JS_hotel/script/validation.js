const form = document.querySelector("form");

//hasta que no este validado no envio form
form.addEventListener("submit", (event) => {
  event.preventDefault();

  //prueba
  const name = document.getElementById("name");

  if(!checkRegexTxt(name)){
    name.setCustomValidity("Solo letras");
  }
  //todo
  //solo validar los datos de reserva , los datos personales los cargo desde la base de datos
});



//para acceder cuando ocurra un error al div y ponerlo de otro color
//patron para mis input[type='text']
const regexTxt = /^[a-zA-Z]{1,90}$/; //solo letras mayus and minus entre 1 y 90 chars
function checkRegexTxt(input) {
  return regexTxt.test(input);
}
//patron para mis input[type="phone"]
const regexPhone = /^\d{9}$/; //solo numeros && 9 digitos en total
function checkRegexPhone(input) {
  return regexPhone.test(input);
}

//patron para mis input[type="mail"]
const regexEmail =
  /^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$/;
function checkRegexEmail(input) {
  return regexEmail.test(input);
}
