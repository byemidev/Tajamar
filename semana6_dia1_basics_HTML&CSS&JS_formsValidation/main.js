const form = document.querySelector("form");
const select = document.getElementById("selector");


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
const checkBoxes = document.querySelectorAll("input[type='checkbox'][name='cb']"); 
const enableCheckBox = [];

checkBoxes.forEach((checkbox) => {
  checkbox.addEventListener('change', (event) => {
    if(!event.target.checked){
      console.log("ningun valor seleccionado en #colors__checkbox");
      checkBoxes.setCustomValidity("debe haber al menos ua opcion seleccionada");  
    }else{
      checkbox.setCustomValidity("");
      enableCheckBox.push(event.target.value); 
      console.log("seleccionado en checkbox");
    }
    checkBoxes.reportValidity();

    //recorriendo los valores seleccionados
    enableCheckBox.forEach((checkboxValue)=>{
        console.log(`${checkboxValue} esta seleccionado`);
    });
  });
});


//validacion radio 
const radios = document.querySelectorAll("input[type='radio'][name='colors_radio']"); //me devuelve mas de uno

radios.forEach((radio) => {
  radio.addEventListener("change", (event) => {
    if(!event.target.checked){
      console.log("ningun valor seleccionado en #colors__radio")
      radios.setCustomValidity("debes seleccionar un valor para radio");
    }else {
      radios.setCustomValidity("");
      console.log("seleccionado en radio");
    }
    checkBoxes.reportValidity();
  });
});

//escucho el evento submit
form.addEventListener("submit", (event) => {//antes de enviar mi formulario checkeo que todos los valores estan en ese momento = valid
  if (!select.checkValidity() && !checkBoxes.checkValidity() && !radios.checkValidity()) {+
    console.log("los criterios de validacion no han sido satisfechos");
    event.preventDefault();
  } //tengo que verificar que devuelven mis validaciones
});

