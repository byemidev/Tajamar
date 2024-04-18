<?php
    //recuperar data 
    include_once('main.php');
    $data = fetchData();
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Pagina tiempo semana</title>
    <link rel="stylesheet" href="styles.css">
</head>
<body class="flexwrap">
    <?php
     //display data as divs
     foreach($data as $item){
        if($item['locality']){
            echo '<h1>' . $item['locality'] . '</h1>';
            if(str_contains($item, 'day')){
                for($i = 1; $i <= 7; $i++){
                    $day = $item['day' . $i]
                    include_once('main.php');
                    new Weather($day['date'], $day['temperature_max'], $day['temperature_min'], $day['text'], $day['humidity'], $day['moon_phases_icon'],);
                }
            }
        }
     }
    ?>
</body>
</html>
