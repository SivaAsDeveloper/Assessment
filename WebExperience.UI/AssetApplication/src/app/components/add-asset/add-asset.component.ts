import { Component, OnInit } from '@angular/core';
import { AssetService } from '../../services/asset.service';

@Component({
  selector: 'app-add-asset',
  templateUrl: './add-asset.component.html',
  styleUrls: ['./add-asset.component.css']
})
export class AddAssetComponent implements OnInit {

  asset = {
    AssetId: null,
    FileName: '',
    MIMEType: '',
    CreatedBy: '',
    Email: '',
    Country:'',
    Description:''

  };
  submitted = false;

  constructor(private assetservice: AssetService) { }

  ngOnInit(): void {
  }

  saveAsset(): void {
    const data = {
      id: this.asset.AssetId,
      FileName: this.asset.FileName,
      MIMEType: this.asset.MIMEType,
      CreatedBy: this.asset.CreatedBy,
      Email: this.asset.Email,
      Country:this.asset.Country,
      Description:this.asset.Description
    };

    if(data.FileName!='' && data.MIMEType!='' && data.CreatedBy!='' && data.Email!='' && data.Country!='' && data.Description!='')
  {
    this.assetservice.create(data)
      .subscribe(
        response => {
          console.log(response);
          this.submitted = true;
        },
        error => {
          console.log(error);
        });
      }
      else
      {
        alert('All the Fields are mandatory');
      }
  }

  newAsset(): void {
    this.submitted = false;
    this.asset = {
      AssetId: null,
      FileName: '',
      MIMEType: '',
      CreatedBy: '',
      Email: '',
      Country:'',
      Description:''
    };
  }

}
