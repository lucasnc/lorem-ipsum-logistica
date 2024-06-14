import { Endereco } from "./endereco";

export interface Cliente {
  id: number;
  nome: string;
  dataNascimento: string;
  genero: number;
  enderecos: Endereco[]
}
