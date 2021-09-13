import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AssetListComponent } from './components/asset-list/asset-list.component';
import { AssetDetailsComponent } from './components/asset-details/asset-details.component';
import { AddAssetComponent } from './components/add-asset/add-asset.component';

const routes: Routes = [
  { path: '', redirectTo: 'asset-list', pathMatch: 'full' },
  { path: 'asset-list', component: AssetListComponent },
  { path: 'asset/:AssetId', component: AssetDetailsComponent },
  { path: 'add', component: AddAssetComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
