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

const ages = [];
ages.push(document.getElementById("age0"));

const room = document.getElementById("room");

//debo ver si los criterios de validacion se estan cumpliendo

  if (!name.checkValidity()) {
    name.setCustomValidity("introduce un nombre valido");
  } else if (!surname.checkValidity()) {
    surname.setCustomValidity("introduce un apellido valido");
  } else if (!phone.checkValidity()) {
    phone.setCustomValidity("introduce un numero valido");
  } else if (!email.checkValidity()) {
    email.setCustomValidity("introduce un formato valido para email");
  } else if (!checkinDate.checkValidity()) {
    checkinDate.setCustomValidity("elije una fecha de entrada valida");
  } else if (!checkoutDate.checkValidity()) {
    checkoutDate.setCustomValidity("elije una fecha de entrada valida");
  } else if (!guestNum.checkValidity()) {
    guestNum.setCustomValidity("debes elegir el numero de huespedes");
  } else if (!ages[0].checkValidity()) {
    ages[0].setCustomValidity("debes de ser mayor de edad");
  } else {
    name.setCustomValidity("");
    surname.setCustomValidity("");
    phone.setCustomValidity("");
    email.setCustomValidity("");
    checkinDate.setCustomValidity("");
    checkoutDate.setCustomValidity("");
    guestNum.setCustomValidity("");
    ages[0].setCustomValidity("");
    // envio el formulario
    form.submit();
  }
});
