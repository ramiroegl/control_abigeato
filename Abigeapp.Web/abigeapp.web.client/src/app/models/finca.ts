import { Alerta } from "./dispositivo";

export interface Finca {
    id: string;
    nombre: string;
    latitud: number;
    longitud: number;
    perimetros: Perimetro[];
}

export interface Perimetro {
    id: string;
    nommbre: string;
    tipo: string;
    coordenadas: Coordenada[];
}

export interface FincaConAlertas {
    alertas: Alerta[]
    total: number;
}

export interface Coordenada {
    orden: number;
    latitud: number;
    longitud: number;
}
