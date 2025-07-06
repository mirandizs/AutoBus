import { isDevMode } from "@angular/core"

export class Definicoes {
    static API_URL = window.location.href.includes('localhost') ? "http://localhost:3000/api/" : 'https://servidorautobus.onrender.com/api/'
}