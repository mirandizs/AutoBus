<?php
    session_start();


    require "ligadb.php";

    $sql = "SELECT * FROM utilizadores WHERE email='".$_POST["email"]."';"; 
    $resultado = mysqli_query($con, $sql);
    $registo = mysqli_fetch_array($resultado);

    echo $sql;

    if(!$resultado)
    {
        $_SESSION["erro"] = "Não houve nenhum resultado ";
        header("Location: inicial.php");
        exit();
    }
    

    if($registo)
    {
        //echo $registo["password"];  
        echo $_POST["password"];
        
            // Verifica se a palavra-passe está correta
        if ($registo["password"] == $_POST["password"]) 
        {
            $_SESSION["email"] = $registo["email"];
            $_SESSION["nome"] = $registo["nome"];
            $_SESSION["tipo_utilizador"] = $registo["tipo_utilizador"];
            $_SESSION["atividade"] = $registo["atividade"];
            $_SESSION["nif"] = $registo["nif"];
            $_SESSION["foto"] = $registo["foto"];
            $_SESSION['iniciando'] = true;
            $_SESSION["foto"] = $registo["foto"];


            // Verifica o tipo de utilizador
            if ($registo["tipo_utilizador"] == 0) 
            {
               header("Location: inicial.php");
            }
            
            else 
            {
               header("Location: inicial.php");
            }
            exit();
        }

        else{
            $_SESSION["erro"] = "A palavra passa está incorreta.";
            header("Location: inicial.php");
            exit();
        }
    }
    else{
        $_SESSION["erro"] = "O utilizador não existe.";
        header("Location: inicial.php");
        exit();
    }
?>