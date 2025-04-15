    // função para o botão de visibilidade da password
    function myFunction(inputId = 'password') {
        var x = document.getElementById(inputId);
        var icon = (inputId === 'password') ? document.getElementById('iconPassword') : document.getElementById('iconPasswordConfirm');
        
        if (x.type === "password") {
            x.type = "text";
            icon.src = "img/aberto.png"; // Alterar para a imagem do olho aberto
        } else {
            x.type = "password";
            icon.src = "img/fechado.png"; // Alterar para a imagem do olho fechado
        }
    }

    
    // funcao para verificar se as palavras-passe são iguais
    function togglePasswordVisibility(inputId = 'pass') {
        var x = document.getElementById(inputId);
        var icon = (inputId === 'password') ? document.getElementById('iconPassword') : document.getElementById('iconPasswordConfirm');
        
        if (x.type === "password") {
            x.type = "text";
            icon.src = "img/aberto.png"; // Alterar para a imagem do olho aberto
        } else {
            x.type = "password";
            icon.src = "img/fechado.png"; // Alterar para a imagem do olho fechado
        }
    }
    

    // funcao de validação da password 
    function validarPasswords() {
        var pop = document.getElementById("popup");
        var pass1 = document.getElementById("password").value;
        var pass2 = document.getElementById("pass").value;
        
    
        if (pass1 !== pass2) {
            pop.style.visibility = "visible"; // // mostrar a mensagem se as palavras-passe não coincidirem 
            return false;  // impede o envio do formulário
        }
        return true;  // permite o envio do formulário
    }


    // funcao dos numeros
    document.addEventListener('DOMContentLoaded', () => {
        const telefoneInput = document.getElementById('telefone');
        const nifInput = document.getElementById('nif'); 
        const nomeInput = document.getElementById('nome'); 
        const localidadeInput = document.getElementById('localidade'); 

        // não permitir que sejam inseridas letras no nif e no número de telemóvel
        if (telefoneInput) {
            telefoneInput.addEventListener('input', () => {
                telefoneInput.value = telefoneInput.value.replace(/[^0-9]/g, ''); // permite apenas números no telefone
            });
        } else {
            console.error("Elemento com ID 'telefone' não encontrado.");
        }

        if (nifInput) {
            nifInput.addEventListener('input', () => {
                nifInput.value = nifInput.value.replace(/[^0-9]/g, ''); // permite apenas números no NIF
            });
        } else {
            console.error("Elemento com ID 'nif' não encontrado.");
        }

        // não permitir que sejam inseridos números no nome e nem na localidade
        if (nomeInput) {
            nomeInput.addEventListener('input', () => {
                nomeInput.value = nomeInput.value.replace(/[^a-zA-ZÀ-ÿ\s]/g, ''); // permite apenas letras (com acentos) e espaços no nome
            });
        } else {
            console.error("Elemento com ID 'nome' não encontrado.");
        }

        if (localidadeInput) {
            localidadeInput.addEventListener('input', () => {
                localidadeInput.value = localidadeInput.value.replace(/[^a-zA-ZÀ-ÿ\s]/g, ''); // permite apenas letras (com acentos) e espaços na localidade
            });
        } else {
            console.error("Elemento com ID 'localidade' não encontrado.");
        }
    });



    //validação da idade
    document.getElementById('nascimento').addEventListener('change', function () {
        const errorMessage = document.getElementById('error');
        const inputDate = new Date(this.value); //obtem a data de nascimento
        const today = new Date(); //data atual
        const age = today.getFullYear() - inputDate.getFullYear(); //calcula a idade
        const monthDifference = today.getMonth() - inputDate.getMonth();

        //ajusta a idade com base no mês e no dia
        if (monthDifference < 0 || (monthDifference === 0 && today.getDate() < inputDate.getDate())) {
            age--;
        }

        const idadeTexto = document.getElementById('textoIdade');

        //verifica se a idade é menor que 18 anos
        if (age < 18) {
            //idadeTexto.textContent = 'É necessário ter pelo menos 18 anos para criar uma conta.';
            idadeTexto.style.color = 'red';
            document.getElementById('botao').disabled = true; //desabilita o botão de envio
        } else {
            idadeTexto.textContent = ''; //limpa a mensagem de erro
            document.getElementById('botao').disabled = false; //habilita o botão de envio
        }
    });



    //
    myInput.onfocus = function() {
        document.getElementById("messageBox").style.display = "block";
        document.getElementById("messageBox").scrollIntoView({ behavior: "smooth" });
    }


    //pop up da comparação das passwords
    /*window.onclick = function(event) {
        var pop = document.getElementById("popup");
        if (event.target == pop) {
        pop.style.visibility = "hidden"; // fechar o modal
        }
    }*/



    //nao me lembro
    /*document.addEventListener("DOMContentLoaded", function () {
        
        const camposTexto = document.querySelectorAll(".campoTexto");
        const validacao = document.getElementById("messageBox");

        //Salva os valores iniciais de todos os campos e selects
        const valoresIniciais = Array.from(camposTexto).map(campo => campo.value);

        function verificarAlteracoes() {
            const algumAlterado = Array.from(camposTexto).some((campo, i) => campo.value !== valoresIniciais[i]);

            validacao.disabled = !algumAlterado; // Ativa ou desativa o botão

            scrollToRequirements();

            validarPasswords();
        }
    
        // Adiciona eventos aos campos de texto
        camposTexto.forEach(campo => {
            campo.addEventListener("input", verificarAlteracoes);
        });
    });*/