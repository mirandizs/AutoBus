<?php
    session_start();
?>

<!DOCTYPE html>
<html lang="pt">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" type="text/css" href="contacto.css">
    <script src="contacto.js"></script>
    <title>AutoBus</title>
</head>

<style>
    .imagem {
        width: 650px;
        height: 900px;
        top: 100%;
        bottom: 100%;
        border-radius: 20px;
        margin-left: -20px;
    }

    .column {
        display: flex;
    }

    .left {
        width: 65%;
    }

    .right {
        width: 75%;
    }
</style>

<body>
    <?php include "topbar.php"  ?>
    
    <div>
        <div id="modalVerificacao" class='modal'>
            <div class='modal-contentt animate'>
                <div>
                    <h3></h3>
                    <!-- BOTAO X DE SAIR -->
                    <div class='imgcontainer' id='sair'>
                        <span onclick='verificacao' class='close' title='Close Modal'>&times;</span>
                    </div><br><br>

                    <h3>Email enviado com sucesso!</h3><br>

                    <label>Entraremos em contacto consigo o mais breve possível.</label>
                </div>
            </div>
        </div>

        <div class="column">
            <div class="column left">
                <img src="img/paisagem.jpg" class="imagem">
            </div>

            <div class="column right" style="margin-top: 30px;">
                <div>
                    <h1 class="texto">Entre em contacto conosco!</h1><br><br>

                    <!--<label>Entre em contacto conosco para tirar qualquer dúvida ou resolver qualquer problema.</label>  escrever sobre enviar email-->

                    <form action="contactoEmail.php" method="POST">
                        <label class="texto"><strong>Email: </strong><br><br>
                            <input type="email" name="email" id="email" class="inputs" style="width: 300px; margin-bottom: 50px; padding-left: 10px" placeholder="Insira o seu email..."><br>
                        </label>

                        <label class="texto"><strong>Assunto: </strong><br><br>
                            <input type="text" class="inputs campoTexto" name="assunto" id="assunto" style="width: 300px; margin-bottom: 50px; padding-left: 10px" placeholder="Assunto da mensagem..."><br>
                        </label>

                        <label class="texto"><strong>Mensagem: </strong><br><br>
                            <!--<input type="text" class="inputs" style="width: 600px; height: 300px; align-text:top;"><br>-->
                            <textarea class="inputs campoTexto" name="mensagem" id="mensagem" style="text-align:justify; width: 600px; height: 300px; resize: none; padding-left: 15px; padding-right:15px; font-family: Calibri, Helvetica, sans-serif; padding-top:10px;" placeholder="Texto..."></textarea>
                        </label><br><br><br>

                        <button class="enviar" id="enviarMensagem" name="enviarMensagem" type="submit" disabled>Enviar email</button>

                        <?php
                            if (isset($_SESSION["em_verificacao"])) {

                                unset($_SESSION['em_verificacao']);

                                echo "

                                    <script>
                                        const modal = document.getElementById('modalVerificacao');
                                        modal.style.display = 'block';
                                    </script>
                                ";
                            }
                            else {
                                echo "
                                    <script>
                                        const modal = document.getElementById('modalVerificacao');
                                        modal.style.display = 'none';
                                    </script>";
                            }
                        ?>
                    </form>
                </div>
            </div>
        </div>

        
        <!--botao para voltar para a página anterior-->
        <div class="botaoVoltar" id="botaoVoltar">
            <button class="botaoVolt"><a href="inicial.php" style="text-decoration: none; color: white;">Voltar</a></button>
        </div>


        <!--bolinhas de carregamento -->
        <div id='carregar' class='carregamentoFundo'>
            <div class='carregamento'>
                <div class='dot'></div>
                <div class='dot'></div>
                <div class='dot'></div>
                <div class='dot'></div>
                <div class='dot'></div>
                <div class='dot'></div>
            </div>
        </div>

        <script>
            //função para mostrar a animação do carregamento
            const botaoCarregarEmail = document.getElementById('enviarMensagem');
            const carregarRoda = document.getElementById('carregar');

            botaoCarregarEmail.addEventListener('click', function() {
                console.log('visible')
                carregarRoda.style.display = 'block';
            });

            botaoCarregarPassword.addEventListener('click', function() {
                console.log('visible')
                carregarRoda.style.display = 'block';
            });
        </script>
    </div>

    <?php include "footer.php"?>
</body>
</html>