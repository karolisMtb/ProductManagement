import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Component } from '@angular/core';
import { HttpService } from '../../services/HttpService';
import { ProductType } from '../../models/ProductType';
import { ProductDto } from '../../models/ProductDto';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css'],
})
export class AddProductComponent {

  productName: string = '';
  productDescription: string = '';
  euros?= ['', Validators.required, Validators.nullValidator];
  cents?= ['', Validators.required, Validators.nullValidator];
  productTypes: ProductType[] = [];
  selectedProductTypeId: string = '';
  productType!: ProductType;

  constructor(private http: HttpClient, private router: Router, private httpService: HttpService) {
    this.getProductTypes();
  }

  exampleForm = new FormGroup({
    productName: new FormControl(this.productName.valueOf, [Validators.required, Validators.nullValidator]),
    productDescription: new FormControl(this.productName.valueOf, [Validators.required, Validators.nullValidator]),
  })

  submitForm() {

    const newProduct: ProductDto = {
      name: this.productName,
      description: this.productDescription,
      price: +`${this.euros}.${this.cents}`,
      productTypeId: this.selectedProductTypeId,
    };

    this.httpService.addNewProduct(newProduct).subscribe({
      next: (result) => {
        console.log('New product added successfully:', result);
        this.router.navigateByUrl('');
      },
      error: (error) => {
        console.error('Error adding new product:', error);
      }
    });
  }

  getProductTypes() {
    this.httpService.getProductTypes().subscribe({
      next: (result) => {
        this.productTypes = result;
      },
      error: (error) => {
        console.error(error);
      }
    });
  }
}
