<?php
    //getting connection
    $conn = mysqli_connect('localhost','root','','grupoLLamadas') or die('error en la conexion a base de datos(MYSQL), matando conexion....');
    
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

    if($result = mysqli_query($conn, $sql)){
        while($row = $result->fetch_assoc()){ 
?>
            <th scope="row"><?php
                echo  $row['id_grupo'];
            ?></th>
            <td>
                <?php echo $row['nombre_grupo']?>
            </td>
            <?php
            $i=0;//for adding button value

            echo '<td><button id="ver">info</button></td>';
            echo '<td><button id="add" value="'. $i++ . '">añadir</button></td>';
            ?>
            </tr>
        </tbody>
    
<?php    
        }//while
    }//if
?>
    </table>
    <script src="script.js"></script>
    </body>
    </html>
    

