const form = document.querySelector("reservation-form");

//hasta que no este validado no envio form
form.addEventListener("submit", (event) => {
  //prevengo que se envie sin validar
  event.preventDefault();
  //recoger input
  const name = document.getElementById("name");
  
  const surname = document.getElementById("surname");
  
  const phone = document.getElementById("phone");
  
  const email = document.getElementById("email");
  
  const checkinDate = document.getElementById("checkinDate");
  
  const checkoutDate = document.getElementById("checkoutDate");
  
  const guestNum = document.getElementById("guestNum");
  
  const ages = []; //me interesa tener las edades en un mismo sitio. Pero debe haber al menos una edad registrada == una por huesped
  ages.push(document.getElementById("age0"));
  
  const room = document.getElementById("room");
  //debo ver si los criterios de validacion se estan cumpliendo
  
  const hasAnError = false;
  if (!checkRegexTxt(name.textContent)) {
    console.log("error about name");
    message = "error about name";
    hasAnError = true;
    error(message);
  } else if (!checkRegexTxt(surname.textContent )) {
    console.log("error about name");
    hasAnError = true;
    surname.error(message);
  } else if (!checkRegexPhone(phone.textContent)) {
    console.log("error about name");
    hasAnError = true;
    phone.error();
  } else if (!email.checkValidity()) {
    console.log("error about name");
    hasAnError = true;
    email.error();
  } else if (!checkinDate.checkValidity()) {
    console.log("error about name");
    hasAnError = true;
    checkinDate.error();
  } else if (!checkoutDate.checkValidity()) {
    console.log("error about name");
    hasAnError = true;
    checkoutDate.error();
  } else if (!guestNum.checkValidity()) {
    console.log("error about name");
    hasAnError = true;
    guestNum.error();
  } else if (!ages[0].checkValidity()) {
    console.log("error about name");
    hasAnError = true;
    ages[0].error();
  } 
  
  
  if(!hasAnError) {
    name.success();
    surname.success();
    phone.success();
    email.success();
    checkinDate.success();
    checkoutDate.sucess();
    guestNum.success();
    ages[0].success();
    // envio el formulario
    form.submit();
  }
});

const fields = document.getElementsByClassName("field");
 fields.array.forEach(field => {

 }); 

//para acceder cuando ocurra un error al div y ponerlo de otro color
const fieldValue = document.querySelector("div[class='field']");
//patron para mis input[type='text']
const regexTxt= /^[a-zA-Z]{1,90}$/;//solo letras mayus and minus entre 1 y 90 chars
function checkRegexTxt (input) {
  return  patternTxt.test(input);
}
//patron para mis input[type="phone"]
const regexPhone = /^\d{9}$/; //solo numeros && 9 digitos en total
function checkRegexPhone(input){
  return regexPhone.test(input);
}

//patron para mis input[type="mail"]
const regexEmail = /^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$/;
function checkRegexEmail(input){
  return regexEmail.test(input);
}

