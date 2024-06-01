export interface Dispositivo {
    id: string;
    codigo: string;
    latitud: number;
    longitud: number;
    estado: 'Dentro' | 'Fuera' | 'Inactivo';
}

export interface FincaConDispositivos {
    dispositivos: Dispositivo[];
    total: number;
}
