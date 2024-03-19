<?php
    
    require_once('getConn.php');
    $conn = getConn();

    $nombre = $_POST["nombre_cli"];
    $cod = $_POST["apellidos_cli"];
    $des = $_POST["direccion_cli"];
    $price = $_POST["telefono_cli"];

    $sql = "INSERT INTO clientes (nombre_cli, apellidos_cli, direccion_cli, telefono_cli) 
            VALUES ('{$nombre}', '{$cod}', '{$des}', '{$price}')";

    if(mysqli_query($conn, $sql)){
        echo "inserted";
    } else {
        echo "error -->>" . mysqli_error($conn);
    }

    $conn->close();
?>