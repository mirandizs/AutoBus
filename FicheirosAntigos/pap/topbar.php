<!-- 
    if (isset($_SESSION["id_utilizador"])) {
        $id = $_SESSION["id_utilizador"];

        // Obtém a foto do utilizador
        $sql = "SELECT foto FROM utilizadores WHERE id_utilizador = ?";
        $stmt = $conn->prepare($sql);
        $stmt->bind_param("i", $id);
        $stmt->execute();
        $stmt->bind_result($foto);
        $stmt->fetch();
        $stmt->close();

        // Se não houver foto, usa uma imagem padrão
        $foto = $foto ? $foto : "img/default-profile.png";
    } 
    
    else {
        $foto = "img/default-profile.png"; // Caso o utilizador não esteja autenticado
    }
?>-->


<?php //if(isset($_SESSION['email'])){ echo "sessao iniciada";}?>

<link rel="stylesheet" type="text/css" href="topbar.css">

<style>
    .dropdown {
      position: relative;
      display: inline-block;
    }

    .dropdown-content {
      display: none;
      position: absolute;
      right: 0;
      background-color: rgb(3, 3, 59);
      min-width: 100px;
      box-shadow: 0px 8px 16px 0px rgba(0, 0, 0, 0.2);
      z-index: 1000;
      border-radius: 15px;
    }

    .dropdown-content a {
      color: white;
      width: 80px;
      padding-bottom: 12px;
      padding-top: 12px;
      padding-left: 23px;
      padding-right: 22px;
      text-decoration: none;
      display: block;
    }

    .dropbtn {
      padding: 10px 20px;
      background-color: rgb(3, 3, 59);
      color: white;
      border: none;
      cursor: pointer;
    }

   

    .botao-imagem {
        display: inline-flex; /* Permite alinhar imagem e texto lado a lado */
        align-items: center; /* Alinha verticalmente */
        background-color: transparent; /* Cor de fundo */
        /*border: 1px solid #ccc; Borda do botão */
        padding-right: 5px; /* Espaçamento interno */
        padding-left: 10px;
        padding-top: 0px;
        padding-bottom: 5px;
        font-size: 16px; /* Tamanho do texto */
        cursor: pointer; /* Cursor de mão ao passar o rato */
        color: white; /* Cor do texto */
    }

    .imagem-butao-perfil{
        margin-right: 5px;
        width: 35px; /* Largura da imagem */
        height: 35px; /* Altura da imagem */
        padding-top: 0px;
        /*object-fit: cover;*/
    }

    .botao-imagem-carrinho::before{
        content: ''; /* Adiciona a imagem */
        display: inline-block; /* Garante que a imagem fique visível */
        background: url('img/carrinhoB.png') no-repeat center; /* Insere a imagem */
        background-size: contain; /* Ajusta o tamanho da imagem */
        width: 28px; /* Largura da imagem */
        height: 30px; /* Altura da imagem */
        margin-right: 5px; /* Espaçamento entre a imagem e o texto */
    }

    .botao-imagem-compras::before{
        content: ''; /* Adiciona a imagem */
        display: inline-block; /* Garante que a imagem fique visível */
        background: url('img/comprasB.png') no-repeat center; /* Insere a imagem */
        background-size: contain; /* Ajusta o tamanho da imagem */
        width: 28px; /* Largura da imagem */
        height: 30px; /* Altura da imagem */
        margin-right: 5px; /* Espaçamento entre a imagem e o texto */
    }
</style>


