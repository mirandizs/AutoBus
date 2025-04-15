<?php
    session_start();

    require "ligadb.php";

    //var_dump($_SESSION['email']); exit();

    //var_dump($_POST); exit();

    $_SESSION['em_verificacao'] = true;

    
    if (!isset($_SESSION["id_utilizador"])&& isset($_POST['email'])) 
    {
        $email = mysqli_real_escape_string($con, $_POST['email']);

        $query = "SELECT id_utilizador, nome, nif FROM utilizadores WHERE email='$email'";

        $result = mysqli_query($con, $query);
    
        if ($row = mysqli_fetch_assoc($result)) {
            $_SESSION['id_utilizador'] = $row['id_utilizador'];
            $_SESSION['nome'] = $row['nome'];
            $_SESSION['nif'] = $row['nif'];
        }
    }

    $idutilizador = $_SESSION['id_utilizador'];
    $nif_utilizador = $_SESSION['nif'];
    $nome_utilizador = $_SESSION['nome'];
    $email_utilizador = $_POST['email'];
    $assunto = $_POST["assunto"];
    $mensagem = $_POST["mensagem"];
    
    //var_dump($mensagem); exit;

    $msg = htmlspecialchars($mensagem); // Evita conversões desnecessárias

    /*$msg = ltrim(wordwrap($mensagem,  70, "\n", true));
    //Xecho $msg;exit;
    $msg = str_replace("<wbr>", "", $msg);
    $msg = nl2br(htmlspecialchars($msg));*/

    $receiver = "autobus.pap@gmail.com"; // E-mail do admin
    $sender = "From:" . $nome_utilizador; //quem envia o email
    $subject = $assunto;

    $body = "
                <div style='
                padding-top: 20px;
                padding-left: 20px;
                padding-right: 20px;
                width: 620px;
                height: 490px; 
                border-radius: 10px;
                background-color: rgb(3,3,59);
            '>
                <div style='
                    color: black;
                    padding-top: 10px;
                    padding-left: 20px;
                    padding-right: 20px;
                    width: 580px;
                    height: 450px; 
                    border-radius: 10px;
                    border: 1px solid rgba(3, 3, 56, 0.945);
                    background-color: rgb(255, 255, 255);
                    box-shadow: 0 4px 10px 2px rgba(0, 0, 0, 0.4);
                    margin-bottom: 10px;
                    margin-right: 200px;
                '>
                    <h1 style='text-align: left;padding-left: 10px;color: rgb(0, 0, 150);'>AutoBus</h1>

                    <hr style='border: 1px solid rgb(0, 0, 150); margin-left: 10px; margin-right: 10px; width: 550px;'><br>

                    <div style='margin-left: 10px; color:black; word-wrap: break-word; white-space: normal; overflow-wrap: break-word;'>
                        <p>Id do utilizador: <strong style='color:rgb(0, 0, 150)'>$idutilizador</strong><br>
                            NIF: <strong style='color:rgb(0, 0, 150)'>$nif_utilizador</strong>
                        </p>

                        <p> Nome do utilizador: <strong style='color:rgb(0, 0, 150)'>$nome_utilizador</strong><br>
                            Email: <strong style='color:rgb(0, 0, 150)'>$email_utilizador</strong>
                        </p><br>

                        <div style='display: flex; /*align-items: center;*/'>
                            <p style='margin-right: 10px;'>Mensagem: </p>
                            
                            <div style='
                                display: block;
                                width: 460px; 
                                height: 150px; 
                                white-space: normal;
                                word-wrap: normal;
                                word-break: normal;
                                border: 2px solid rgb(224, 224, 224); 
                                border-radius: 4px;
                                font-weight: bold;
                                color: rgb(0, 0, 150);
                                font-family: Calibri;
                                font-size: 16px;
                                margin-top:12px;
                                padding-top: 5px;
                                padding-right:15px;
                                padding-left:10px;
                                overflow-y: auto;
                                text-align:justify;
                            '><div style='white-space: pre-wrap;'>$msg</div>
                    </div>
                </div>
            </div>
        ";

    // Cabeçalhos do e-mail 
    $headers = "MIME-Version: 1.0\r\n" .
                "From: " . $email_utilizador . "\r\n" .
                "Reply-To: " . $email_utilizador . "\r\n" .
                "Content-Type: text/html; charset=UTF-8" . "\r\n";

    if (mail($receiver, $subject, $body, $headers, $sender)) {
        header("Location: contacto.php");
    } else {
        echo "Sorry, failed while sending mail!";
    }
?>