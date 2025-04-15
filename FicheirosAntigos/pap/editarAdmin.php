<?php
    session_start();

    if (!isset($_POST["botaoEditar"])) {
        header("Location:definicoes.php");
    }

    $nome = $_POST["nome"];
    $nascimento = $_POST["nascimento"];
    $telefone = $_POST["telefone"];
    $localidade = $_POST["localidade"];
    $tipo_utilizador = $_POST["tipo_utilizador"];
    $estado = $_POST["atividade"];

    require "ligadb.php";

    $sql = "UPDATE utilizadores SET nome = '$nome', nascimento = '$nascimento', telefone = '$telefone', localidade = '$localidade',
            tipo_utilizador = '$tipo_utilizador', atividade = '$estado' WHERE nif = '" . $_SESSION["nif"] . "'";

    $result = mysqli_query($con, $sql);

    if(!$result){
        echo "Erro: não foi possível aceder à Base de Dados!";
        exit;
    }

    header("Location: definicoes.php");
?>