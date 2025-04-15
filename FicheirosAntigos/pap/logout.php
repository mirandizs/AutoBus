<?php
    session_start();

    if (isset($_SESSION["email"])){
        session_unset();
        session_destroy(); //var_dump($_SESSION["email"]); var_dump("sessao terminada"); exit();
    }
    header("Location: inicial.php"); 
    exit();
?>