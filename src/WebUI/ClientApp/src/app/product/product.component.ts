import { Component, OnInit } from '@angular/core';
import { ProductsVm, ProductListClient, ProductListDto } from "../web-api-client";
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  debug = false;

  vm: ProductsVm;

  selectedList: ProductListDto;

  constructor(private listClient: ProductListClient, private itemsClient: BsModalService) { 
    this.listClient.get().subscribe(
      result => {
        this.vm = result;
        if (this.vm.lists.length) {
          this.selectedList = this.vm.lists[0];
        }
      },
      error => console.error(error)
    );
  }

  ngOnInit(): void {
  }

}
