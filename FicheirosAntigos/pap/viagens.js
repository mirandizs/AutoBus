document.addEventListener("DOMContentLoaded", function () {
    const ida = document.getElementById("radioIda");
    const volta = document.getElementById("radioIdaVolta");
  
    ida.addEventListener("change", function () {
      if (ida.checked) {
        volta.checked = false;
      }
    });
  
    volta.addEventListener("change", function () {
      if (volta.checked) {
        ida.checked = false;
      }
    });
  });

  

// mostrar a janela de ida ou a de ida e volta
document.addEventListener("DOMContentLoaded", function () {
    const radioIda = document.getElementById("radioIda");
    const radioVolta = document.getElementById("radioIdaVolta");
    const janelaIda = document.getElementById("janelaIda");
    const janelaVolta = document.getElementById("janelaVolta");
  
    function atualizarJanela() {
        if (radioIda.checked) {
            janelaIda.style.display = "block";
            janelaVolta.style.display = "none";
        } else if (radioVolta.checked) {
            janelaIda.style.display = "none";
            janelaVolta.style.display = "block";
        }
    }


    // Eventos para verificar mudanças nos *radio buttons*
    radioIda.addEventListener("change", atualizarJanela);
    radioVolta.addEventListener("change", atualizarJanela);
  
    // Definir estado inicial
    atualizarJanela();
  });




// mostrar o texto de ida e volta da hora e da data
  document.addEventListener("DOMContentLoaded", function () {
    const radioIda = document.getElementById("radioIda");
    const radioVolta = document.getElementById("radioIdaVolta");
    const textoIda = document.getElementById("textoIda");
    const textoVolta = document.getElementById("textoVolta");
  
    function atualizarJanela() {
        if (radioIda.checked) {
            textoIda.style.display = "block";
            textoVolta.style.display = "none";
        } else if (radioVolta.checked) {
            textoIda.style.display = "none";
            textoVolta.style.display = "block";
        }
    }


    // Eventos para verificar mudanças nos *radio buttons*
    radioIda.addEventListener("change", atualizarJanela);
    radioVolta.addEventListener("change", atualizarJanela);
  
    // Definir estado inicial
    atualizarJanela();
  });









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
