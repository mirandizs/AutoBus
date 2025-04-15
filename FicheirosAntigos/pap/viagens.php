<?php
session_start();
?>

<!DOCTYPE html>
<html lang="pt">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" type="text/css" href="viagens.css">
    <script src="viagens.js"></script>
    <title>Bilhetes</title>
</head>

<body>
    <?php

    include "topbar.php";

    //passagem de parâmetros pelo método GET, da página inicial para esta
    $passageiros = $_GET['passageiros'] ?? '1';
    $n_passageiros = htmlspecialchars($passageiros);
    $local_partida = $_GET['partida'] ?? '...';
    $local_chegada = $_GET['chegada'] ?? '...';
    $data_ida = $_GET['data_ida'] ?? '...';
    $hora_ida = $_GET['hora_ida'] ?? '...';
    $data_volta = $_GET['data_volta'] ?? '...';
    $hora_volta = $_GET['hora_volta'] ?? '...';

    ?>



    <!--<div class='topo' style='padding-left:40px;'>
                <a style='cursor:pointer; color:white' href='inicial.php'>AutoBus</a>
            </div>-->

    <div class='caixaViagens'>

        <form class='caixa' action="viagens.php" method="GET">
            <div class='input-row'>

            </div>
            <!-- Seletor de ida e ida e volta -->
            <div class='trip-type '>
                <label class='radioestilo'><strong>Ida</strong>
                    <input type='radio' name='radioIda' id='radioIda' checked='checked'>
                    <span class='checkmark'></span>
                </label>
                <label class='radioestilo' style='margin-right: 890px;'><strong>Ida e volta</strong>
                    <input type='radio' name='radioIdaVolta' id='radioIdaVolta'>
                    <span class='checkmark'></span>
                </label>

                <button class='botaoTransicao procurar' name='procurar' id='procurar'
                    style='cursor:pointer;'>Procurar</button>
            </div>



            <div class='idaevolta'>
                <label
                    style='color: rgb(43,34,99); font-size: 13px; margin-right: 180px; margin-left: 3px'><strong>Partida</strong></label>
                <label
                    style='color: rgb(43,34,99); font-size: 13px; margin-right: 172px;'><strong>Chegada</strong></label>
                <label
                    style='color: rgb(43,34,99); font-size: 13px; margin-right: 140px;'><strong>Passageiros</strong></label>

                <div id='textoIda' class='janela ativa'>
                    <label
                        style='color: rgb(43,34,99); font-size: 13px; margin-right: 266px;'><strong>Ida</strong></label>
                    <label style='color: rgb(43,34,99); font-size: 13px;'><strong>Hora de Ida</strong></label>
                </div>

                <div id='textoVolta' class='janela'>
                    <label
                        style='color: rgb(43,34,99); font-size: 13px; padding-right: 120px/*305px*/'><strong>Ida</strong></label>
                    <label
                        style='color: rgb(43,34,99); font-size: 13px; padding-right: 115px'><strong>Volta</strong></label>
                    <label style='color: rgb(43,34,99); font-size: 13px; padding-right: 65px'><strong>Hora de
                            Ida</strong></label>
                    <label style='color: rgb(43,34,99); font-size: 13px'><strong>Hora de Volta</strong></label>
                </div>
            </div>

            <!-- campos de origem e destino -->
            <div class='input-row' style='width:100%; margin-bottom: 20px'>
                <div class='input-icon'>
                    <i>📍</i>
                    <input type='text' placeholder=' De: Braga'
                        style='width:150px; padding-left: 50px; margin-right: 15px;' name="partida" value='' />
                </div>
                <div class='input-icon'>
                    <i>📍</i>
                    <input type='text' placeholder=' Para: Porto'
                        style='width:150px; padding-left: 50px; margin-right: 15px;' name="chegada" value='' />
                </div>

                <!-- número de passageiros -->
                <?php
                echo "<div>
                                <select style='width:200px; margin-right: 15px;'>
                                    <option " . ($n_passageiros == 1 && "selected") . " value='1'>1 Adulto</option>
                                    <option " . ($n_passageiros == 2 && "selected") . " value='2'>2 Adultos</option>
                                    <option " . ($n_passageiros == 3 && "selected") . " value='3'>3 Adultos</option>
                                </select>
                            </div>"
                    ?>



                <!-- janela de ida ------------------------------------------------------------------------->
                <div id='janelaIda' class='janela ativa' style='display: block;'>
                    <div class='input-row' style='width:100%; margin-bottom: 10px;'>
                        <!-- seletor de data -->
                        <div class='input-icon'>
                            <input type='date'
                                style='padding-left: 20px; padding-right: 15px; margin-right:15px; width: 240px'
                                value='". htmlspecialchars($data_ida)."'> <!--value='yyyy-MM-dd'-->
                        </div>

                        <div class='input-icon'>
                            <input type='time' style='padding-left: 25px; padding-right: 20px; width:220px;'
                                value='" . htmlspecialchars($hora_ida) . "'>
                        </div>
                    </div>
                </div>




                <!-- janela de voltar ------------------------------------------------------------------------->
                <div id='janelaVolta' class='janela'>
                    <div class='input-row' style='width:100%; margin-bottom: 10px;'>
                        <!-- seletor de data-->
                        <div class='input-icon'>
                            <input type='date' style='padding-left: 10px; padding-right: 10px; margin-right:5px'
                                value='" . htmlspecialchars($data_ida) . "'>
                        </div>
                        <div class='input-icon' style='margin-right: 15px;'>
                            <input type='date' style='padding-left: 10px; width: 113px' value=<?php echo $data_volta ?>>
                        </div>

                        <div class='input-icon'>
                            <input type='time'
                                style='padding-left: 15px; padding-right: 15px; width:100px; margin-right:5px'
                                value=<?php echo $hora_ida ?>>
                        </div>

                        <div class='input-icon'>
                            <input type='time' style='padding-left: 15px; width:104px;' value=<?php echo $hora_ida ?>>
                        </div>
                    </div>
                </div>

            </div>
        </form>
    </div>
    </div>

    <br><br><br>

    <?php

    include "ligadb.php";
    //var_dump($_POST); 
    

    //pesquisa para buscar as informações que foram inseridas nos inputs
    $query = "
    SELECT 
        p1.idautocarro,
        p1.id_ponto AS id_ponto_partida,
        p2.id_ponto AS id_ponto_chegada,
        p1.hora_partida AS hora_partida
    FROM pontos_rotas p1
    INNER JOIN pontos_rotas p2 ON p1.idautocarro = p2.idautocarro
    INNER JOIN autocarro a ON a.idautocarro = p1.idautocarro
    WHERE p1.local = '$local_partida' 
      AND p2.local = '$local_chegada'
      AND p1.hora_partida < p2.hora_partida
    ORDER BY p1.hora_partida ASC;
            ";


    $pesquisa = mysqli_query($con, $query);


    while ($resultado = mysqli_fetch_array($pesquisa)) {
        echo "
                    <div class='caixaBilhete'>
                        <div style='display:inline-flex; justify-items:center; text-align: center'  >
                            <br>
                            <a><strong>" . $local_partida . "  ⮕ " . $local_chegada . "</strong></a>
                            <h2 style='margin-left:390px; margin-top:-4px; float: right; display:flex'>00,00€</h2>
                        </div><br>
                            <a>Hora de partida: " . $resultado["hora_partida"] . "</a>
                            <br><br><br><br><br>

                        <!--<button class='botaoTransicao botaoComprar'>Adicionar ao carrinho</button>-->
                        <!--<form action='' method='POST'>-->
                            <button class='botaoTransicao verMais'>Ver mais detalhes</button>
                        <!--</form>-->
                            
                    <form action='inserirCarrinho.php' method='POST'>
                    
                            <input type='hidden' name='id_ponto_partida' value='" . $resultado["id_ponto_partida"] . "'>
                            <input type='hidden' name='id_ponto_chegada' value='" . $resultado["id_ponto_chegada"] . "'>
                            <input type='hidden' name='local_partida' value='" . $local_partida . "'>
                            <input type='hidden' name='local_chegada' value='" . $local_chegada . "'>
                            <input type='hidden' name='hora_partida' value='" . $resultado["hora_partida"] . "'>
                            <input type='hidden' name='passageiros' value='" . $passageiros . "'>
                            <input type='hidden' name='data_ida' value='" . $data_ida . "'>
                            <input type='hidden' name='data_volta' value='" . $data_volta . "'>
                            <button class='btCarrinho'></button>
                    </form>
                        </div><br>
                ";
    }
    ?>

    <!--botao para voltar para a página anterior-->
    <div class="botaoTopo" id="botaoTopo">
        <button class="btTopo" onclick="topFunction()">Voltar ao topo</button>
    </div>

    <!--// include "footer.php"-->
</body>

</html>