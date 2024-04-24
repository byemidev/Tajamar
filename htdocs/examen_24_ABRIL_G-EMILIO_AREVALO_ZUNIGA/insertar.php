<?php
    if(isset($_POST['submit'])){
        $nombre_plato = $_POST['nombre_plato'];
        $componentes = $_POST['componentes'];
        $alergenos = $_POST['alergenos'];
        $posicion = $_POST['posicion'];
        insertar($nombre_plato, $componentes, $alergenos, $posicion);
    }else{
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous">
    <link rel="stylesheet" href="style.css">
    <title>insertar php</title>
</head>
<body>
    <div class="insertar">
    <form id="form-insertar" action="" method="post" no-validate>
            <label for="nombre_plato">Nombre plato: <input class="form-control" id="nombre_plato" name="nombre_plato" type="text" required maxlenght="150"></label>
            <label for="componentes">Componenetes: <input class="form-control" id="componentes" name="componentes" type="text" required maxlenght="255"></label>
            <label for="alergenos">Alergenos: <select class="form-control" id="alergenos" name="alergenos" required>
                <option value="">--</option>
                <option name="alergenos" value="0">si</option>
                <option name="alergenos" value="1">no</option>
            </select></label>
            <label for="posicion">Posicion: <select class="form-control" id="posicion" name="posicion" required>
                <option value="">--</option>
                <option name="posicion" value="1">entrante</option>
                <option name="posicion" value="2">primer plato</option>
                <option name="posicion" value="3">segundo plato</option>
                <option name="posicion" value="4">postre</option>
            </select></label>
            <button class="btn btn-primary" name="submit" value="insertar">INSERTAR</button>
        </form>
    </div>
    <script src="script.js"></script>
<?php }?>
</body>
</html>

<?php
//funciones
  function insertar($nombre_plato, $componentes, $alergenos, $posicion){
        include_once('gestorDB.php');
        $conn = getConn();

        $sql = "INSERT INTO listado (nombre_plato, componentes, alergenos, posicion) VALUES ('$nombre_plato', '$componentes', '$alergenos', $posicion)"; 
        
        if(!mysqli_query($conn, $sql)){
            echo 'Error en la insercion';
            $conn->close();
        }else{
            echo 'insertado';
            header("Location: index.php");
        }

        $conn->close();
    }
?>