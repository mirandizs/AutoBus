<!DOCTYPE html>
<html lang="pt">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>
<body>
    <?php
        require "ligadb.php";
        session_start();
    
        if (!isset($_POST["botaoCriarConta"])) {
            header("Location:criarConta.php");
        }
    
        $foto = $_FILES['foto'];

        if (isset($foto)){
            $uploads_directory = "uploads/";
    
            $file_temp_path = $foto['tmp_name']; 
            $file_extension = ".". pathinfo($foto['name'], PATHINFO_EXTENSION); // Extensao do ficheiro pode variar
            $filename = $nome . $file_extension;
            $targetFilePath = $uploads_directory . $filename; // o nome de utilizador e sempre utilizado como nome do ficheiro
    
            if (move_uploaded_file($file_temp_path, $targetFilePath)) {
                echo "Uploaded file ".$targetFilePath;
                $campos[] = "foto = '$filename'";
            } else {
                echo "File upload failed!";
            }
        }

        $sql = "UPDATE utilizadores SET foto = '".$foto."' WHERE nif = '" . $_SESSION["nif"] . "'";

        $result = mysqli_query($con, $sql);

        if(!$result){
            echo "Erro: não foi possível aceder à Base de Dados!";
            exit;
        }

        header("Location: inicial.php");
    ?>
</body>
</html>