// mostrar a janela de cliente, ou seja, definições da conta.
function mostrarSecao(idSecao) {
        document.querySelectorAll('.janela').forEach((secao) => {
            secao.classList.remove('ativa');
            console.log(`Secção escondida: ${secao.id}`);
        });
    
        const secao = document.getElementById(idSecao);
        if (secao) {
            secao.classList.add('ativa');
            console.log(`Secção mostrada: ${idSecao}`);
        } else {
            console.error(`Secção com ID "${idSecao}" não encontrada.`);
        }
};


// função para mudar a cor do botão conforme estiver selecionado
document.addEventListener("DOMContentLoaded", function() { 
    let minhaConta = document.getElementById("minhaConta");
    let privacidade = document.getElementById("privacidadeSeguranca");

    // Define o estado inicial
    minhaConta.style.backgroundColor = "rgb(240, 240, 240)";

    // Evento para mudar a cor quando "Privacidade e Segurança" for clicado
    privacidade.addEventListener("click", function() {
        minhaConta.style.backgroundColor = "white";
        privacidade.style.backgroundColor = "rgb(240, 240, 240)";
    });

    // Evento para voltar ao estado inicial
    minhaConta.addEventListener("click", function() {
        minhaConta.style.backgroundColor = "rgb(240, 240, 240)";
        privacidade.style.backgroundColor = "white";
    });
});


function mostrarGestao(idSecao) {
    document.querySelectorAll('.gerir').forEach((secao) => {
        secao.classList.remove('ativa');
        console.log(`Secção escondida: ${secao.id}`);
    });

    const secao = document.getElementById(idSecao);
    if (secao) {
        secao.classList.add('ativa');
        console.log(`Secção mostrada: ${idSecao}`);
    } else {
        console.error(`Secção com ID "${idSecao}" não encontrada.`);
    }
};


// função para o botão de visibilidade da password
function myFunction(inputId = 'password') {
    var x = document.getElementById(inputId);  // seleciona o campo de input (password)
    var icon = document.getElementById('iconPasswordConfirm');  // seleciona o ícone de password

    if (x.type === "password") {
        x.type = "text";  // muda para texto para mostrar a password
        icon.src = "img/aberto.png";  // altera o ícone para o olho aberto
    } else {
        x.type = "password";  // volta a esconder a password
        icon.src = "img/fechado.png";  // altera o ícone para o olho fechado
    }
}






// animação do popup de login


//animação do pop up do código de verificação
// Get the modal
var modalVerificar = document.getElementById('modalVerificacao');

// when the user clicks anywhere outside of the modal, close it
window.onclick = function(event) {
    if (event.target == modalVerificar) {
        modalVerificar.style.display = "none";
    }
}





// popup do codigo de verificacao
function verificacao() {
    const popup = document.getElementById('modalVerificacao');
    const loadingScreen = document.getElementById('carregar'); // Div do carregamento
    const btX = document.getElementById('sair');

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





















// funcao para mudar o cursor e interação com o botao "Editar"
document.addEventListener("DOMContentLoaded", function () {
    const camposTexto = document.querySelectorAll(".campoTexto");
    const selects = document.querySelectorAll(".campoSelect");
    const botao = document.getElementById("botaoEditar");
    const inputFile = document.getElementById("file"); 

    // salva os valores iniciais de todos os campos e selects
    const valoresIniciais = Array.from(camposTexto).map(campo => campo.value);
    const valoresIniciaisSelects = Array.from(selects).map(select => select.value);

    // função para verificar alterações em campos ou selects
    function verificarAlteracoes() {
        const algumAlterado = Array.from(camposTexto).some((campo, i) => campo.value !== valoresIniciais[i]) ||
            Array.from(selects).some((select, i) => select.value !== valoresIniciaisSelects[i]);
        botao.disabled = !algumAlterado; // Ativa ou desativa o botão
        botao.textContent = algumAlterado ? "Salvar" : "Salvo";
    }

    // adiciona eventos aos campos de texto
    camposTexto.forEach(campo => {
        campo.addEventListener("input", verificarAlteracoes);
    });

    // adiciona eventos aos selects
    selects.forEach(select => {
        select.addEventListener("change", verificarAlteracoes);
    });

    // adiciona evento ao input de arquivo
    inputFile.addEventListener("change", function() {
        botao.disabled = false; // Ativa o botão
        botao.textContent = "Salvar"; // Muda o texto do botão
    });
  });
  







document.addEventListener("DOMContentLoaded", function () {
    
    const camposTexto = document.querySelectorAll(".campoTexto");
    const botaoP = document.getElementById("editarPassword");
    const botaoE = document.getElementById("editarEmail");

    // Salva os valores iniciais de todos os campos e selects
    const valoresIniciais = Array.from(camposTexto).map(campo => campo.value);

    function verificarAlteracoes() {
        const algumAlterado = Array.from(camposTexto).some((campo, i) => campo.value !== valoresIniciais[i]);

        botaoP.disabled = !algumAlterado; // Ativa ou desativa o botão
        botaoP.style.cursor = "pointer";

        botaoE.disabled = !algumAlterado; // Ativa ou desativa o botão
        botaoE.style.cursor = "pointer";
      }
  
      // Adiciona eventos aos campos de texto
    camposTexto.forEach(campo => {
        campo.addEventListener("input", verificarAlteracoes);
      });
});








//funcao para o input do codigo
    document.addEventListener('DOMContentLoaded', () => {
    const codigoInput = document.getElementById('codigo'); 

    // não permitir que sejam inseridas letras no input do codigo de verificacao
    if (codigoInput) {
        codigoInput.addEventListener('input', () => {
            codigoInput.value = codigoInput.value.replace(/[^0-9]/g, ''); // permite apenas números no codigo
        });
    } else {
        console.error("Elemento com ID 'telefone' não encontrado.");
    }
});



















//FUNCAO PARA OCULTAR O EMAIL NA PARTE DE ENVIAR O CÓDIGO
function ocultarEmail(email) {
    let partes = email.split("@");  
    if (partes.length !== 2) return email; // Se não for um email válido, retorna como está.

    let usuario = partes[0]; // Antes do @
    let dominio = partes[1]; // Depois do @

    // Esconde o domínio
    let usuarioOculto = usuario.substring(0, 5) + "********"; // Mantém os 5 primeiros caracteres e oculta o resto

    return `${usuarioOculto}@${dominio}`;
}

// Exemplo de uso
let email = "exemplo@gmail.com";
console.log(ocultarEmail(email)); // Saída: exemp********@gmail.com