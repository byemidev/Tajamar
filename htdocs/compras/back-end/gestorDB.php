<?php
    function getConn(){
        $serverName ="localhost";
        $user ="root";
        $pass ="";
        $database ="compras";

        $conn = mysqli_connect($serverName, $user, $pass, $database);

        if(!$conn){
            die("fallo de conexion" . mysqli_connect_error());
        }
        return $conn;
    }

    function insert($conn, $sql){
        if(mysqli_query($conn, $sql)){
            echo '<div style="width=100%; height="auto"; background-color:green; > INSERCCION CORRECTA: </br><a href="../"> volver a menu</a>
                 </div>';
        } else {
            echo "error -->>" . mysqli_error($conn);
        }
    }
?>