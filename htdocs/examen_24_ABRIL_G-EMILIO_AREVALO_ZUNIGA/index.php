<?php
    //tratamientos menu
    if(isset($_POST['submit'])){
        if($_POST['option']){
            if($_POST['option'] === "1"){
                header("Location: insertar.php");
            }else{
                header("Location: mostrar.php");
            }
        }   
    }

?>


<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous">
    <link rel="stylesheet" href="style.css">
    <title>examen</title>
</head>
<body>
    <div class="container-fluid justify-content-center">
        <p class="display-4 text-info">
                Elije una opcion y seras reedirigido a la pagina correspondiente.
        </p><hr><br>
        <div class="container-fluid table-bordered">
        <form id="form-menu" action="" method="post">
            <div class="mb-3 form-check">
                <label class="display-6 form-check-label" for="insertar">Insertar un plato<input class="form-check-input" name="option" value="1" id="insertar" type="radio"></label>
            </div>
            <div class="mb-3 form-check">
                <label class=" display-6 form-check-label" for="mostrar">Mostrar platos<input class="form-check-input" name="option" value="2" id="mostrar" type="radio"></label>
            </div>
        <button class="btn btn-primary"name="submit" value="OK">OK</button>
        </form>
        </div>
    </div>
<script src="script.js"></script>
</body>
</html>





