    <?php
        session_start();
        //var_dump($_SESSION); exit();
        // verificar se existe uma sessão iniciada
        /*if ( ! isset($_SESSION["utilizador"]) ) {
            $_SESSION["mensagem"] = "Inicie sessão para efetuar compras.";
            Header("Location: inicial.php");
        }*/

        require "ligadb.php";

        $consulta = "SELECT * FROM utilizadores WHERE nif = '" . $_SESSION["nif"] . "'";

        $resultado = mysqli_query($con, $consulta);
        
        if(!$resultado){
            echo "Erro: não foi possível aceder à Base de Dados!";
            exit;
        }

        $registo = mysqli_fetch_array($resultado);

        if (isset($_SESSION['metodoPagamento'])) {
            $metodoPagamento = $_SESSION['metodoPagamento'];
        } else {
            $metodoPagamento = null; // Caso o método de pagamento não tenha sido definido
        }
    ?>

    <!DOCTYPE html>
    <html lang="pt">
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <link rel="stylesheet" type="text/css" href="carrinho.css">
        <title>AutoBus</title>
    </head>
    <body>
        <?php include "topbar.php"?>

        <div class="row">
            <div class="column left">
            
                <h1 class="titulo">Meu carrinho</h1>

                <h2 style="text-align: center; margin-bottom:70px; color: rgb(5, 5, 96);">Bilhetes</h2>

                <?php 
                    /*require "ligadb.php";
                    
                    $query = "SELECT FROM carrinho WHERE id_utilizador= " . $_SESSION["id_utilizador"] . ";";

                    $consulta = mysqli_query($con, $query);

                    while ($resultado = mysqli_fetch_array($pesquisa)){
                        echo "
                            <div class='caixaBilhete'>
                                <div style='display:inline-flex; justify-items:center; text-align: center'>
                                    <br>
                                    <a><strong>".$local_partida."  ⮕ " . $resultado['local'] . "</strong></a>
                                    <h2 style='margin-left:390px; margin-top:-4px; float: right; display:flex'>00,00€</h2>
                                </div><br>

                                <a style='margin-right:400px;'>Hora de partida: ".$resultado["hora_partida"]."</a>

                                <button class='btCarrinho'></button> //imagem de remover do carrinho
                            </div>"
                        ;
                    }*/
                ?>

                <div class='caixaBilhete'>
                    <div style='display:inline-flex; justify-items:center; text-align: center'>
                        <br>
                        <a><strong>".$local_partida."  ⮕ " . $resultado['local'] . "</strong></a>
                        <h2 style='margin-left:500px; margin-top:-4px; float: right; display:flex'>00,00€</h2>
                    </div><br>

                    <a style='margin-right:360px;'>Hora de partida: ".$resultado["hora_partida"]."</a>

                    
                    <button class='btCarrinho'></button>
                    <!--<button class='botaoTransicao verMais'></button>-->
                </div>
            </div>

            <div class="column right">
                <h2 style="text-align: center; margin-top: 140px; margin-bottom:70px; color: rgb(5, 5, 96);">Resumo da compra:</h2>

                <div class="caixaTotal">
                    <label><strong>Total a pagar: <?php $preco ?></strong></label>

                    <hr style='border: 1px solid black; margin-left: 0px; margin-right: 10px; margin-top: 20px; width: 380px;'><br>

                    <button id="openModal" class="botaoFinalizar botaoTransicao">Finalizar compra</button> <!--para ao clicar, aparecer o formulario de pagamento-->
                </div>

                 <!-- Exibir o método de pagamento selecionado
                <div class="caixaMetodoPagamento">
                    <?php //if ($metodoPagamento !== null): ?>
                        <p>Método de pagamento selecionado: <?php //echo htmlspecialchars($metodoPagamento); ?></p>
                    <?php //else: ?>
                        <p>Nenhum método de pagamento selecionado.</p>
                    <?php //endif; ?>
                </div>-->
            </div>
        </div>


        
        <div class="modalFUNDO"> <!-- fundo fixo para todos os modals -->

            <!-- CAIXA DE PAGAMENTO ---------------------------------------------------------------> 
            <div id="modalMetodo" style="display:none;" class="modalSlidein">
                <div class="modalpay" id="fundoPagamento">
                    <div class="modal-payment">
                        <button class="fechar" id="fecharModal">✖</button>
                        <h2 style="color: rgb(0, 0, 150); margin-bottom: 50px; margin-left: 20px;">Método de pagamento</h2>

                        <div class="caixaEscolha" style="display: flex;">
                            <button id="btnCartao" class="btnEscolha" style="display:flex; padding-top: 10px;">
                                <label style="margin-right:120px; margin-top:6px; cursor:pointer;">Cartão de crédito</label>
                                <img src="img/cartoes.png" style="height: 25px; width: 25;">
                            </button>
                        </div>
                        <div class="caixaEscolha" style="margin-bottom:30px;">
                            <button id="btnMbway" class="btnEscolha"  style="display:flex; padding-top: 10px;">
                                <label style="margin-right:180px; margin-top:6px; cursor:pointer;">MB WAY</label>
                                <img src="img/mbway.png" style="height: 25px; width: 25;">
                            </button>
                        </div>
                    </div>
                </div>
            </div>


            <!-- OPCAO DO CARTAO DE CREDITO -->
            <div id="modalCartao" style="display: none;" class="modalSlideRight">
                <div class="modalTipoPagamento">
                    <!--<?php //var_dump($_SESSION["metodoPagamento"])?>-->
                    <button class="fechar" id="fecharModal2">✖</button><br>

                    <h2 style="color: rgb(0, 0, 150); margin-bottom: 50px; margin-left: 20px;">Pagamento com cartão de crédito</h2>

                    <form id="formCartao" action="inserirCartao.php" method="POST">
                        <div style="margin-left:20px;">
                            <div class="form-group">
                                <input type="text" id="nome_Cartao" name="nome_Cartao"  placeholder=" " required class="input-grande"/>
                                <label>Nome do titular do cartão</label>
                            </div>

                            <div class="form-group">
                                <input type="text" id="numero_cartao" name="numero_cartao"  placeholder=" " minlength="16" maxlength="16" required class="input-grande"/>
                                <label>Número do cartão</label>
                            </div>

                            <div style="display: flex;">
                                <div class="form-group">
                                    <input type="text" id="validade" name="validade"  placeholder=" " required class="input-pequeno"/>
                                    <label>Validade</label>
                                </div>

                                <div class="form-group" style="margin-left:-70px; margin-right:0px;">
                                    <input type="tel" id="cvv" name="ccv"  placeholder=" "minlength="3" maxlength="3" class="input-pequeno" required/>
                                    <label>CVV</label>
                                </div>

                                <img src="img/visamastercard.png" style="height:40px; width: 45px; margin-right:20px; margin-left:-70px;">
                            </div>

                            <div style="display: flex; margin-bottom: 30px;">
                                <input type="checkbox" style="margin-right: 10px; cursor:pointer;" id="guardarCartao">
                                <label>Guardar os dados do cartão.</label>
                            </div>

                            <button type="submit" id="openCode" class="btnContinuarPay botaoTransicao" onclick="verificarCheckbox(event)">Continuar</button>
                        </div>               
                    </form>
                </div>
            </div>


            <!-- OPCAO DO MBWAY -->
            <div id="modalMbway" class="modalSlideRight" style="display: none;">
                <div class="modalpay" >
                    <div class="modalTipoPagamento">
                        <?php //var_dump($_SESSION["metodoPagamento"])?>
                        <button class="fechar" id="fecharModal3">✖</button>

                        <h2 style="color: rgb(0, 0, 150); margin-bottom: 50px; margin-left: 20px;">Pagamento com MB MAY</h2>
        
                        <div style="margin-left:20px;">
                            <div class="form-group">
                                <input type="tel" id="telefone" name="telefone" maxlength="9" pattern="9[0-9]{8}" title="O número de telemóvel deve conter 9 números e deve iniciar com 9." placeholder="9XXXXXXXX" style="padding-left:20px;" required class="input-grande" value='<?= htmlspecialchars($registo["telefone"]) ?>'/>
                                <label>Número de telemóvel</label>
                            </div>

                            <label>Este é o teu número?</label>
                        </div>
                    </div>
                </div>
            </div>

            
            <!-- MODAL DE CODIGO DE CONFIRMACAO -->
            <div id='modalCodigo' class='modalSlideRight'>
                <div class='modalCodigo'>
                    <button class="fechar" id="fecharModal4">✖</button><br><br>

                    <h2 style="color: rgb(0, 0, 150); margin-bottom: 30px; margin-left: 20px; text-align: center;">Insira o código de 6 dígitos</h2>
                    
                    <?php if (isset($erro)) : ?>
                        <p style='color: red;'><?= htmlspecialchars($erro) ?></p>
                    <?php endif; ?>

                    <p style="margin-left:20px; text-align:center;">Insira o código de verificação que foi enviado para '<?= htmlspecialchars($registo["email"]) ?>'</p>

                    <div class='container'>
                        <form action='verificar_codigo.php' method='POST'>
                            <input type='tel' class='codigo' maxlength='6' id='codigo' name='codigo' required><br>
                            <div class='container' style='margin-bottom: 15px;'>
                                <button type='submit' class='botaoVerificar botaoTransicao'><strong>Verificar</strong></button>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>


        <script>
            // modal metodo
            const btnAbrir = document.getElementById('openModal'); 
            const modal = document.getElementById('modalMetodo');
            const btnFechar1 = document.getElementById('fecharModal');

            // modal cartao
            const modalCartao = document.getElementById('modalCartao');
            const btnCartao = document.getElementById('btnCartao');
            const btnFechar2 = document.getElementById('fecharModal2');
            const btnContinuar = document.getElementById('openCode');
            const formCartao = document.getElementById('formCartao');

            // modal mbway
            const modalMbway = document.getElementById('modalMbway');
            const btnMbway = document.getElementById('btnMbway');
            const btnFechar3 = document.getElementById('fecharModal3');

            // modal codigo
            const modalCode = document.getElementById('modalCodigo');
            const btnFechar4 = document.getElementById('fecharModal4');

            const fundoModal = document.querySelector('.modalFUNDO');

            // abrir modalmetodo
            btnAbrir?.addEventListener("click", function () {
                fundoModal.classList.add("show"); // mostra o fundo
                modal.style.display = 'block'; // mostra o primeiro modal (modalmetodo)
                modal.classList.add("show");
            });

            
            //funcao para guardar o metodo que foi selecionado na session 
            function guardarMetodo(metodo) {
                console.log("Método selecionado:", metodo); // Mostra antes de enviar

                fetch("guardarMetodo.php", {
                    method: "POST",
                    headers: {
                        "Content-Type": "application/x-www-form-urlencoded"
                    },
                    body: `metodoPagamento=${encodeURIComponent(metodo)}`
                }).then(res => res.json());
                //.then(data => console.log(data));
            }

            // quando escolhe cartão
            btnCartao?.addEventListener('click', () => {
                guardarMetodo("Cartao de Crédito");
                modal.style.display = 'none';
                modal.classList.remove("show");
                modalCartao.style.display = 'block';
                modalCartao.classList.add("show");
            });

            // quando escolhe MB Way
            btnMbway?.addEventListener('click', () => {
                guardarMetodo("MB WAY");
                modal.style.display = 'none';
                modalMbway.style.display = 'block';
                modalMbway.classList.add("show");
            });



            // aparicao do modalcodigo 
            btnContinuar?.addEventListener('click', () => {
                modal.style.display = 'none';
                modal.classList.remove("show");
                modalCartao.style.display = 'none';
                modalCartao.classList.remove("show");

                modalCode.style.display = 'block';
                modalCode.classList.add("show");
            });


            

            // função para remover o método de pagamento da sessão
            function removerMetodoSessao() {
                fetch('removerMetodo.php', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/x-www-form-urlencoded'
                    },
                    body: 'removerMetodo=true'
                })
                .then(response => response.text())
                .then(data => {
                    console.log("Método removido da sessão:", data);
                });
            }



            
            // fechar o modalmetodo
            btnFechar1.addEventListener('click', () => {
                //fecharModal(modal);
                modal.style.display = 'none';
                fundoModal.classList.remove("show");
            });

            // fechar o modal de cartão e voltar ao anterior
            btnFechar2.addEventListener('click', () => {
                removerMetodoSessao();
                fecharModal(modalCartao);
                modal.style.display = 'block'; // voltar para o modalmetodo
                /*modalCartao.classList.add("outshow");
                modal.classList.add("back");*/
            });

            // mesma coisa para o mbway
            btnFechar3.addEventListener('click', () => {
                removerMetodoSessao();
                fecharModal(modalMbway);
                modal.style.display = 'block';
                /*modalMbway.classList.add("outshow");
                modal.classList.add("show");*/
            });

            // mesma coisa para o codigo
            btnFechar4.addEventListener('click', () => {
                fecharModal(modalCode);
                modal.style.display = 'block';
                /*modalMbway.classList.add("outshow");
                modal.classList.add("show");*/
            });


            //funcao para fechar os modals
            function fecharModal(modalElement) {
                modalElement.style.display = 'none';
                modalElement.classList.remove('show');
            }


            //funcao para não permitir inserir letras no campo de telefone 
            document.addEventListener('DOMContentLoaded', () => {
                const telefoneInput = document.getElementById('telefone');
                const cvvInput = document.getElementById('cvv');
                const codigoInput = document.getElementById('codigo');

                // não permitir que sejam inseridas letras no número de telemóvel
                if (telefoneInput) {
                    telefoneInput.addEventListener('input', () => {
                        telefoneInput.value = telefoneInput.value.replace(/[^0-9]/g, ''); // permite apenas números no telefone
                    });
                } else {
                    console.error("Elemento com ID 'telefone' não encontrado.");
                }

                // não permitir que sejam inseridas letras no cvv
                if (cvvInput) {
                    cvvInput.addEventListener('input', () => {
                        cvvInput.value = cvvInput.value.replace(/[^0-9]/g, '');
                    });
                } else {
                    console.error("Elemento com ID 'cvv' não encontrado.");
                }

                // não permitir que sejam inseridas letras no codigo
                if (codigoInput) {
                    codigoInput.addEventListener('input', () => {
                        codigoInput.value = codigoInput.value.replace(/[^0-9]/g, '');
                    });
                } else {
                    console.error("Elemento com ID 'codigo' não encontrado.");
                }
            });




            // verificar se a checkbox de guardar os dados do cartao está selecionada
            function verificarCheckbox(event) {
                event.preventDefault(); 

                const checkbox = document.getElementById("guardarCartao");

                if (checkbox.checked) {
                    // redireciona para a página que insere o cartão e depois volta com query string
                    window.location.href = "inserirCartao.php?voltarPara=carrinho.php&abrirModal=modalCodigo";
                } else {
                    // só avança para o próximo modal (código)
                    fecharModal(modalCartao);
                    modalCode.style.display = 'block';
                    modalCode.classList.add("show");
                }
            }
        </script>
    </body>
    </html>