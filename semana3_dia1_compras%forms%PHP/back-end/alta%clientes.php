<?php
    $serverName ="localhost";
    $user ="root";
    $pass ="";
    $database ="compras";

    $conn = mysqli_connect($serverName, $user, $pass, $database);

    if(!$conn){
        die("fallo de conexion" . mysqli_connect_error());
    }

    $nombre = $_POST["nombre_cli"];
    $cod = $_POST["apellidos_cli"];
    $des = $_POST["direccion_cli"];
    $price = $_POST["telefono_cli"];

    $sql = "INSERT INTO clientes (nombre_cli, apellidos_cli, direccion_cli, telefono_cli) 
            VALUES ('{$nombre}', '{$cod}', '{$des}', '{$price}')";

    if(mysqli_query($conn, $sql)){
        echo "inserted"
    } else {
        echo "error -->>" . mysqli_error($conn);
    }

    $conn->close();
?>