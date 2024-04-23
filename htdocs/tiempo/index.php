<?php
include_once('weather.php');
$data = fetchData();

if($data ===null){
    echo 'sin datos';
}else {
    

?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Pagina tiempo semana</title>
    <link rel="stylesheet" href="style.css">
</head>
<body class="grid">
    <?php
        //header
        echo '<h1 class="header">' . 'Hoy en ' . $data['locality']['name'] . '</h1>';
        //getting {Root}.locality
        $findMe = "day";
         
        for($i = 1; $i <=7; $i++){
            //TODO $data['day' . (string)$i]['values'] 
            
            
            //if($day = strpos($data, $findMe)){
                //$weather = new Weather($item['date'], $item['icon'], $item['temperature_max'], $item['temperature_min'], $item['text'], $item['humidity'], $item['moonphase']);
                //$weather->__toString();
                //}
        }
            
    }
?>
</body>
</html>
