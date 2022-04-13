import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";

import { FooterComponent } from "../Components/Layout/footer/footer.component";
import { NavMenuComponent } from "../Components/Layout/nav-menu/nav-menu.component";
import { HomeComponent } from "../pages/home/home.component";

@NgModule({
  declarations:[
    NavMenuComponent,
    HomeComponent,
    FooterComponent
  ],
  imports: [
    CommonModule,
    RouterModule
  ],
  exports:[
    NavMenuComponent,
    HomeComponent,
    FooterComponent
  ]
})
export class NavegationModule{}
