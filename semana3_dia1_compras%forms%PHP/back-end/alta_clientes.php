<?php
    //necesito getConn.php
    require_once('gestorDB.php');
    $conn = getConn();//obtengo la conexion 
    
    //reocojo los datos del formulario
    $nombre = $_POST["nombre_cli"];
    $apell = $_POST["apellido_cli"];
    $dir = $_POST["direccion_cli"];
    $tel = $_POST["telefono_cli"];

    $sql = "INSERT INTO articulos (nombre_cli, apellido_cli, direccion_cli, telefono_cli) 
            VALUES ('{$nombre}', '{$apell}', '{$dir}', '{$tel}')";
    
    require_once('gestorDB.php');
    insert($conn, $sql);
    
    $conn->close();
?>