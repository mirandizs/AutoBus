<?php
    session_start();

    //var_dump($_SESSION["nome"]); exit();

    if (!isset(($_SESSION["email"]))) {
        header("Location: inicial.php");
    }

    if (!isset($_SESSION["nif"]) && !isset($_SESSION["tipo_utilizador"])) {
        header("Location: inicial.php");
    }

    require "ligadb.php";

    $consulta = "SELECT * FROM utilizadores WHERE nif = '" . $_SESSION["nif"] . "'";

    $resultado = mysqli_query($con, $consulta);
    
    if(!$resultado){
        echo "Erro: não foi possível aceder à Base de Dados!";
        exit;
    }

    $registo = mysqli_fetch_array($resultado);
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>AutoBus</title>
</head>

<style>
    body{
        padding: 30px;
        align-items: center;
        justify-content: center;
        font-family: Calibri, Helvetica, sans-serif;
        /*background-color: rgba(7, 3, 39, 0.849);*/
        background-color: rgb(3,3,59);
    }

    .caixa {
        color: rgba(3, 3, 56, 0.945);
        padding-top: 10px;
        padding-left: 20px;
        width: 500px;
        height: 480px; 
        border-radius: 10px;
        border-color: rgba(3, 3, 56, 0.945);
        background-color: rgb(255, 255, 255); /* Cor de fundo adicionada */
        box-shadow: 0 4px 10px 2px rgba(0, 0, 0, 0.4);
        
        margin-top: 60px;
        margin-bottom: 10px;
        margin-left: 470px;
        margin-right: 200px;
    }

    .logoTexto{
        width: 100% ;
        padding-top: 2px;     
        text-align: center;
        top: 0;              
        left: 0;  
        position: fixed;  
        z-index: 0;
        font-size: xx-large;
        color: rgb(255, 255, 255);
        text-align: center;
        font-weight: bold;
    }

    .imagemUti {
        margin-left: 130px;
        margin-top: 10px;
        margin-bottom: 5px;
        height: 220px;
        width: 220px;
    }

    
    .file-label {
        position: relative;
        left: 28%;
        display: inline-block;
        padding: 10px 20px;
        background-color: #007bff;
        color: white;
        font-size: 16px;
        border-radius: 5px;
        cursor: pointer;
        transition: background 0.3s;
        margin-top: 10px;
    }

    .file-label:hover {
        background-color: #0056b3;
    }

    .file-input {
        display: none;
    }

    .botaoCriarConta {
        background-color: rgba(3, 3, 56, 0.945);
        color: white;
        font-weight: 10px;
        width: 110px;
        border: 0;
        padding: 10px;
        border-radius: 4px;
        cursor: pointer;
        margin-bottom: 20px;
        margin-top: 20px;
    }

    .botaoCriarConta:hover {
        
        background-color: rgba(15, 15, 120, 0.945);
    }

    .imagemVolt {   
        width: 40px; /* Largura da imagem */
        height: 40px; /* Altura da imagem */
        object-fit: cover;
    }
</style>

<body>
    <main>
        <h1 class="logoTexto">AutoBus</h1>
            <div class="caixa">
                <form action="updateFotoConta.php" method="POST">
                    <div style="display:flex; align-items: center;">
                        <a href="criarConta.php" style="text-decoration: none; color: white; padding-right: 20px;">
                                <img class="imagemVolt" src="img/voltarr.png">
                        </a>
                        
                        <h2 style="">Foto de perfil</h2>
                    </div>

                    <br>

                    <label style="margin-left: 70px;">Insira uma imagem para o teu perfil de utilizador!</label><br><br>
                    
                    <a>
                        <img class='imagemUti' id='preview'src="<?= 'uploads/' . $registo['foto'] ?>" onerror='this.src="img/default.png"'>
                    </a>

                    <script>
                        function previewImage(event) {
                            var reader = new FileReader();
                            reader.onload = function() {
                                var output = document.getElementById('preview');
                                output.src = reader.result;
                            };
                            reader.readAsDataURL(event.target.files[0]);
                        }
                    </script>

                    <br>
                    <label for="file" class="file-label" >Selecione uma imagem</label>
                    <input type="file" accept="image/*" id="file" class="file-input" name="foto" onchange="previewImage(event)">
                    <br>
                    
                    <a href="incial.php"><button type='button' class="botaoCriarConta" id='botaoAvancar' name='botaoAvancar' disabled style='margin-right: 250px; margin-left:5px'>Alterar depois</button></a>
                    <button type='submit' class="botaoCriarConta" id='botaoCriarConta' name='botaoCriarConta' style=''>Criar conta</button>
                </form>    
            </div>
        </main>
    <?php include "footer.php" ?>
    

    <style>
        .footer
        {
            background-color: rgba(3, 3, 59);
            color: white;
            display: block;
            bottom: 0;
            width: 100%;
            height: 40px;
            left: 0;
            font-size: 12px;
            padding-top: 5px;
        }

    </style>
</body>
</html>