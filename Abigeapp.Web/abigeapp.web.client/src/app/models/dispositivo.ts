import { Perimetro } from "./finca";

export interface Dispositivo {
    id: string;
    codigo: string;
    latitud: number;
    longitud: number;
    estado: 'Dentro' | 'Fuera' | 'Inactivo';
}

export interface DispositivoConPerimetro extends Dispositivo {
    perimetro: Perimetro;
}

export interface FincaConDispositivos {
    dispositivos: Dispositivo[];
    total: number;
}

export interface Posicion {
    latitud: number;
    longitud: number;
}

export interface Alerta {
    id: string;
    descripcion: string;
    fechaCreacion: Date;
    dispositivo: Dispositivo;
    latitud: number
    longitud: number;
    estado:'Pendiente' | 'Resuelta';
}