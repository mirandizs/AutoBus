<?php
    session_start();

    /*if (isset($_SERVER['HTTP_REFERER'])) {
        $referrer = $_SERVER['HTTP_REFERER'];
        echo "This page was redirected from: " . htmlspecialchars($referrer);
    } else {
        echo "No referrer information is available.";
    }*/
    //var_dump($_SESSION["nome"]); exit();

    if (!isset(($_SESSION["email"]))) {
        header("Location: inicial.php");
    }

    if (!isset($_SESSION["nif"]) && !isset($_SESSION["tipo_utilizador"])) {
        header("Location: inicial.php");
    }

    require "ligadb.php";

    $consulta = "SELECT * FROM utilizadores WHERE nif = '" . $_SESSION["nif"] . "'";

    $resultado = mysqli_query($con, $consulta);
    
    if(!$resultado){
        echo "Erro: não foi possível aceder à Base de Dados!";
        exit;
    }

    $registo = mysqli_fetch_array($resultado);
?>

<!DOCTYPE html>
<html lang="pt">
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <link rel="stylesheet" type="text/css" href="definicoes.less">
        <link rel="icon" type="image/x-icon" href=""> <!--fav icon-->
        <script src="definicoes.js"></script>
        <title>AutoBus</title>
    </head>

    <body>
        <!--<header>AutoBus</header>-->


        <?php
        
            $VisiblidadeConta = "ativa";
            $VisiblidadePriv = "";
            if (isset($_SESSION["em_verificacao"])){
                $VisiblidadePriv = "ativa";
                $VisiblidadeConta = "";
            }
            else {
                $VisiblidadeConta = "ativa";
                $VisiblidadePriv = "";
            }
        ?>
            
            <?php if ($_SESSION["tipo_utilizador"] == 0): ?> <!--admin-->
                <div id="0">
                    <div class="roww">
                        <div class="box1">
                            <button type="button" id="gestor" class="botao" onclick="mostrarGestao('gestaoUtilizadores')">Gerir Utilizadores</button>
                            <button type="button" id="edicao" class="botao" onclick="mostrarGestao('gestaoEditar')">Editar Utilizadores</button>
                            <a href="inicial.php"><button type="button" value="Voltar" class="botao">Voltar</button></a>
                        </div>

                        <div id="gestaoUtilizadores" class="gerir ativa">
                            <div class="box2 row">
                                <div class="column left">
                                    <h2>Gestão de Utilizadores</h2><br>
                                    
                                    <table>
                                        <tr>
                                            <th>NIF</th>
                                            <th>Nome</th>
                                            <th>Data de Nascimento</th>
                                            <th>Telemóvel</th>
                                            <th>Localidade</th>
                                            <th>Email</th>
                                            <th>Palavra-passe</th>
                                            <th>Tipo de utilizador</th>
                                            <th>Editar</th>
                                        </tr>

                                        <?php
                                        $sql = 'SELECT nif, nome, nascimento, telefone, localidade, email, password, tipo_utilizador, atividade FROM utilizadores';
                                        $consulta = mysqli_query($con, $sql);

                                        if (mysqli_num_rows($consulta) > 0):
                                            while ($linha = mysqli_fetch_assoc($consulta)): ?>
                                                <tr class="dadosTabela">
                                                    <td><?= htmlspecialchars($linha["nif"]) ?></td>
                                                    <td><?= htmlspecialchars($linha["nome"]) ?></td>
                                                    <td><?= htmlspecialchars($linha["nascimento"]) ?></td>
                                                    <td><?= htmlspecialchars($linha["telefone"]) ?></td>
                                                    <td><?= htmlspecialchars($linha["localidade"]) ?></td>
                                                    <td><?= htmlspecialchars($linha["email"]) ?></td>
                                                    <td>...</td>
                                                    <td><?= htmlspecialchars($linha["tipo_utilizador"]) ?></td>
                                                    <td>
                                                        <button type="button" class="editar imagemEditar" id="editarUtilizador" onclick="mostrarGestao('gestaoEditar')">
                                                            <img src="img/lapis.png" id="edit" width="20px" height="20px">
                                                        </button>
                                                    </td>
                                                </tr>
                                            <?php endwhile;
                                        else: ?>
                                            <tr><td colspan="8">Nenhum utilizador encontrado.</td></tr>
                                        <?php endif; ?>
                                    </table>
                                </div>
                            </div>
                        </div>

                        <!-- Janela de editar utilizadores -->
                        <div id="gestaoEditar" class="gerir">
                            <form action="editarAdmin.php" method="POST">
                                <div class="box2 row">
                                    <div class="column left">
                                        <h2>Gestão de Utilizadores - Editar</h2><br>

                                        <label>Nome:</label><br>
                                        <input type="text" class="info campoTexto caixa" id="nome" name="nome" value="<?= htmlspecialchars($registo["nome"]) ?>"><br><br>

                                        <label>NIF:</label><br>
                                        <input type="tel" class="info campoTexto caixa" id="nif" name="nif" maxlength="9" value="<?= htmlspecialchars($registo["nif"]) ?>" disabled><br><br>

                                        <label>Data de nascimento:</label><br>
                                        <input type="date" class="info campoTexto caixa" id="nascimento" name="nascimento" value="<?= htmlspecialchars($registo["nascimento"]) ?>"><br><br>

                                        <label>Password:</label><br>
                                        <input type="password" class="info campoTexto caixa" id="password" name="password" value="<?= htmlspecialchars($registo["password"]) ?>" style="margin-bottom:10px;"><br><br>

                                        <button type="submit" id="botaoEditar" name="botaoEditar" disabled>Salvo</button>
                                    </div>

                                    <div class="column right">
                                        <div style="padding-top: 60px;">
                                            <label>Telemóvel:</label><br>
                                            <input type="tel" class="info campoTexto caixa" id="telefone" name="telefone" maxlength="9" value="<?= htmlspecialchars($registo["telefone"]) ?>"><br><br>

                                            <label>Localidade:</label><br>
                                            <input type="text" class="info campoTexto caixa" id="localidade" name="localidade" value="<?= htmlspecialchars($registo["localidade"]) ?>"><br><br>

                                            <label>Email:</label><br>
                                            <input type="email" class="info campoTexto caixa" id="email" name="email" value="<?= htmlspecialchars($registo["email"]) ?>"><br><br>

                                            <div class="row">
                                                <div class="column left">
                                                    <label>Tipo de utilizador:</label><br>
                                                    <select class="campoSelect" id="tipo_utilizador" name="tipo_utilizador">
                                                        <option value="0" <?= ($registo["tipo_utilizador"] == '0') ? "selected" : "" ?>>Administrador</option>
                                                        <option value="1" <?= ($registo["tipo_utilizador"] == '1') ? "selected" : "" ?>>Cliente</option>
                                                    </select>
                                                </div>

                                                <div class="column right" style="padding-top:10px;">
                                                    <label>Atividade:</label><br>
                                                    <select class="campoSelect" id="atividade" name="atividade">
                                                        <option value="0" <?= ($registo["atividade"] == '0') ? "selected" : "" ?>>Inativo</option>
                                                        <option value="1" <?= ($registo["atividade"] == '1') ? "selected" : "" ?>>Ativo</option>
                                                    </select>
                                                </div>
                                            </div>
                                            <br>
                                        </div>
                                    </div>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>

            <?php elseif ($_SESSION["tipo_utilizador"] == 1): ?> <!--cliente-->
                <div id='1'>
                    <div class='roww'>
                        <div class='box1'>
                            <button type='button' id='minhaConta' class='botao' onclick='mostrarSecao("minhaconta");'>Minha conta</button>
                            <button type='button' id='privacidadeSeguranca' class='botao' onclick='mostrarSecao("privacidade");'>Privacidade e Segurança</button>
                            <a href='inicial.php'><button type='button' value='Voltar' class='botao'>Voltar</button></a>
                        </div>

                        <div id='minhaconta' class='janela <?= $VisiblidadeConta ?>'>
                            <form action='editarCliente.php' method='POST' enctype="multipart/form-data">
                                <div class='box2 row'>
                                    <div class='column left'>
                                        <h2 style="margin-bottom: 25px;">Minha conta</h2>

                                        <label>Nome: </label><br>
                                        <input type='text' class='info campoTexto caixa' name='nome' value='<?= htmlspecialchars($registo["nome"]) ?>'><br><br>
                                        
                                        <label>NIF: </label><br>
                                        <input type='tel' class='info campoTexto caixa' name='nif' maxlength='9' value='<?= htmlspecialchars($registo["nif"]) ?>' disabled style="cursor:not-allowed;"><br><br>
                                        
                                        <label>Data de nascimento: </label><br>
                                        <input type='date' class='info campoTexto caixa' name='nascimento' value='<?= htmlspecialchars($registo["nascimento"]) ?>'><br><br>
                                        
                                        <label>Telemóvel: </label><br>
                                        <input type='tel' class='info campoTexto caixa' name='telefone' pattern='9[0-9]{8}' title='O número de telemóvel deve conter 9 números e deve iniciar com 9.' maxlength='9' value='<?= htmlspecialchars($registo["telefone"]) ?>'><br><br>
                                        
                                        <label>Localidade: </label><br>
                                        <input type='text' class='info campoTexto caixa' name='localidade' value='<?= htmlspecialchars($registo["localidade"]) ?>'><br>

                                        <button type='submit' id='botaoEditar' name='botaoEditar' disabled style='margin-top:30px;'>Salvo</button>
                                    </div>

                                    <div class='column right'>
                                        
                                        <h3 class="foto-perfil">Foto de perfil</h3>

                                        <div class="bordas">
                                            <div class="alignment">
                                                <a class='fundo'>
                                                    <img class='imagemUti' id='preview' src="<?= 'uploads/' . $registo['foto'] ?>" onerror='this.src="img/default.png"'>
                                                </a>

                                                <script>
                                                    function previewImage(event) {
                                                        var reader = new FileReader();
                                                        reader.onload = function() {
                                                            var output = document.getElementById('preview');
                                                            output.src = reader.result;
                                                        };
                                                        reader.readAsDataURL(event.target.files[0]);
                                                    }
                                                </script>

                                                <br>
                                                <label for="file" class="file-label" >Selecione uma imagem</label>
                                                <input type="file" accept="image/*" id="file" class="file-input" name="foto" onchange="previewImage(event)">
                                                <br>
                                            </div>                                            
                                        </div>
                                    </div>
                                </div>
                            </form>
                        </div>

                        <div id='privacidade' class='janela <?= $VisiblidadePriv ?>'>
                            <div id='modalVerificacao' class='modal'>
                                <div class='modal-content animate'>

                                    <!--BOTAO SAIR X-->
                                    <div class='imgcontainer' id='sair'>
                                        <span onclick='verificacao()' class='close' title='Fechar'>&times;</span>
                                    </div><br>

                                    <h2>Insira o código de 6 dígitos</h2><br>
                                    
                                    <?php if (isset($erro)) : ?>
                                        <p style='color: red;'><?= htmlspecialchars($erro) ?></p>
                                    <?php endif; ?>

                                    <p>Insira o código de verificação que foi enviado para '<?= htmlspecialchars($registo["email"]) ?>'</p><br>

                                    <div class='container'>
                                        <form action='verificar_codigo.php' method='POST'>
                                            <input type='tel' class='codigoVerificacao codigo' maxlength='6' id='codigo' name='codigo' required><br><br>
                                            <div class='container' style='margin-bottom: 15px;'>
                                                <button type='submit' class='botaoVerificar'><strong>Verificar</strong></button>
                                            </div>
                                        </form>
                                    </div><br>
                                </div>
                            </div>

                            <form action='codigo.php' method='POST'>
                                <div class='box2 row'>
                                    <div class='column left'>
                                        <h2>Privacidade e Segurança</h2><br>

                                        <label>Aqui poderás alterar o teu email e password com segurança! Atenção, será enviado um email de confirmação.</label><br><br><br>

                                        <label>Email:</label><br>
                                        <input type='email' class='info caixa campoTexto' name='email' id='email' value='<?= htmlspecialchars($registo["email"]) ?>'>
                                        <button type='button' class='editar imagemEditar' id='editarEmail' disabled style="cursor:not-allowed">
                                            <img src='img/lapis.png' width='20px' height='20px'>
                                        </button><br><br>

                                        <label>Password:</label><br>
                                        <input type='password' class='info caixa campoTexto' name='password' id='password' value='<?= htmlspecialchars($registo["password"]) ?>'>
                                        <button type='button' class='ver' name="iconPasswordConfirm" id="iconPasswordConfirm" onclick='myFunction("password")'>
                                            <img src='img/fechado.png' width='20px' height='20px'>
                                        </button>
                                        <button type='submit' class='editar imagemEditar' id='editarPassword' disabled style="cursor:not-allowed">
                                            <img src='img/lapis.png' width='20px' height='20px'>
                                        </button><br><br><br>

                                        <label>Tenha certeza de que o email que está a utilizar está ativo ou que tenha espaço o suficiente para receber emails de confirmação do nosso site.</label>
                                    

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
                                    
                                    </div>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>

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
                    const botaoCarregarEmail = document.getElementById('editarEmail');
                    const botaoCarregarPassword = document.getElementById('editarPassword');
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
            <?php endif; ?>
        <br>
        
        <?php include "footer.php"?>
    </body>
</html>