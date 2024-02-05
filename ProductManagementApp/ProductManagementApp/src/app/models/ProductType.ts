import { Product } from "./Product";

export interface ProductType {
    id: string;
    typeName: string;
    products: Product[];
  }