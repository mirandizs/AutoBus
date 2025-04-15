document.addEventListener("DOMContentLoaded", function () {
    
    const camposTexto = document.querySelectorAll(".campoTexto");
    const botaoEnviar = document.getElementById("enviarMensagem");

    // Salva os valores iniciais de todos os campos e selects
    const valoresIniciais = Array.from(camposTexto).map(campo => campo.value);

    function verificarAlteracoes() {
        const algumAlterado = Array.from(camposTexto).some((campo, i) => campo.value !== valoresIniciais[i]);

        botaoEnviar.disabled = !algumAlterado; // Ativa ou desativa o botão
        botaoEnviar.style.cursor = "pointer";
      }
  
      // Adiciona eventos aos campos de texto
    camposTexto.forEach(campo => {
        campo.addEventListener("input", verificarAlteracoes);
      });
});



var modalVerificar = document.getElementById('modalVerificacao');

// When the user clicks anywhere outside of the modal, close it
window.onclick = function(event) {
    if (event.target == modalVerificar) {
        modalVerificar.style.display = "none";
    }
}


// popup do codigo de verificacao
function verificacao() {
  const btEnviar = document.getElementById('enviarMensagem');
  const popup = document.getElementById('modalVerificacao');
  const btX = document.getElementById('sair');

  /*//para enviar email
  if (btEnviar && popup) {
      btEnviar.addEventListener("click", function () {
          popup.style.display = "block";
      });
  }*/

  /*// para editar a password
  if (btPassword && popup) {
      btPassword.addEventListener("click", function () {
          popup.style.display = "block";
      });
  }*/

  // para sair do popup, botão "X"
  if (btX && popup) {
      btX.addEventListener("click", function () {
          
          popup.style.display = "none";
      });
  }
}

// Garante que o DOM esteja carregado antes de executar a função
document.addEventListener("DOMContentLoaded", function () {
  verificacao();
});



//animação para o botão de voltar atrás
window.addEventListener("scroll", function () {
    let botao = document.getElementById("botaoVoltar");
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
