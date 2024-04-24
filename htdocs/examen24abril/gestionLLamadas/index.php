<?php
    //OBETENER CONEXION
    //getting connection
    $conn = mysqli_connect('localhost','root','','gruposLLamadas') or die('error en la conexion a base de datos(MYSQL), matando conexion....');
    $sql = "SELECT * FROM grupos";
    
?>

    <!DOCTYPE html>
    <html lang="en">
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>Document</title>
        <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
        <link rel="stylesheet" href="style.css">
    </head>
    <body class="grid">
        <table class="table table-dark table-striped">
        <thead>
            <tr>
            <th scope="col">#grupo</th>
            <th scope="col">nombre</th>
            </tr>
        </thead>
        <tbody>
            <tr>
<?php
// CARGAR GRUPOS EN LA TABLA 1
    if($result = mysqli_query($conn, $sql)){
        while($row = $result->fetch_assoc()){ 
?>
            <th scope="row">
<?php
                echo  $row['id_grupo'];
?>          </th>
            <td>
<?php 
//tabla
// CARGAR GRUPOS EN LA TABLA 2
            echo $row['nombre_grupo'] . '<br>'; 
            //CARGAR NUMEROS POR GRUPO EN LA TABLA        
            if(isset($row['id_grupo'])){
                        $sql_2 = "SELECT * FROM numeros WHERE id_grupo = {$row['id_grupo']}";
                        if($datos = mysqli_query($conn, $sql_2)){
                            echo '<div id="lista" style="visibility: hidden;">';
                            while($i = $datos->fetch_assoc()){ 
                                echo '<p>' . $i['nombre'] . '</p><br>';
                            }//fin while   
                            echo '</div>';
                        }
                    }
?>
            </td>
<?php
//tabla
//CREAR BOTONES POR CADA GRUPO  .SHOW .ADD          
            echo '<td><button class="show">info</button></td>';
            echo '<td><button class="add" value="'. $row['id_grupo'] . '">añadir</button></td>';
?>
            </tr>
        </tbody>
    
<?php   
//tabla 
        }//while cerrado cargar grupos
    }//if condicion de grupo

    //logica del formulario POST
    if (isset($_POST['submit'])) {
        
        $nombre = $_POST['nombre'];
        $desc = $_POST['descripcion'];
        $id_grupo = $_POST['id_grupo'];

        // Check if the id_grupo value exists in the grupos table
        $sql = "SELECT * FROM grupos WHERE id_grupo = '$id_grupo'";
        $result = mysqli_query($conn, $sql);
        if (mysqli_num_rows($result) == 0) {
            // The id_grupo value does not exist in the grupos table
            echo 'El grupo seleccionado no existe.';
            exit;
        }

        $sql = "INSERT INTO numeros (nombre, descripcion, id_grupo) VALUES ('$nombre', '$desc', '$id_grupo')"; 

        if (!mysqli_query($conn, $sql)) {
            echo 'No se pudo insertar el registro.';
        }
    }

?>
        <div class="form" style="visibility: hidden;">
            <form action="" method="post">
                <label for="nombre"> NOMBRE
                    <input id="nombbre" name="nombre"></input>
                </label>
                <label for="descripcion"> DESCRIPCION
                    <input id="descripcion" name="descripcion"></input>
                </label>
                <label for="id_grupo"> ID GRUPO
                    <input id="id_grupo" name="id_grupo"></input>
                </label>
                <button name="submit">insertar</button>
            </form>
        </div>
    </table>
    <script src="script.js"></script> 
    </body>
    </html>
    

