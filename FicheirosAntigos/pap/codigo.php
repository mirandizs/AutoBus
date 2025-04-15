<?php
    session_start();

    require "ligadb.php";

    // Função para gerar código aleatório de 6 dígitos
    function gerarCodigoAleatorio() {
        return str_pad(rand(0, 999999), 6, '0', STR_PAD_LEFT);
    }

    $code = gerarCodigoAleatorio();

    // Armazenar o código na sessão
    $nome = $_SESSION["nome"];
    $_SESSION['codigo_verificacao'] = $code;
    $_SESSION['mudarEmail'] = $_POST["email"]; 
    $_SESSION['mudarPassword']= $_POST["password"]; 
    $_SESSION['em_verificacao'] = true;
    
    $receiver = $_SESSION["email"]; //quem recebe 
    $sender = "From:AutoBus"; //quem envia o email
    $subject = "Código de Verificação";

    $body = "
        <div style='
            padding-top: 20px;
            padding-left: 20px;
            padding-right: 20px;
            width: 620px;
            height: 490px; 
            border-radius: 10px;
            background-color: rgb(3,3,59); /* Cor de fundo */
        '>
            <div style='
                color: black;
                padding-top: 10px;
                padding-left: 20px;
                padding-right: 20px;
                width: 580px;
                height: 450px; 
                border-radius: 10px;
                border: 1px solid rgba(3, 3, 56, 0.945); /* Bordas */
                background-color: rgb(255, 255, 255); /* Cor de fundo */
                box-shadow: 0 4px 10px 2px rgba(0, 0, 0, 0.4); /* Sombra */
                margin-bottom: 10px;
                margin-right: 200px;
            '>
                <h1 style='text-align: left;padding-left: 10px;color: rgb(0, 0, 150);'>AutoBus</h1>

                <hr style='border: 1px solid rgb(0, 0, 150); margin-left: 10px; margin-right: 10px; width: 540px;'><br>

                <div style='margin-left: 10px; color:black; word-wrap: break-word; white-space: normal; overflow-wrap: break-word;'>
                    <p>Olá, <strong style='color:rgb(0, 0, 150)'>$nome</strong></p>
                    <p style='word-wrap: break-word; padding-bottom: 15px; white-space: normal; overflow-wrap: break-word;'>Agradecemos por utilizar o Autobus. Para continuar com a tua verificação, utiliza o código abaixo:</p>
                    <h2 style='color: rgb(30, 0, 200);padding-bottom: 15px'>$code</h2>
                    <p style='padding-bottom: 15px'>Se não foste tu a solicitar este código, por favor, ignore este email.</p>

                    <p>Atenciosamente,<br>
                       <strong style='color:rgb(110, 110, 110)'>Equipa Autobus.</strong></a>
                    </p>
                </div>
            </div>
        </div>
    ";

    
    $headers = "MIME-Version: 1.0" . "\r\n";
    $headers .= "Content-Type: text/html; charset=UTF-8" . "\r\n";
    $headers .= "From: AutoBus <autobus.pap@gmail.com>" . "\r\n";
    $headers .= "Reply-To: autobus.pap@gmail.com" . "\r\n";


    if(mail($receiver, $subject, $body, $headers, $sender)){
        header("Location: definicoes.php");
    }else{
        echo "Sorry, failed while sending mail!";
    }
?>