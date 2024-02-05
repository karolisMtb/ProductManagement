import { Component } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Product } from '../../models/Product';
import { HttpService } from '../../services/HttpService';

@Component({
  selector: 'app-product-table',
  templateUrl: './product-table.component.html',
  styleUrls: ['./product-table.component.css'],
})
export class ProductTableComponent {
  displayedColumns: string[] = ['id', 'name', 'description', 'price', 'productType', 'actions'];
  dataSource: MatTableDataSource<Product> = new MatTableDataSource<Product>([]);
  products: Product[] = [];

  constructor(private httpService: HttpService) {
    this.getProducts();
  }

  getProducts() {
    this.httpService.getAllProducts().subscribe({
      next: (result: Product[]) => {
        this.products = result;
        this.dataSource = new MatTableDataSource(this.products);
      },
      error: (error) => {
        console.error(error);
      }
    });
  }

  deleteProduct(productId: string) {
    console.log(productId);
    this.httpService.deleteProduct(productId).subscribe({
      next: () => {
        this.getProducts();
      },
      error: (error) => {
        console.error(error);
      }
    });
  }

  getId(productId: any) {
    console.log("Get id method: " + productId);
  }
}
