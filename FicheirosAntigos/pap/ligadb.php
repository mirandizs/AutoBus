<?php
    $servername = "localhost";
    $username = "root";
    $password = "";
    $dbname = "pap";

    $con = mysqli_connect($servername, $username, $password, $dbname);

    if (!$con){
        die("Erro ao conectar ao MySQL:". mysqli_connect_error());
    }

    $escolheBD = mysqli_select_db($con,"pap");

    if(!$escolheBD){
        echo "Erro: não foi possível aceder à Base de Dados!";
        exit;
    }