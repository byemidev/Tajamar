<?php
    //catching data returns
    include_once('weather.php');
    $data = fetchData();

    $i=0;
    foreach($data as $item){
     //working in body
     echo $i++; //to kno how many items json had
     //TODO; find locality to shoy the title into the body
     //TODO; Find days to show into the body as cards into a grid
     
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
    /*the code bellow didnt work bcause i tried to compare and array as string in strpos() method
        $findMe = "day";
        if($day = strpos($item, $findMe)){
           $weather = new Weather($item['date'], $item['icon'], $item['temperature_max'], $item['temperature_min'], $item['text'], $item['humidity'], $item['moonphase']);
           $weather->__toString();
       }
       */
    }
    ?>
</body>
</html>
