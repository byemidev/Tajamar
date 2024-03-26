<?php
    //global function 
    function getConn(){
        $serverName ="localhost";
        $user ="root";
        $pass ="";
        $database ="bdbiblioteca";

        $conn = mysqli_connect($serverName, $user, $pass, $database);

        if(!$conn){
            die("fallo de conexion" . mysqli_connect_error());
        }
        return $conn;
    }
    //inserta un registro 
    function insertBook($conn, $sql){
        if(mysqli_query($conn, $sql)){
            echo '<div style="width=100%; height="auto"; background-color:green; > INSERCCION CORRECTA: </br><a href="../"> volver a menu</a>
                 </div>';
        } else {
            echo "error -->>" . mysqli_error($conn);
        }
    }
    /*home functions*/ 
    //muestra todos los productos para home
    function getAllBooks() {
        $conn = getConn();
        $sql = "SELECT * FROM BOOKS";
        if ($result = mysqli_query($conn, $sql)) {
            return $result->fetch_assoc(); 
        }
    }

?> 