<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous">
    <link rel="stylesheet" href="style.css">
    <title>Mostrar php</title>
</head>
<body>
    <div class="container-fluid">
    <button id="btn-volver" class="btn btn-primary">Volver al menu</button><hr><br>
    <table class="table table-dark table-striped">
        <thead>
            <tr>
            <th scope="col">#ID</th>
            <th scope="col">nombre</th>
            <th scope="col">componentes</th>
            <th scope="col">alergenos</th>
            <th scope="col">posicion</th>
            </tr>
        </thead>
        <tbody>
            <tr>
            <?php
            //mostrar
                include_once('gestorDB.php');
                $sql = "SELECT * FROM listado"; 
                $conn = getConn();
                if($result = mysqli_query($conn, $sql)){
                    while($row = $result->fetch_assoc()){ 
            ?>
            <th scope="row">
            <?php echo  $row['id_producto']; ?>          
            </th>
            <td>
            <?php echo  $row['nombre_plato']; ?>
            </td>
            <td>
            <?php echo  $row['componentes']; ?>
            </td>
            <td>
            <?php if($row['alergenos']==0){echo 'NO';} else{echo 'SI';}?>
            </td>
            <td>
            <?php switch ($row['posicion']){
                case 1:
                    echo 'entrante';
                    break;
                case 2:
                    echo 'primer plato';
                    break;
                case 3:
                    echo 'segundo plato';
                    break;
                case 4:
                    echo 'postre';
                    break;
                default: 
                    echo 'sin asignar';
                    break;
                } ?>
            </td>
            </tr>
            <?php 
                    }//fin de while para $row
                }// fin de condicion if($result = mysqli_query())
                
            ?>
        </tbody>
    </table>
</div>
<script src="script.js"></script>
</body>
</html>
