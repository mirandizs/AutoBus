<?php
    session_start();
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>AutoBus</title>
    <link rel="stylesheet" type="text/css" href="localidades.css">
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyDHAEqCE6r6dEAYodPFvi1rVlh6-0659bw&loading=async&callback=StartMap" defer></script>
    <style>
        #map {
            height: 300px;
            width: 90%;
            border-radius: 10px;
            margin-top: 30px;
            margin-left: 70px;
            box-shadow: 0 4px 10px 2px rgba(0, 0, 0, 0.2);
        }
    </style>
</head>
<body>
    <?php include "topbar.php"?>

    <br>

    <!--<h2 class="texto">Mapa</h2>-->

    <div id="map">
        <script>
            async function StartMap() {

            const { AdvancedMarkerElement } = await google.maps.importLibrary("marker");

            var latitude = 0;
            var longitude = 0;

            // Buscar localizacao
            navigator.geolocation.getCurrentPosition(function (position) {
                latitude = position.coords.latitude;
                longitude = position.coords.longitude;

                // Criar mapa quando a localizacao for carregada
                const map = new google.maps.Map(document.getElementById("map"), {
                center: { lat: latitude, lng: longitude},
                zoom: 17,
                mapId: "DEMO_MAP_ID", 
                mapTypeId: "satellite"
                });

                const marker = new AdvancedMarkerElement({
                map: map,
                position: { lat: latitude, lng: longitude},
                title: "Uluru",
                });
            });
            }
        </script>
    </div><br><br><br><br><br>

    <h2 class="texto">Partidas e destinos</h2><br><br>

    <p class="centrar">Aqui encontram-se as cidades pelas quais a nossa companhia passa! Entre elas... TODAS DE PORTUGAL!</p><br><br>

    <div class="cidades">
        <div class="caixaImg" style="text-align: center; margin-left: 110px;">
            <img class="imagem" src="img/viana_do_castelo.jpg">
            <p>Viana do Castelo</p>
        </div>
        <div class="caixaImg">
            <img class="imagem" src="img/braga.jpg">
            <p>Braga</p> 
        </div>
        <div class="caixaImg">
            <img class="imagem" src="img/vila_real.jpg">
            <p>Vila Real</p> 
        </div>
        <div class="caixaImg">
            <img class="imagem" src="img/braganca.jpg">
            <p>Bragança</p> 
        </div>
        <div class="caixaImg">
            <img class="imagem" src="img/porto.jpg">
            <p>Porto</p> 
        </div>
        <div class="caixaImg">
            <img class="imagem" src="img/aveiro.jpg">
            <p>Aveiro</p>   
        </div>
    </div><br>

    <div class="cidades">
        <div class="caixaImg" style="margin-left: 110px;">
            <img class="imagem" src="img/viseu.jpg">
            <p>Viseu</p> 
        </div>
        <div class="caixaImg">
            <img class="imagem" src="img/guarda.jpg">
            <p>Guarda</p> 
        </div>
        <div class="caixaImg">
            <img class="imagem" src="img/coimbra.jpg">
            <p>Coimbra</p> 
        </div>
        <div class="caixaImg">
            <img class="imagem" src="img/castelo_branco.jpg">
            <p>Castelo Branco</p> 
        </div>
        <div class="caixaImg">
            <img class="imagem" src="img/leiria.jpg">
            <p>Leiria</p> 
        </div>
        <div class="caixaImg">
            <img class="imagem" src="img/lisboa.jpg">
            <p>Lisboa</p> 
        </div>
    </div><br>

    <div class="cidades">
        <div class="caixaImg" style="margin-left: 110px;">
            <img class="imagem" src="img/santarem.jpg">
            <p>Santarém</p> 
        </div>
        <div class="caixaImg">
            <img class="imagem" src="img/setubal.jpg">
            <p>Setúbal</p> 
        </div>
        <div class="caixaImg">
            <img class="imagem" src="img/portalegre.jpg">
            <p>Portalegre</p> 
        </div>
        <div class="caixaImg">
            <img class="imagem" src="img/evora.jpg">
            <p>Évora</p> 
        </div>
        <div class="caixaImg">
            <img class="imagem" src="img/beja.jpg">
            <p>Beja</p> 
        </div>
        <div class="caixaImg">
            <img class="imagem" src="img/faro.jpg">
            <p>Faro</p> 
        </div>
    </div>

    <!--botao para voltar para a página anterior-->
    <div class="botaoTopo" id="botaoTopo">
            <button class="btTopo" onclick="topFunction()" >Voltar ao topo</button>
    </div>

    <br><br><br>
    <?php include "footer.php"?>

    <script>
        //animação para o botão de ir para o topo da pagina aparecer
        window.addEventListener("scroll", function () {
        let botao = document.getElementById("botaoTopo");
        let alturaPagina = document.documentElement.scrollHeight;
        let alturaVisivel = window.innerHeight;
        let posicaoScroll = window.scrollY;

        // Se o usuário estiver no fim da página, mostra o botão
        if (posicaoScroll + alturaVisivel >= alturaPagina - 50) {
            botao.classList.add("mostrar");
        } else {
            botao.classList.remove("mostrar");
        }
        });


        //funcao para ir ao topo da pagina
        function topFunction() {
        document.body.scrollTop = 0;
        document.documentElement.scrollTop = 0;
        }
    </script>
</body>
</html>