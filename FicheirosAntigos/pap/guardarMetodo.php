<?php
session_start();

if ($_SERVER["REQUEST_METHOD"] === "POST") {
    $metodo = $_POST["metodoPagamento"] ?? null;

    if ($metodo) {
        $_SESSION["metodoPagamento"] = $metodo;
        echo json_encode(["status" => "ok"]);
    } else {
        echo json_encode(["status" => "erro", "mensagem" => "Método não enviado"]);
    }
}
?>
