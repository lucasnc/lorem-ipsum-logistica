export interface Endereco {
  id: number;
  tipoEndereco: number;
  cep: string;
  logradouro: string;
  localidade: string;
  uf: string;
  numero: string;
  complemento?: string;
  bairro?: string;
}
