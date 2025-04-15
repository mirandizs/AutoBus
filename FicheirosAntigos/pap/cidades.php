<?php
    // Array de cidades com coordenadas
    $cidades = [
        1 => ['lat' => 41.68374910961116, 'lng' => -8.842858508219035, 'nome' => 'Viana do Castelo'],
        2 => ['lat' => 41.54830831744326, 'lng' => -8.416214198627008, 'nome' => 'Braga'],
        3 => ['lat' => 41.30024716955441, 'lng' => -7.7459606458724055, 'nome' => 'Vila Real'],
        4 => ['lat' => 41.806037910030504, 'lng' => -6.758317418665908, 'nome' => 'Bragança'],
        5 => ['lat' => 41.157917311754375, 'lng' => -8.630022713917526, 'nome' => 'Porto'],
        6 => ['lat' => 40.640550906661716, 'lng' => -8.654584556650637, 'nome' => 'Aveiro'],
        7 => ['lat' => 40.653599581478595, 'lng' => -7.82875004439962, 'nome' => 'Viseu'],
        8 => ['lat' => 40.534923159682315, 'lng' => -7.1314080021531865, 'nome' => 'Guarda'],
        9 => ['lat' => 40.20225170847529, 'lng' => -8.410785148203193, 'nome' => 'Coimbra'],
        10 => ['lat' => 39.82694109278938, 'lng' => -7.421412673517717, 'nome' => 'Castelo Branco'],
        11 => ['lat' => 39.739599011388464, 'lng' => -8.719434157989355, 'nome' => 'Leiria'],
        12 => ['lat' => 38.72128608198941, 'lng' => -9.133647313166383, 'nome' => 'Lisboa'],
        13 => ['lat' => 39.23524590485262, 'lng' => -8.680465183802433, 'nome' => 'Santarém'],
        14 => ['lat' => 38.52609303231486, 'lng' => -8.887451649342236, 'nome' => 'Setúbal'],
        15 => ['lat' => 39.29703750065809, 'lng' => -7.430936768193475, 'nome' => 'Portalegre'],
        16 => ['lat' => 38.570328173942976, 'lng' => -7.910669827839234, 'nome' => 'Évora'],
        17 => ['lat' => 38.01467964624268, 'lng' => -7.861647790359124, 'nome' => 'Beja'],
        18 => ['lat' => 37.01585771875306, 'lng' => -7.936501322421256, 'nome' => 'Faro']
    ];

    // Função para calcular a distância com a fórmula de Haversine
    function calcularDistancia($lat1, $lng1, $lat2, $lng2) {
        $raioTerra = 6371; // Raio médio da Terra em km
        $dLat = deg2rad($lat2 - $lat1);
        $dLng = deg2rad($lng2 - $lng1);
        $a = sin($dLat/2) * sin($dLat/2) +
            cos(deg2rad($lat1)) * cos(deg2rad($lat2)) *
            sin($dLng/2) * sin($dLng/2);
        $c = 2 * atan2(sqrt($a), sqrt(1 - $a));
        return $raioTerra * $c; // Distância em km
    }

    // Função para calcular tempo de viagem e preço
    function calcularViagem($distancia) {
        $velocidadeMedia = 120; // km/h
        $precoPorKm = 0.10; // € por km
        
        $tempoHoras = $distancia / $velocidadeMedia;
        $horas = floor($tempoHoras);
        $minutos = round(($tempoHoras - $horas) * 60);
        $preco = $distancia * $precoPorKm;
        
        return [
            'tempo' => sprintf("%02d:%02d", $horas, $minutos),
            'preco' => number_format($preco, 2, ',', '.') . ' €'
        ];
    }

    // Exemplo de uso (Porto para Lisboa)
    $origem = 5; // Porto
    $destino = 12; // Lisboa

    die(
        isset($cidades[$origem]) && isset($cidades[$destino]) 
            ? json_encode(
                array_merge(
                    ['distancia' => calcularDistancia(
                        $cidades[$origem]['lat'], 
                        $cidades[$origem]['lng'], 
                        $cidades[$destino]['lat'], 
                        $cidades[$destino]['lng']
                    )],
                    calcularViagem(
                        calcularDistancia(
                            $cidades[$origem]['lat'], 
                            $cidades[$origem]['lng'], 
                            $cidades[$destino]['lat'], 
                            $cidades[$destino]['lng']
                        )
                    )
                )
            ) 
            : json_encode(['erro' => 'Cidade inválida'])
    );
?>