import { Component, OnInit } from '@angular/core';
import { AssetService } from '../../services/asset.service';

@Component({
  selector: 'app-asset-list',
  templateUrl: './asset-list.component.html',
  styleUrls: ['./asset-list.component.css']
})
export class AssetListComponent implements OnInit {
  columnDefs:any = [
    { field: 'AssetId',cellRenderer:function(paramObj:any){
      //for making cell as link
      return `<a href="/asset/`+paramObj.value+`">`+paramObj.value+`</a>`;
    }  
  },
  { field: 'Description' },
  { field: 'CreatedBy' },
];
rowData:any = [
];

  assets: any;

  constructor(private assetservie: AssetService) { }

  ngOnInit(): void {
    this.GetAssets();
  }

  GetAssets(): void {
    this.assetservie.getAll()
      .subscribe(
        data => {
          this.rowData = data;
          console.log(data);
        },
        error => {
          console.log(error);
        });
  }
}
