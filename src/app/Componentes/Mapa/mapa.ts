import { Component, Input } from '@angular/core';
import { GoogleMapsModule, MapMarker } from '@angular/google-maps';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'mapa',
  imports: [RouterModule, GoogleMapsModule],
  templateUrl: './mapa.html',
  styleUrl: './mapa.css'
})

export class Mapa {
  options: google.maps.MapOptions = {
    mapId: "DEMO_MAP_ID",
    center: { lat: 0, lng: 0 },
    zoom: 4,
    mapTypeId: 'satellite',
    
    //minZoom: 5,
    //maxZoom: 19,
  };

  Markers: any[] = []

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
    this.options.zoom = 17
    this.AdicionarMarcador({
      position: { lat: Location.coords.latitude, lng: Location.coords.longitude },
      title: 'Voce esta aqui'
    })
  }
}
