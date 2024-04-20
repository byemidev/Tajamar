<?php

$option = $_POST['option'];
echo $option;
$submit = $_POST['submit'];
    if(isset($submit)){
        if(isset($option)){
            if($option === "1"){
                uploadRegCalls();
            }else{
                downloadCSV();
            }
        }   
    }

    function uploadRegCalls(){
        
    $conn = new mysqli('localhost','root','','regcalls') or die("error en la conexion : mysql");
    
    if($conn->set_charset('utf8')){

        $json = file_get_contents("http://www.holaformacion.com/tajamar/ejemplo_llamadas.json");
        
        $data = json_decode($json, true);

        foreach($data as $llamada){
            
            //TODO: fix date format to insert into the table
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


    //using mysqli to obtain the connexion
    function downloadCSV(){
        $callsCSV = "calls.csv";
        $conn = new mysqli('localhost','root','','regcalls') or die('error en la conexion: mysql');
        $i = 0;
        if($conn){
    
            $i++;//for unique exec
    
            if($i===1){
                $fp = fopen($callsCSV, 'w');
                $columns = getColumns();
                fputcsv($fp, $columns, ';');
                fclose($fp);
            }
            
            $sql = 'SELECT * FROM llamadas ';
            
            if($result = mysqli_query($conn, $sql)){
    
                $fp = fopen($callsCSV, 'a');
    
                while($row = $result->fetch_assoc()){
                    $row = 
                    fputcsv($fp, $row, ';');
                }
                fclose($fp);
                
                // Output the CSV file to the browser for download
                header('Content-Type: text/csv');
                header('Content-Disposition: attachment; filename="' . basename($callsCSV) . '"');
                header('Expires: 0');
                header('Cache-Control: must-revalidate');
                header('Pragma: public');
                header('Content-Length: ' . filesize($callsCSV));
                readfile($callsCSV);
    
            }else {
                echo 'error';
            }
        }
        $conn->close();
        //to delete after dowload
    }


    //using PDO to obtain the conexion
    function getColumns(){
        try{
            $base_datos = new PDO("mysql:host=localhost;dbname=regcalls;charset=utf8","root","");
        }catch(Exception $e){
            echo 'ocurrio algo con la base de datos' . $e;
        }
        //getting columns using meta database info
        $columns = $base_datos->query("SELECT COLUMN_NAME AS columna FROM  information_schema.columns
                                        WHERE table_schema = 'regcalls' AND table_name = 'llamadas'")->fetchAll(PDO::FETCH_COLUMN);
    
        return $columns;
    }
?>
