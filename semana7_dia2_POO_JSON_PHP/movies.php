<?php
//TODO: Refactor code--> oringin : index.php
//* move the code about fetching here to take another point of view. 
//** Rename some variables as too longer  with short and descriptive names 
//*** Encapsullate methods to call in index.php
//**** try to call the differents parts correctly 

//fetching and return data
    function getData(){
        //Warring: check the reload when i trying to find the data into de json file
    //getting (using get) 
    $url = "http://www.holaformacion.com/json/movies.json";
    $json = file_get_contents($url);
    $data = json_decode($json, true);

    return $data;    
    }

    
    function getfilteredData($data, $input){
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