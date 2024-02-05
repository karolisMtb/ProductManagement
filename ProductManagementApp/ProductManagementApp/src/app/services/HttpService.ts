import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ProductType } from '../models/ProductType';
import { Product } from '../models/Product';
import { ProductDto } from '../models/ProductDto';

@Injectable({
  providedIn: 'root',
})
export class HttpService {
  private baseUrl = 'https://localhost:7048/api';

  constructor(private http: HttpClient) { }

  getProductTypes(): Observable<ProductType[]> {
    const url = `${this.baseUrl}/productTypes`;
    return this.http.get<ProductType[]>(url);
  }

  getProductType(id: string): Observable<ProductType> {
    const url = `${this.baseUrl}/productType/${id}`;
    console.log(url);
    return this.http.get<ProductType>(url);
  }

  addNewProduct(product: ProductDto): Observable<ProductDto> {
    const url = `${this.baseUrl}/product`;
    return this.http.post<ProductDto>(url, product);
  }

  getAllProducts(): Observable<Product[]> {
    const url = `${this.baseUrl}/products`;
    return this.http.get<Product[]>(url);
  }

  deleteProduct(id: string): Observable<any> {
    const url = `${this.baseUrl}/product/${id}`;
    return this.http.delete(url);
  }
}
