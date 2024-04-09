const form = document.querySelector("form");
const select = document.getElementById("selector");



form.addEventListener("submit", (event) => {
  if (!select.checkValidity()) {
    event.preventDefault();
  } //tengo que verificar que devuelven mis validaciones
});


//validacion de desplegable
select.addEventListener("change", (event) => {
  if (event.target.value === "") {
    select.setCustomValidity("necesitas elegir un valor");
    console.log("ningun valor elegido");
  } else {
    select.setCustomValidity("");
    console.log("algun valor elegido");
  }

  select.reportValidity();
});

//validacion de checkboxes
const checkBoxes = document.querySelectorAll("input[name='cb']");

checkBoxes.forEach((checkbox) => {
  checkbox.addEventListener('click', (event) => {
    if(!event.target.checked){
      console.log("ningun valor chekced");
      checkBoxes.setCustomValidity("debe haber al menos ua opcion seleccionada");  
    }else{checkBoxes.setCustomValidity(""); console.log("todo ok en checkbox");}
    checkBoxes.reportValidity();
  });
});
