<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>
<body>
    <form action="definicoes.php" method="post" enctype="multipart/form-data">
        <input type="file" name="image" accept="image/*">
        <button type="submit">Upload</button>
    </form>

    <?php
        if ($_SERVER["REQUEST_METHOD"] == "POST" && isset($_FILES["image"])) {
            $pasta = "uploads/"; // pasta para salvar as imagens
            $nomeFicheiro = $pasta . basename($_FILES["image"]["name"]);
            $tipoImagem = strtolower(pathinfo($nomeFicheiro, PATHINFO_EXTENSION));

            // Check if file is an actual image
            $check = getimagesize($_FILES["image"]["tmp_name"]);
            if ($check === false) {
                die("File is not an image.");
            }

            // aceitar tipos expecíficos de imagem
            $permissao = ["jpg", "jpeg", "png", "bmp"];
            if (!in_array($tipoImagem, $permissao)) {
                die("Only JPG, JPEG, PNG, and BMP files are allowed.");
            }

            // Move the uploaded file
            if (move_uploaded_file($_FILES["image"]["tmp_name"], $nomeFicheiro)) {
                echo "File uploaded successfully: <br>";
                echo "<img src='$nomeFicheiro' width='200'>";
            } else {
                echo "Error uploading file.";
            }
        }
    ?>

</body>
</html>