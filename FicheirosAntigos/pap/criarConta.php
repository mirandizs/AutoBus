<?php
    session_start();
    //var_dump($_session); 
    //exit();
?>
   
<!DOCTYPE html>
<html lang="pt">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" type="text/css" href="criarContaEstilos.css">
    <link rel="icon" type="image/x-icon" href=""> <!--fav icon-->
    <title>AutoBus</title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script> <!-- Inclua esta linha -->
    <script src="criarContaFuncoes.js"></script>
</head>
<body>
    <main>
        <!--<header><img src="img/busBranco.png"> AutoBus </header>-->
        <div class="box">
            <form action="inserir.php" method="POST" name="form" onsubmit="return validarPasswords()">

            <!--<header>AutoBus</header>-->

            <h1 class="logoTexto">AutoBus</h1>

            <!--<p class="logo"><h1 style="text-align: center;">AutoBus</h1></p>-->

            <h2>Novo Registo</h2>
            
            <div class="row">
                <div class="column left">
                    <label><strong>Nome*</strong></label><br>
                    <input type="text" name="nome" id="nome" style="padding-left:10px;" required>
                    <span id="textoNome"></span><br><br>

                    <label><strong>NIF*</strong></label><br>
                    <input type="tel" name="nif" id="nif" style="padding-left:10px;" required pattern="[125679][0-9]{8}" title="O NIF deve conter 9 números e começar com 1, 2, 5, 6, 7 ou 9." inputmode="numeric" maxlength="9" placeholder="XXXXXXXXX">
                    <span id="textoNif"></span><br><br>

                    <label><strong>E-mail*</strong></label><br>
                    <input type="email" name="email" id="email" style="padding-left:10px;" required pattern="[a-zA-Z0-9._]+@(gmail|yahoo|hotmail)\.com" title="O email deve ser @gmail.com, @yahoo.com ou @hotmail.com" placeholder="exemplo@gmail.com">
                    <span id="textoEmail"></span><br><br>

                    <label for=password><strong>Palavra-Passe*</strong></label><br>
                    <input href="#anchor" type="password" name="password" id="password" class="campoTexto" style="padding-left:10px;"
                            onblur="document.getElementById('messageBox').style.display = 'none';" onclick="scrollToRequirements()"
                            pattern="(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}" title="Deve conter pelo menos um número, uma letra maiúscula e pelo menos 8 ou mais caracteres" required>
                    <span id="textoPass"></span>
                    <button type="button" class="ver" id="verficarPass" onclick="myFunction('password')">
                        <img src="img/fechado.png" id="iconPassword" width="20px" height="20px">
                    </button><br>
                    <p>
                        <strong>* Campo obrigatório.</strong>
                        <a class="mensagemErro" id="error" name="error"></a>
                    </p>
                </div>

                <div class="column right">

                    <label><strong>Data de Nascimento*</strong></label><br>
                    <input type="date" name="nascimento" id="nascimento" style="padding-right:10px; padding-left:10px;" required pattern="\d{2}|\d{3}" title="Tem de ser maior de 18 anos.">
                    <span id="textoIdade" name="textoIdade">
                    </span><br><br>

                    <label><strong>Telemóvel*</strong></label><br>
                    <input type="tel" name="telefone" id="telefone" style="padding-left:10px;" required pattern="9[0-9]{8}" title="O número de telemóvel deve conter 9 números e deve iniciar com 9." maxlength="9" placeholder="9XXXXXXXX">
                    <span id="textoPhone"></span><br><br>

                    <label><strong>Localidade*</strong></label><br>
                    <input type="text" name="localidade" id="localidade" style="padding-left:10px;" placeholder="Ex: Coimbra"required>
                    <span id="textoLocalidade"></span><br><br>

                    <label for=pass><strong>Confirmar palavra-passe*</strong></label><br>
                    <input type="password" name="pass" id="pass" style="padding-left:10px;" pattern="(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}" title="" required >
                    <span id="textoPass2"></span>
                    <button type="button" class="ver" id="verficarPass2" onclick="togglePasswordVisibility('pass')">
                        <img src="img/fechado.png" id="iconPasswordConfirm" width="20px" height="20px">
                    </button>
                </div>
            </div>
            
            
            <a href="inicial.php"><button type="button" value="Voltar" id="botaoo" class="botaoVoltar">Voltar</button></a>
            <button type="submit" value="Criar Conta" id="botao" class="botaoCriar">Avançar</button>

            <div id="popup" class="modal">
                <div class="modal-content">
                    <!--<span class="close">&times;</span>-->
                    <p>As palavras-passe não coincidem.</p>
                    <p class="letra2">Clique em qualquer parte do ecrã para sair.</p>
                </div>
            </div>
            </form>
        </div>
    </main>
    
    <div id="anchor">
        <div class="box2" id="messageBox">
            <h3>A palavra-passe deve conter pelo menos: </h3>
            <p id="letter" class="invalid">Uma letra <b>minúscula</b></p>
            <p id="capital" class="invalid">Uma letra <b>maiúscula</b></p>
            <p id="number" class="invalid">Um <b>número</b></p>
            <p id="length" class="invalid">Mínimo <b>8 caracteres</b></p>
        </div>
    </div>
    <script src="confirmarPass.js"></script>

    <!--<?php //include "footer.php" ?>-->

    <!--<style>
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

    </style>-->
</body>
</html> 