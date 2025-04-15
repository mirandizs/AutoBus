<style>
    .footer
    {
        height: 100%;
        margin: 0;
        flex-direction: column;
        background-color: rgba(3, 3, 59);
        color: white;
        bottom: 0;
        width: 100%;
        height: 80px;
        left: 0;
        font-size: 12px;
        padding-top: 5px;
        padding-bottom: 5px;
        bottom: 0%;
    }

    .contact-button {
        background-color: transparent;
        color: white;
        border: none;
        padding: 8px 15px;
        margin-top: 5px;
        margin-left: 40px;
        font-size: 12px;
        cursor: pointer;
        border-radius: 5px;
        
        transition: 0.4s;
    }

    .contact-button:hover {
        transition: scale(1.5);        
    }

    /*.contact-button:hover {
        background-color: lightgray;
    }*/

</style>

<footer class="footer">
    <div style="display: flex; align-items: center;">

        <?php 

            //condição para identificar se a página de viagens está "ativa"
            $nome_pagina = basename($_SERVER['PHP_SELF']); 
            
            //basename para converter o caminho do ficheiro para um nome, ou seja, em vez de localhost/REDES/pap/definicoes.php será apenas definicoes.php

            //qualquer página que seja diferente desta, aparecerá os botões abaixo
            if ($nome_pagina != "definicoes.php" && $nome_pagina != "contacto.php" && $nome_pagina != "criarConta.php" && $nome_pagina != "criarContaFoto.php"){
                echo '
                    <div style="position: absolute; left: 0;">
                        <button class="contact-button"><a href="contacto.php" style="text-decoration: none; color: white;">Contacte-nos!</a></button>
                        <button class="contact-button"><a href=".php" style="text-decoration: none; color: white;">Sobre Nós</a></button>
                    </div>
                ';
            }

            if ($nome_pagina == "contacto.php") { // if para adicionar o número de telefone no footer caso esteja na página de contacto
                echo '
                    <div style="position: absolute; left: 0;">
                        <button class="contact-button">
                            <style>
                                .imagemContact{
                                    margin-right: 5px;
                                    width: 30px; /* Largura da imagem */
                                    height: 30px; /* Altura da imagem */
                                    object-fit: cover;
                                    margin-right: 10px;
                                }
                            </style>
                            <div style="display:flex;">
                                <img class="imagemContact" src="img/telefoneB.png">
                                <a style="padding-top: 7px">+351 916942618</a>
                            </div>
                        </button>
                    </div>
                ';
            }
        ?>
            

        <div style=" margin: 0 auto; text-align:center;">

            <br>

            <!--licenças do site-->
            <p xmlns:cc="http://creativecommons.org/ns#" xmlns:dct="http://purl.org/dc/terms/">
                <span property="dct:title"><strong>AutoBus</strong></span> by <span property="cc:attributionName"><strong>Sofia Miranda</strong></span><br> is licensed under 
                <a href="https://creativecommons.org/licenses/by-nc-nd/4.0/?ref=chooser-v1" target="_blank" rel="license noopener noreferrer" style="display:inline-block; color: white; text-decoration: none;">CC BY-NC-ND 4.0
                    <img style="height:22px!important;margin-left:3px;vertical-align:text-bottom;" src="https://mirrors.creativecommons.org/presskit/icons/cc.svg?ref=chooser-v1">
                    <img style="height:22px!important;margin-left:3px;vertical-align:text-bottom;" src="https://mirrors.creativecommons.org/presskit/icons/by.svg?ref=chooser-v1">
                    <img style="height:22px!important;margin-left:3px;vertical-align:text-bottom;" src="https://mirrors.creativecommons.org/presskit/icons/nc.svg?ref=chooser-v1">
                    <img style="height:22px!important;margin-left:3px;vertical-align:text-bottom;" src="https://mirrors.creativecommons.org/presskit/icons/nd.svg?ref=chooser-v1">
                </a>
            </p>

            <!--<p><strong>By,</strong> Sofia Miranda</p>-->
        </div>
    </div>
</footer>