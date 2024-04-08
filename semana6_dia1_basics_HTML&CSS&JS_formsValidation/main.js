function main() {
    desplegable();
    showCheckBox();
    showRadio();
    isToday();
    isDate2GreaterThanDate1();
    minAge();
    getIVA();
}


function desplegable() {
    let selectElement = document.getElementById("colors__select");
    selectElement.addEventListener("change", (event) => {
        const selectedValue = event.target.value;
        console.log(`Selected color: ${selectedValue}`);
    });
}

function showCheckBox() {
    const fieldset = document.querySelector("fieldset[id='colors__checkbox']");
    const checkBoxs = fieldset.querySelectorAll("input[type='checkbox']");

    for(const checkBox of checkBoxs){
        checkBox.addEventListener("change", (event) =>{
            const selectedValue = event.target.value;
            console.log(`Selected value for checkbox ${selectedValue}`);
        });
    }
}

function showRadio() {
    const fieldsetElement = document.querySelector("fieldset[id='colors']");
    const radioButtons = fieldsetElement.querySelectorAll("input[type='radio']");

    for (const radioButton of radioButtons) {
        radioButton.addEventListener("change", (event) => {
            const selectedValue = event.target.value;
            console.log(`Selected value: ${selectedValue}`);
        });
    }
}

function isToday() {

}
function isDate2GreaterThanDate1() {

}
function minAge() {

}
function getIVA() {

}