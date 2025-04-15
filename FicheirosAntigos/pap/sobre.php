<p?php
    session_start();
?>

<!DOCTYPE html>
<html lang="pt">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>AutoBus</title>

    <style>
        .gradient {
            background: linear-gradient(180deg, rgb(3,3,59) 0%, rgb(129, 129, 157) 35%,rgb(255, 255, 255) 100%);
            /*background: linear-gradient(rgb(3,3,59), rgb(129, 129, 157), rgb(255, 255, 255));*/
            height: 90px;
            width: 100%;
            margin-bottom: 90px;
        }

        .centrar {
            text-align: center;
            color: rgb(43, 34, 99);
            margin-bottom: 80px;
        }

        .texto {
            text-align: justify;
            margin-left: 150px;
            word-spacing: 5px;
        }
    </style>
</head>
<body>
    <?php include "topbar.php"?>

    <div class="gradient"></div>

    <h1 class="centrar">Sobre nós!</h1>

    <p class="texto">
        Bem-vindo à AutoBus! 
        
        <br><br>
        Somos uma plataforma dedicada a tornar as viagens de autocarro mais simples, acessíveis e convenientes. 
                    Acreditamos que viajar deve ser fácil e sem complicações, <br>e é por isso que criámos um sistema intuitivo para compra de bilhetes, consulta de horários e planeamento de rotas.

        O nosso objetivo é oferecer aos passageiros uma experiência eficiente, garantindo informações precisas e um processo de reserva seguro. Trabalhamos constantemente para melhorar os nossos serviços e facilitar a mobilidade dos nossos utilizadores.

        Junta-te a nós nesta viagem e descobre uma nova forma de explorar o mundo sobre rodas!
    </p>
</body>
</html>