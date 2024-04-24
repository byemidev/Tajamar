<?php
    $conn = null;

    function getConn(){
        $conn = mysqli_connect('localhost','root','','examen_db') or die('error en la conexion de la base de datos');
        return $conn;
    }

    function closeConn(){
        return $conn->close();
    }

?>