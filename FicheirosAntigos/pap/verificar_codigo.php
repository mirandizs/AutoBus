<?php
    session_start();

    require "ligadb.php";

    if ($_SERVER['REQUEST_METHOD'] === 'POST') {
        $codigoInserido = $_POST['codigo'];
        $codigoEnviado = $_SESSION['codigo_verificacao'] ?? null;

        if ($codigoInserido === $codigoEnviado) {
            //echo "Código verificado com sucesso!";
            // Aqui pode redirecionar ou executar outra lógica

            unset($_SESSION["codigo_verificacao"]);
            unset($_SESSION['em_verificacao']);
            var_dump($_SESSION["codigo_verificacao"]);  // Deve retornar NULL ou não exibir nada.

            $email = $_SESSION["mudarEmail"]; 
            $password = $_SESSION["mudarPassword"]; 
            $nif = $_SESSION["nif"];

            $sqlConsulta = "UPDATE utilizadores SET email = '$email', password = '$password' WHERE nif = '$nif'";
        
            $resultado = mysqli_query($con, $sqlConsulta);

            if(!$resultado){
                echo "Erro: não foi possível aceder à Base de Dados!";
                exit;
            }

           header("Location: definicoes.php");
        } else {
            echo "O código está incorreto. Tente novamente.";
        }
    } else {
        echo "Acesso inválido.";
    }
?>