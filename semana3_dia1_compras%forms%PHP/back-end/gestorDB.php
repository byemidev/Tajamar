<?php
    //obtiene la conexion OK 
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
    //inserta un registro OK 
    function insert($conn, $sql){
        if(mysqli_query($conn, $sql)){
            echo '<div style="width=100%; height="auto"; background-color:green; > INSERCCION CORRECTA: </br><a href="../"> volver a menu</a>
                 </div>';
        } else {
            echo "error -->>" . mysqli_error($conn);
        }
    }

    //muestra todos los articulos OK 
    function showAllArticulos($conn) {
        $sql = "SELECT * FROM ARTICULOS";
        if ($result = mysqli_query($conn, $sql)) {
            while ($row = $result->fetch_assoc()) {
                echo "<ul>\n<li>" . $row["nombre_art"] . " || " . $row["codigo_art"] . " || " . $row["descripcion_art"] . " || " . $row["precio"] . "</li></ul>\n";
            }
        }
    }
    //muestra todos los clientes OK 
    function showAllClientes($conn){
        $sql = "SELECT * FROM CLIENTES";
        if ($result = mysqli_query($conn, $sql)) {
            while ($row = $result->fetch_assoc()) {
                echo "<ul>\n<li>" . $row["nombre_cli"] . " || " . $row["apellidos_cli"] . " || " . $row["direccion_cli"] . " || " . $row["telefono_cli"] . "</li></ul>\n";
            }
        }
    }
    //muestra todas las compras OK
    function showAllCompras($conn){
        $sql = "SELECT * FROM COMPRAS";
        if ($result = mysqli_query($conn, $sql)) {
            while ($row = $result->fetch_assoc()) {
                echo "<ul>\n<li>" . $row["id_cliente"] . " || " . $row["id_articulo"] . " || " . $row["cantidad"] . " || " . $row["fechacompra"] . "</li></ul>\n";
            }
        }
    }
    //muestra todos los articulos por ID 
    function showAllArticulosByID($conn, $id) {
        $sql = "SELECT * FROM ARTICULOS WHERE id_articulo = '{$id}'";
        if ($result = mysqli_query($conn, $sql)) {
            while ($row = $result->fetch_assoc()) {
                echo "<ul>\n<li>" . $row["nombre_art"] . " || " . $row["codigo_art"] . " || " . $row["descripcion_art"] . " || " . $row["precio"] . "</li></ul>\n";
            }
        }
    }
    //muestra todos los clientes por ID 
    function showAllClientesByID($conn, $id){
        $sql = "SELECT * FROM CLIENTES WHERE id_cliente = '{$id}'";
        if ($result = mysqli_query($conn, $sql)) {
            while ($row = $result->fetch_assoc()) {
                echo "<ul>\n<li>" . $row["nombre_cli"] . " || " . $row["apellidos_cli"] . " || " . $row["direccion_cli"] . " || " . $row["telefono_cli"] . "</li></ul>\n";
            }
        }
    }
    //muestra todas las compras por id_cliente
    function showAllComprasByID($conn, $id){
        $sql = "SELECT * FROM COMPRAS WHERE id_cliente = '{$id}'";
        if ($result = mysqli_query($conn, $sql)) {
            while ($row = $result->fetch_assoc()) {
                echo "<ul>\n<li>" . $row["id_cliente"] . " || " . $row["id_articulo"] . " || " . $row["cantidad"] . " || " . $row["fechacomnpra"] . "</li></ul>\n";
            }
        }
    }

    function deleteClienteByID($conn, $id){
        $sql = "DELETE FROM CLIENTES WHERE id_cliente = '{$id}';";
    }

    /*home functions*/ 
    //muestra todos los productos para home
    function getAllProducts() {
        $conn = getConn();
        $sql = "SELECT * FROM ARTICULOS";
        if ($result = mysqli_query($conn, $sql)) {
            return $result->fetch_assoc(); 
        }
    }

?> 