<div class="topo">
    <div>
        <div class="login">
            
            <a><button id="butao-compras" class="botaoLogin-a botao-imagem-compras"></button></a>
            <a href="carrinho.php"><button id="butao-carrinho" class="botaoLogin-a botao-imagem-carrinho"></button></a>

            <div id="dropdown-container" class="dropdown">  
                <button class="botaoLogin botao-imagem dropbtn" id="butao-perfil" alt="Utilizador">
                    <img class="imagem-butao-perfil" src="<?= isset($_SESSION['foto']) && $_SESSION['foto'] ? 'uploads/' . $_SESSION['foto'] : 'img/default-profile.png' ?>">
                    <span id="nome-utilizador" style="color: white; font-size: 14px; margin-left:10px;"></span>
                </button>
                
                <br><br>
                <div id="dropdown" class="dropdown-content">
                    <a href="definicoes.php" style="padding-top: 30px;" onclick="identificarUtilizador();">Definições</a>
                    <!--<a href="contacto.php">Contacto</a>-->
                    <a onclick="Redirecionar('logout.php')" style="padding-bottom: 17px; cursor: pointer;" id="botaoLogout" name="botaoLogout">Sair</a>
                </div>
            </div>

            <div class="modal" id="ModalLogin">

                <form class="modal-content animate" action="login.php" method="POST">
                    <div class="container">
                        <!--<a class="imagemLogin"><img src="img/logoTeste.png">Login</a><br><br>-->
                        <label class="entrar"><strong>Entrar</strong></label>

                        <br><br>
                        <label style="margin-left:3%"><b>Email</b></label>
                        <input class="inserir" type="email" placeholder="Insira o email" name="email" id="email" required style="margin-left:3%"><br>

                        <label style="margin-left:3%"><b>Palavra-Passe</b></label>
                        <input class="inserir" type="password" placeholder="Insira a palavra-passe" name="password" id="password" required style="margin-left:3%">

                        <div id="erro" style="color:red"></div>

                        <?php
                            if (isset($_SESSION["erro"]))
                            {
                                echo "<script>
                                        document.getElementById('erro').innerHTML = '" . $_SESSION["erro"] . "'
                                    </script>";
                                unset($_SESSION["erro"]);
                            }
                        ?>

                        <div style="display: flex; justify-content: space-between; width: 90%;">
                            <button type="submit" class="botao2" name="botaoLogin" id="botaoLogin">Entrar</button>

                            <button type="button" onclick="document.getElementById('ModalLogin').style.display='none'"
                                class="cancelbtn">Cancelar</button>
                        </div><br>
                        
                        
                        <p class="conta">Não tenho conta. <a href="criarConta.php" class="letra"><u>Criar uma.</u></a></p><br>
                    </div>
                </form>
            </div>
        </div>

        <!--<div class="marca"><!--<strong>AutoBus</strong>
            <img src="img/circulo.png" class="imagemLogo" style="padding-top: 0px; padding-bottom: 0px; padding-right: 0px">            
        </div>-->
        <a class="marca" style="padding-left:30px; padding-right: 50px; text-decoration: none; color: white;" href="inicial.php">AutoBus</a>
        
        <a class="marca" style="text-decoration: none; color: white; padding-right: 40px;" href="localidades.php">Mapa e Localidades</a>

        <a class="marca" style="text-decoration: none; color: white; padding-right: 20px;" href="viagens.php">Viagens</a>
        <!-- <a class="marca" style="padding-left:900px; text-decoration: none; color: white;" href="contacto.php">Contacte-nos!</a>-->
        <br>
    </div>
</div>

<script>

    var Utilizador = "<?php 
                            if(isset($_SESSION['email'])){
                                echo $_SESSION['nome']; 
                            } else {
                                echo ''; 
                            }
                        ?>";

    const FormLogin = document.getElementById('ModalLogin');
    const ButaoPerfil = document.getElementById('butao-perfil');
    const ButaoCompras = document.getElementById('butao-compras');
    const ButaoCarrinho = document.getElementById('butao-carrinho');
    const NomeUtilizador = document.getElementById('nome-utilizador');
    const Dropdown = document.getElementById("dropdown")
    const DropdownElements = document.getElementById("dropdown-container")

    if (Utilizador === "") {
        // Se NÃO houver login
        ButaoCompras.style.display = 'none';
        ButaoCarrinho.style.display = 'none';

        ButaoPerfil.addEventListener("click", function () {
            FormLogin.style.display = 'block';
        });
    } else {
        // Se houver login
        NomeUtilizador.textContent = Utilizador; // Adiciona o nome ao lado do botão

        DropdownElements.addEventListener("mouseover", function(){
            Dropdown.style.display = "block"
        })
        DropdownElements.addEventListener("mouseout", function(){
            Dropdown.style.display = "none"
        })

    }
    

    function Redirecionar(Pagina) {
        window.location.href = Pagina;
    }
</script>