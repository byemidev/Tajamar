<?php
    //declaracion de variables/requisitos para la conexion
    $servername = "localhost";
    $database = "prueba";
    $username = "root";
    $password= "";

    //crear conexion 
    $conn = mysqli_connect($servername,$username,$password,$database);

    //comprobar conexion
    if(!$conn){
        die("fallo de conexion: " .mysqli_connect_error()); 
    }

    echo "Connected OK!!";

    //insert prueba
    /*$sql = "INSERT INTO agenda(nombre, apellidos, telefono, direccion) 
    VALUES ('andra','azure zuniga','6666666','calle eres un crack jeje')";
    */

    //recoger datos de formulario 
    $name = $_POST["nombre"];
    $surname = $_POST["apellidos"];
    $tel = $_POST["tel"];
    $dir = $_POST["direccion"];

    //sentencia insert
    $sql = "INSERT INTO agenda (nombre, apellidos, telefono, direccion)
            VALUES ('{$name}','{$surname}','{$tel}','{$dir}')";
    
    /*
    $sql2 = "DELETE FROM agenda WHERE nombre LIKE'a%'";
    */
    //Resolviendo sql ..
    if(mysqli_query($conn, $sql)){
        echo "inserted";
    }else {
        echo "NOT OK" . $sql . mysqli_error($conn);
    }
    //cerrar conexion
    $conn->close();
?>