<?php
    $serverName = "localhost";
    $user = "root";
    $pass = "";
    $database = "newsletter_db";

    $conn = mysqli_connect($serverName,$user,$pass,$database);

    if(!$conn){
        die("fallo de conexion" . mysqli_connect_error());
    }

    $nombre = $_POST["nombre"];
    $surname = $_POST["apellidos"];
    $email = $_POST["email"];
    $origin = $_POST["origen"];

    $sql = "INSERT INTO subscribers(nombre, apell, email, origin)
            VALUES ('{$nombre}','{$surname}','{$email}','{$origin}')";

    if(mysqli_query($conn,$sql)){
        echo "inserted";
    }else {
        echo "error ->> " . mysqli_error($conn);
    }
    $conn->close();
?>