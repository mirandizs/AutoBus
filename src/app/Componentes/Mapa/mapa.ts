import { Component, inject, Input, Renderer2 } from '@angular/core';
import { GoogleMapsModule, MapMarker } from '@angular/google-maps';
import { RouterModule } from '@angular/router';
import { HttpService } from '../../Services/Http.service';
import { Definicoes } from '../../Definicoes';
import polygonPortugal from './polygon-portugal';

type Coordenada = {
  lat: number
  lng: number
}

@Component({
  selector: 'mapa',
  imports: [RouterModule, GoogleMapsModule],
  templateUrl: './mapa.html',
  styleUrl: './mapa.css'
})

export class Mapa {

  ServicoHttp = inject(HttpService)
  Renderer = inject(Renderer2)

  options: google.maps.MapOptions = {
    mapId: "DEMO_MAP_ID",
    center: {
      lat: 40.211, lng: -8.4292
    },
    zoom: 6,
    mapTypeId: 'satellite',

    //minZoom: 5,
    //maxZoom: 19,
  };

  Markers: any[] = []

  PolygonPortugal = polygonPortugal

  PontoA: Coordenada | undefined
  PontoB: Coordenada | undefined

  VisuaisLinha: google.maps.PolylineOptions = {
    strokeColor: '#FF0000',
    strokeOpacity: 1.0,
    strokeWeight: 2,
  };

  GetLocation(): Promise<GeolocationPosition> {
    return new Promise((resolve, reject) => {
      if (!navigator.geolocation) {
        reject('Geolocation not supported');
      } else {
        navigator.geolocation.getCurrentPosition(
          position => resolve(position),
          error => reject(error)
        );
      }
    });
  }

  AdicionarMarcador(Marcador: any) {
    this.Markers.push(Marcador)
  }

  async ngOnInit() {
    const Location = await this.GetLocation();
    this.options.center = { lat: Location.coords.latitude, lng: Location.coords.longitude };
    this.AdicionarMarcador({
      position: { lat: Location.coords.latitude, lng: Location.coords.longitude },
      title: 'Voce esta aqui'
    })


    const Localidades = await this.ServicoHttp.Request(Definicoes.API_URL + 'localidades', 'GET', 'Falha ao carregar localidades')
    for (const Localidade of Localidades) {
      const Coordenadas: Coordenada = { lat: Localidade.latitude, lng: Localidade.longitude }
      this.AdicionarMarcador({
        position: Coordenadas,
        title: Localidade.local,
        content: this.CriarTexto(Localidade.local, Coordenadas),
      })
    }
  }

  CriarTexto(text: string, Coordenadas: Coordenada): HTMLElement {
    const div = this.Renderer.createElement('div');
    this.Renderer.setProperty(div, 'textContent', text);
    this.Renderer.addClass(div, 'marcador');

    this.Renderer.listen(div, 'click', (event) => {
      event.stopPropagation();

      let pontoEquivalente: 'A' | 'B' | undefined;
      if (this.PontoA?.lat === Coordenadas.lat && this.PontoA?.lng === Coordenadas.lng) {
        pontoEquivalente = 'A';
      } else if (this.PontoB?.lat === Coordenadas.lat && this.PontoB?.lng === Coordenadas.lng) {
        pontoEquivalente = 'B';
      }

      if (!pontoEquivalente) {
        if (!this.PontoA) {
          this.PontoA = Coordenadas;
        } else {
          this.PontoB = Coordenadas;
        }
        this.Renderer.addClass(div, 'selecionado');
      } else {
        this.Renderer.removeClass(div, 'selecionado');
        if (pontoEquivalente === 'A') {
          this.PontoA = undefined;
        } else if (pontoEquivalente === 'B') {
          this.PontoB = undefined;
        }
      }
    });
    return div;
  }
}
