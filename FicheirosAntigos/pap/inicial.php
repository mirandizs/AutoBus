<?php
    session_start();
    //var_dump($_session); exit();

    //echo $_SESSION["erro"];
    //unset($_SESSION["erro"]);

    /*if (isset($_SERVER['HTTP_REFERER'])) {
        $referrer = $_SERVER['HTTP_REFERER'];
        echo "This page was redirected from: " . htmlspecialchars($referrer);
    } else {
        echo "No referrer information is available.";
    }*/
?>
   
<!DOCTYPE html>
<html lang="pt">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="icon" type="image/x-icon" href=""> <!--fav icon-->
    <link rel="stylesheet" type="text/css" href="inicial.css">
    <title>AutoBus</title>
    <script src="inicial.js"></script>
</head>



<body>
    <main>
        <?php include "topbar.php"  ?>

        <div class="header"></div>

        <div class="caixaViagens">

            <h1 class="titulo" style="color:rgb(3, 3, 59);">Descobre Portugal!</h1><Br>

            <form action="viagens.php" method="GET">
                <div class="caixa">
                    <!-- Seletor de ida e ida e volta -->
                    <div class="trip-type">
                        <label class="radioestilo"><strong>Ida</strong>
                            <input type="radio" name="radioIda" id="radioIda" checked="checked"> 
                            <span class="checkmark"></span>
                        </label>
                        <label class="radioestilo"><strong>Ida e volta</strong>
                            <input type="radio" name="radioIdaVolta" id="radioIdaVolta">
                            <span class="checkmark"></span>
                        </label>
                    </div>
                    
                    

                    <div class="idaevolta">
                        <label name="" style="color: rgb(43,34,99); font-size: 13px; margin-right: 250px"><strong>Partida</strong></label>
                        <label name="" style="color: rgb(43,34,99); font-size: 13px; margin-right: 230px"><strong>Chegada</strong></label>
                        <label name="" style="color: rgb(43,34,99); font-size: 13px;"><strong>Passageiros</strong></label>
                    </div>

                    <!-- campos de origem e destino -->
                    <div class="input-row" style="width:100%; margin-bottom: 20px">
                        <div class="input-icon" >
                            <i>📍</i>
                            <!--partida-->
                            <input type="text" placeholder=" De: Braga" style="width:215px; padding-left: 50px; margin-right: 15px;" name="partida" id="partida"/>
                        </div>
                        <div class="input-icon">
                            <i>📍</i>
                            <input type="text" placeholder=" Para: Porto" style="width:205px; padding-left: 50px; margin-right: 15px;" name="chegada" id="chegada"/>
                        </div>

                        <!-- número de passageiros -->
                        <select style="width:230px; cursor:pointer;" name="passageiros" id="passageiros">
                            <option>1 Adulto</option>
                            <option>2 Adultos</option>
                            <option>3 Adultos</option>
                        </select>
                    </div>


                    
                    
                    <div class="input-row">

                        <!-- janela de ida ------------------------------------------------------------------------->
                        <div id="janelaIda" class="janela ativa" style="display: block;">
                            <div class="idaevolta">
                                <label name="" style="color: rgb(43,34,99); font-size: 13px; padding-right: 272px"><strong>Ida</strong></label>
                                <label name="" style="color: rgb(43,34,99); font-size: 13px; padding-right: 65px"><strong>Hora de Ida</strong></label>
                                <!--<label name="" style="color: rgb(43,34,99); font-size: 13px"><strong>Passageiros</strong></label>-->
                            </div>

                            <div class="input-row" style="width:100%; margin-bottom: 10px;">
                                <!-- seletor de data -->
                                <div class="input-icon">
                                    <input type="date" value="yyyy-MM-dd" style="padding-left: 20px; padding-right: 15px; margin-right:15px; width: 240px; height:20.85px; cursor:pointer;" 
                                           name="data_ida" id="data_ida">
                                </div>

                                <!-- seletor de hora -->
                                <div class="input-icon">
                                    <input type="time" value="" style="padding-left: 25px; padding-right: 20px; width:220px; margin-right:15px; cursor:pointer;"
                                           name="hora_ida" id="hora_ida">
                                </div>
                            </div>
                        </div>



                        <!-- janela de voltar ------------------------------------------------------------------------->
                        <div id="janelaVolta" class="janela">                    
                            <div class="idaevolta">
                                <label name="" style="color: rgb(43,34,99); font-size: 13px; padding-right: 125px/*305px*/"><strong>Ida</strong></label> 
                                <label name="" style="color: rgb(43,34,99); font-size: 13px; padding-right: 115px"><strong>Volta</strong></label>
                                <label name="" style="color: rgb(43,34,99); font-size: 13px; padding-right: 70px"><strong>Hora de Ida</strong></label> 
                                <label name="" style="color: rgb(43,34,99); font-size: 13px"><strong>Hora de Volta</strong></label> 
                                <!--<label name="" style="color: rgb(43,34,99); font-size: 13px"><strong>Passageiros</strong></label>-->
                            </div>

                            <div class="input-row" style="width:100%; margin-bottom: 10px;">
                                <!-- seletor de data-->
                                <div class="input-icon">
                                    <input type="date" value="yyyy-MM-dd" style="padding-left: 10px; padding-right: 10px; margin-right:5px; height:20.85px; cursor:pointer;"
                                           name="data_ida" id="data_ida">
                                </div>
                                <div class="input-icon" style="margin-right: 15px;">
                                    <input type="date" value="yyyy-MM-dd"  style="padding-left: 10px; width: 113px; height:20.85px; cursor:pointer;"
                                           name="data_volta" id="data_volta">
                                </div>

                                <!-- seletor de data -->
                                <div class="input-icon">
                                    <input type="time" value="" style="padding-left: 15px; padding-right: 15px; width:100px; margin-right:5px; cursor:pointer;"
                                           name="hora_ida" id="hora_ida">
                                </div>

                                <div class="input-icon">
                                    <input type="time" value="" style="padding-left: 15px; width:104px; margin-right:15px; cursor:pointer;"
                                           name="hora_volta" id="hora_volta">
                                </div>
                            </div>
                        </div>
                            
                        <input type="submit" id="btProcurar" name="btProcurar" value="Procurar" class="botaoTransicao botaoProcurar"></input>
                    </div>
                </div>
            </form>
        </div>





        <br><br><br><br>
        <h2 class="textoAzul" style="text-align:center">Vantagens de ser um membro AutoBus!</h2><br><br>
        <!--<p style="text-align:center">As vantagens em ter uma conta conosco são imensas!</p><br><br>-->

        <div class="caixaVantagens">
            <div class="vantagens_separada" style="padding-top: 7px">
                <img src="img/mapaA.png" class="vantagens">
                <label class="texto">
                    <h3>Mapa e localidades</h3>
                    <p>Fica a conhecer todas as localidades para onde podes viajar e descobrir Portugal com a AutoBus.</p>
                </label>
            </div>
            
            <div class="vantagens_separada">
                <img src="img/confortoA.png" style="width: 70px; height: 55px;"> 
                <label class="texto">
                    <h3>Conforto</h3>
                    <p>Os nossos autocarros estão equipados com assentos grandes e confortáveis, WC, Wi-Fi, tomadas e ar-condicionado.</p>
                </label>
            </div>

            <div class="vantagens_separada">
                <img src="img/contactoA.png" class="vantagens" style="width: 60px; height: 55px;" > 
                <label class="texto">
                    <h3>Entre em contacto!</h3>
                    <p>Precisas de ajuda? Fale conosco por linha telefónica, email ou através do nosso site!</p>
                </label>
            </div>
        </div><br><br><br>
        
        <!--botao para voltar para a página anterior-->
        <div class="botaoTopo" id="botaoTopo">
            <button class="btTopo" onclick="topFunction()" >Voltar ao topo</button>
        </div>
    </main>
    <br>

    <?php include "footer.php"?>
</body>
</html>