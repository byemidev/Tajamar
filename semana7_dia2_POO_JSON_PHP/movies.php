<?php
//TODO: Refactor code--> oringin : index.php
//* move the code about fetching here to take another point of view. 
//** Rename some variables as too longer  with short and descriptive names 
//*** Encapsullate methods to call in index.php
//**** try to call the differents parts correctly 

//fetching and return data
    function fetchData(){
        //Warring: check the reload when i trying to find the data into de json file
    //getting (using get) 
    $url = "http://www.holaformacion.com/json/movies.json";
    $json = file_get_contents($url);
    $data = json_decode($json, true);

    return $data;    
    }

    
    function getfilteredData($data, $input){
        foreach($data as $movie){
            $inputArr = preg_split('/\s+/', $input);
            foreach($inputArr as $word){
                if(strpos(($storyLine = $movie['storyline']), $word) !== false){
                    echo infoMovie($movie);
                    continue;
                }elseif($actors == $movie['actors']){//change this code, i need to accesing into movies> actors> and compare for each actor in
                    echo infoMovie($movie);
                }else {
                    echo '<p style="font-weight: 400; color: blue;"> Ninguna coincidencia</p>';
                }
            }
        }
    }


    function infoMovie($movie){
        return '<div><p style="font-weight: bold; font-size: 3rem;">' . '<label>Titulo:<br>' . $movie['title'] . '</label></p><br></div> <p style="font-weight:lighter; font-style: italic; font-size: 1em;"><label>Sinopsis:<br>' . $movie['storyline'] . '</label></p><br>';
    }
?>