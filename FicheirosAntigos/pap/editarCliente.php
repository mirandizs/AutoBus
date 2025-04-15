<?php
    require "ligadb.php";
    session_start();

    if (!isset($_POST["botaoEditar"])) {
        header("Location:definicoes.php");
    }

    $nif = $_SESSION["nif"];
    $nome = $_POST["nome"];
    $nascimento = $_POST["nascimento"];
    $telefone = $_POST["telefone"];
    $localidade = $_POST["localidade"];
    $tipo_utilizador = $_POST["tipo_utilizador"];
    $estado = $_POST["atividade"];

    $foto = $_FILES['foto'];


    $campos = [
        "nif = '$nif'",
        "nome = '$nome'",
        "nascimento = '$nascimento'",
        "telefone = '$telefone'",
        "localidade = '$localidade'"
    ];


    if (isset($foto)){
        $uploads_directory = "uploads/";

        $file_temp_path = $foto['tmp_name']; 
        $file_extension = ".". pathinfo($foto['name'], PATHINFO_EXTENSION); // Extensao do ficheiro pode variar
        $filename = $nif . $file_extension;
        $targetFilePath = $uploads_directory . $filename; // o nome de utilizador e sempre utilizado como nome do ficheiro

        if (move_uploaded_file($file_temp_path, $targetFilePath)) {
            echo "Uploaded file ".$targetFilePath;
            $campos[] = "foto = '$filename'";
            $_SESSION['foto'] = $filename;
        } else {
            echo "File upload failed!";
        }
    }

    $sql = "UPDATE utilizadores SET " . implode(", ", $campos) .  // Implode estrutura o os campos do array $campos para o update
            "WHERE nif = '" . $_SESSION["nif"] . "'";

    $result = mysqli_query($con, $sql);

    if(!$result){
        echo "Erro: não foi possível aceder à Base de Dados!";
        exit;
    }

    header("Location: definicoes.php");
?>