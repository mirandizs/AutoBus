<?php
    session_start();
    //var_dump($_session); exit();
?>
   
<!DOCTYPE html>
<html lang="pt">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>
<body>
    <!--<h3>Inserido com suecesso</h3>-->

    <?php
        function test_input($data) 
        {
            $data = trim($data);
            $data = stripslashes($data);
            $data = htmlspecialchars($data);
            return $data;
        }

        if ($_SERVER["REQUEST_METHOD"] == "POST") 
        {
            $metodo = $_SESSION["metodoPagamento"];
            $nome_titular = test_input($_POST["nome_cartao"]);
            $numero_cartao = test_input($_POST["numero_cartao"]);
            $validade = test_input($_POST["validade"]);
            $cvv = test_input($_POST["cvv"]);
            $id_utilizador = $_SESSION["id_utilizador"];
        }
        else{
            header("Location: carrinho.php");
        }

        include "ligadb.php";
        
        $numero_cartao = $_POST["numero_cartao"];

        //pesquisa pelo id do utilizador 
        $existe = "SELECT id_utilizador FROM pagamentos WHERE id_utilizador='".$id_utilizador."';";

        $pesquisa = mysqli_query($con, $existe);
        $n_registos = mysqli_num_rows($pesquisa);
        
        //pesquisa pelo cartao
        $existeCartao = "SELECT * FROM pagamentos WHERE numero_cartao = '$numero_cartao'";
        $pesquisaCartao = mysqli_query($con, $existeCartao);
        $n_registosCartao = mysqli_num_rows($pesquisaCartao);


        if ($n_registos == 1)
        {
            exit("<h3>Já existe um pagamento associado a este utilizador.</h3>");
        }

        // Verifica se o e-mail já existe
        else if ($n_registosCartao > 0) {
                exit("<h3>Este cartão já está registado em outra conta.</h3>");
        }
        else{
            $consulta = "INSERT INTO pagamentos (metodo, nome_cartao, numero_cartao, validade, cvv, id_utilizador)
                            VALUES ('$metodo', '$nome_titular', '$numero_cartao', '$validade', '$cvv', '$id_utilizador')";

            $resultado = mysqli_query($con, $consulta);

            //echo "Dados inseridos com suecesso !!";
            //header("Location: inicial.php");
            header("Location: carrinho.php");
        }

        mysqli_close($con);
    ?>

    <!--<br><br><button><a href="entrada.html"> Voltar à entrada</a></button>-->
</body>
</html>