<?php
if (isset($_POST['removerMetodo']) && $_POST['removerMetodo'] === 'true') {
    session_start();
    unset($_SESSION['metodoPagamento']); // Remove o método de pagamento da sessão
    echo "Método removido com sucesso!";
    header("Location: carrinho.php"); // Redireciona de volta para a página do carrinho
    exit;
}
?>
