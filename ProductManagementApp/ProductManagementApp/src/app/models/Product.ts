import { ProductType } from "./ProductType";

export interface Product {
    id: string;
    name: string;
    description?: string;
    price: number;
    productTypeId: string;
    productType: ProductType | null;
  }
 