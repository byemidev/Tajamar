<?php

echo 'estoy en llamadas<br>'; 

$option = $_POST['option'];
echo $option;
$submit = $_POST['submit'];
    if(isset($submit)){
        if(isset($option)){
            if($option === "1"){
                uploadRegCalls();
            }else{
                downloadRegCalls();
            }
        }   
    }

    function uploadRegCalls(){
        
    $conn = new mysqli('localhost','root','','regcalls') or die("error en la conexion : mysql");

    if($conn){

        $json = file_get_contents("http://www.holaformacion.com/tajamar/ejemplo_llamadas.json");
        
        $data = json_decode($json, true);

        foreach($data as $llamada){
            
            if($stmt= $conn->prepare('INSERT INTO llamadas (FECHA, HORA, ESPECIAL, DURACION , Llamado, Llamante , TIPO_CLIENTE , IDIOMA, COORDINADOR, INICIO, FIN, TIEMPO_COLA, ATENDIDA, CODIGO) VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?)')){
                $stmt->bind_param("ssssssssssssss", $llamada['FECHA'], $llamada['HORA'], $llamada['ESPECIAL'], $llamada['DURACION'], $llamada['Llamado'], $llamada['Llamante'], $llamada['TIPO CLIENTE'], $llamada['IDIOMA'], $llamada['COORDINADOR'], $llamada['INICIO'],$llamada['FIN'], $llamada['TIEMPO COLA'], $llamada['ATENDIDA'], $llamada['CODIGO'] );
                echo '<p>añadiendo registros a la base de datos</p>';
            }
    
            $stmt->execute();
            $stmt->close();
        }
    }

    $conn->close();
    }


    function downloadRegCalls(){
        $i = 0; //countCalls
        $conn = new mysqli('localhost','root','','regcalls') or die('error en la conexion: mysql');
        if($conn){
            $sql = 'SELECT * FROM llamadas;';
            if($result = mysqli_query($conn, $sql)){
                while($row = $result->fetch_assoc()){
                    echo '<p>Registro nro.' . $i++ . '<br>' . $row['FECHA'] . '</p>';
                }
            }
        }
        $conn->close();
    }

?>
