<?php

//Warring: check the reload when i trying to find the data into de json file
//obtener (mediante get) 
$url = "http://www.holaformacion.com/json/movies.json";
$json = file_get_contents($url);
$data = json_decode($json, true);
//tengo mostrar los inputs para la busqueda antes  
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>buscar peliculas</title>
</head>
<body>
    <form action="" method="post">
        <label for="findMovieBySipnosis">Buscar por sipnosis: <input id="findMovieBySipnosis" type="text" placeholder="aqui nombre por sipnosis" name="findMovieBySipnosis"> <button type="submit">Buscar</button></label>
    </form>
    <form action="" method="post">
        <label for="findMovieByActor">Buscar por actor: <input id="findMovieByActor" type="text" placeholder="aqui nombre actor" name="findMovieByActor"> <button type="submit">Buscar</button></label>
    </form>
</body>
</html>
<?php
//input 
// Check if the form was submitted
if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    // Check which form was submitted
    if (isset($_POST['submitSipnosis'])) {
        $inFindMovieByStoryLine = $_POST['findMovieBySipnosis'];
        $inFindMovieByStoryLine = htmlspecialchars(trim($inFindMovieBySipnosis));
        //TODO: find in the data about sipnosis trying to match the input and the data.
        //TODO: Show the output in a new window
        //TODO this i can to make a function with out this logic , and call to catch the return values
        //TODO: check the result 
        $result = getfilteredData($inFindMovieBySipnosis);
        echo $result;
    }
    elseif (isset($_POST['submitActor'])) {
        $inFindMovieByActor = $_POST['findMovieByActor'];
        $inFindMovieByActor = htmlspecialchars(trim($inFindMovieByActor));
        //TODO: find in the data about actor trying to match the input and the data.
        //TODO: Show the output in a new window
    }
}


$counterMovies = 0; //to count movies 
foreach($data as $item){
    $counterMovies++;
    echo '<hr>';
    echo '<p style="font-weight: bold; font-size: 3rem;">' . '<label>Titulo:' . $item['title'] . '</label></p><br>';
    echo '<p style="font-weight: lighter; font-size: 1.3rem;">' . '<label>año:' . $item['year'] . '</label></p><br>';


    if($item['actors']){
        //to count actors
        $counterActors = 0;
        foreach($item['actors'] as $actor){
            $counterActors++;
            echo '<p>' . $actor .'</p>';
        }
        echo '<br>';
    }
    //total actores
    echo '<p style="font-weight: 400; color: blue;"> Total actores es de ' . $counterActors . '</p>';
}
//total peliculas
echo '<p style="font-weight: 400; color: blue; display: top;"> Total peliculas es de ' . $counterMovies. '</p>';


function getfilteredData($input){
    foreach($data as $item){
        //covert string in string's array
        $inputArr = str_split($input, '');

        foreach($word as $inputArr){
            if(strpos(($storyLine = $item['storyline']), $word) !== false){
                echo 'estoy aqui ';
                return '<div>' . $item['title'] . '<br><p>'. $storyLine .'</p></div>';
            }elseif($actors == $item['actors']){    
                //Todo
            }else {
                return '<div style="width: 100%; background-color: red;"><p>Ninguna coincidencia</p></div>';
            }
        }
    }
}

?>

