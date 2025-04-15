var myInput = document.getElementById("password");
var capital = document.getElementById("capital");
var letter = document.getElementById("letter");
var number = document.getElementById("number");
var length = document.getElementById("length");



//funcao do scroll
function scrollToRequirements() {
  $('html, body').animate({
      scrollTop: $("#anchor").offset().scrollTop
  }, 2000); // Usando a animação existente
  }

  $("#button").click(function() {
  $('html, body').animate({
      scrollTop: $("#anchor").offset().scrollTop
  }, 2000);
});




// When the user clicks on the password field, show the message box
myInput.onfocus = function() {
  document.getElementById("messageBox").style.display = "block";
}

// When the user clicks outside of the password field, hide the message box
myInput.onblur = function() {
  document.getElementById("messageBox").style.display = "none";
}





// quando o utilizador começar a escrever qualquer coisa no input da password
myInput.addEventListener('keyup', function(){
  
  // Validar letras minúsculas
  var lowerCaseLetters = /[a-z]/g;
  if(myInput.value.match(lowerCaseLetters)) {  
    letter.classList.remove("invalid");
    letter.classList.add("valid");
  } else {
    letter.classList.remove("valid");
    letter.classList.add("invalid");
  }

  // Validar letra maiúscula
  var upperCaseLetters = /[A-Z]/g;
  if (myInput.value.match(upperCaseLetters)) {
    capital.classList.remove("invalid");
    capital.classList.add("valid");
  } else {
    capital.classList.remove("valid");
    capital.classList.add("invalid");
  }

  // Validar números
  var numbers = /[0-9]/g;
  if (myInput.value.match(numbers)) {  
    number.classList.remove("invalid");
    number.classList.add("valid");
  } else {
    number.classList.remove("valid");
    number.classList.add("invalid");
  }

  // Validar comprimento da palavra-passe
  if (myInput.value.length >= 8) {
    length.classList.remove("invalid");
    length.classList.add("valid");
  } else {
    length.classList.remove("valid");
    length.classList.add("invalid");
  }
});