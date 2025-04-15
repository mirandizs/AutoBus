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

        $erroIdade = ""; // Variável para armazenar erro de idade

            if ($_SERVER["REQUEST_METHOD"] == "POST") 
            {
                $nome = test_input($_POST["nome"]);
                $nif = test_input($_POST["nif"]);
                $email = test_input($_POST["email"]);
                $nascimento = test_input($_POST["nascimento"]);
                $telefone = test_input($_POST["telefone"]);
                $local = test_input($_POST["localidade"]);
            }
            else{
                header("Location: inicial.php");
            }

            include "ligadb.php";
            
            $password = $_POST["password"];

            //pesquisa pelo nif
            $existe = "SELECT * FROM utilizadores WHERE nif='".$nif."';";

            $pesquisa = mysqli_query($con, $existe);
            $n_registos = mysqli_num_rows($pesquisa);
            
            //pesquisa pelo email
            $existeEmail = "SELECT * FROM utilizadores WHERE email = '$email'";
            $pesquisaEmail = mysqli_query($con, $existeEmail);
            $n_registosEmail = mysqli_num_rows($pesquisaEmail);


            if ($n_registos == 1)
            {
                exit("<h3>Já existe registos com esse NIF.</h3>");
            }

            // Verifica se o e-mail já existe
            else if ($n_registosEmail > 0) {
                    exit("<h3>Já existe um registo com esse e-mail.</h3>");
            }
            else{
                // Converte a data de nascimento para o formato correto
                $data_nascimento = new DateTime($nascimento);
                $data_atual = new DateTime();
                $idade = $data_atual->diff($data_nascimento)->y;

                if ($idade < 18) {
                    exit("<h3>É necessário ter pelo menos 18 anos para criar uma conta.</h3>");
                } 
  
                $tipo = 1; // tipo utilizador "cliente"
                $estado = 1; //estado da conta "ativo"
                $foto = "null.png";

                $consulta = "INSERT INTO utilizadores
                            VALUES ('".$id."','".$nif."', '".$nome."', '".$nascimento."', '".$telefone."', '".$local."', 
                                    '".$email."', '".$password."',  '".$foto."', '".$tipo."', '".$estado."')";

                $resultado = mysqli_query($con, $consulta);

                //echo "Dados inseridos com suecesso !!";
                //header("Location: inicial.php");
                header("Location: criarContaFoto.php");
            }

            mysqli_close($con);
    ?>

    <!--<br><br><button><a href="entrada.html"> Voltar à entrada</a></button>-->
</body>
</html>