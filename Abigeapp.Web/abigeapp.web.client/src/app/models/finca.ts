export interface Finca {
    id: string;
    latitud: number;
    longitud: number;
    perimetros: Perimetro[];
}

export interface Perimetro {
    id: string;
    nommbre: string;
    tipo: number;
    coordenadas: Coordenada[];
}

export interface Coordenada {
    orden: number;
    latitud: number;
    longitud: number;
}