import { Component, OnInit } from '@angular/core';
import { AssetService } from '../../services/asset.service';
import { ActivatedRoute, Router } from '../../../../node_modules/@angular/router';

@Component({
  selector: 'app-asset-details',
  templateUrl: './asset-details.component.html',
  styleUrls: ['./asset-details.component.css']
})
export class AssetDetailsComponent implements OnInit {

  currentasset:any = null;
  message = '';

  constructor(
    private assetservice: AssetService,
    private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit(): void {
    this.message = '';
    this.getasset(this.route.snapshot.paramMap.get('AssetId'));
  }

  getasset(AssetId:any): void {
    this.assetservice.get(AssetId)
      .subscribe(
        data => {
          this.currentasset = data;
          console.log(data);
        },
        error => {
          console.log(error);
        });
  }

  updatePublished(status:any): void {
    const data = {
      title: this.currentasset.title,
      description: this.currentasset.description,
      published: status
    };

    this.assetservice.create(this.currentasset)
      .subscribe(
        response => {
          this.currentasset.published = status;
          console.log(response);
        },
        error => {
          console.log(error);
        });
  }

  updateasset(): void {
    if(this.currentasset.FileName!='' && 
    this.currentasset.MIMEType!='' && 
    this.currentasset.CreatedBy!='' && 
    this.currentasset.Email!='' && 
    this.currentasset.Country!='' && 
    this.currentasset.Description!='')
    {
    this.assetservice.create(this.currentasset)
      .subscribe(
        response => {
          console.log(response);
          this.message = 'The asset was updated successfully!';
        },
        error => {
          console.log(error);
        });
      }
      else
      {
        alert('All the fields are mandatory');
      }
  }
}
