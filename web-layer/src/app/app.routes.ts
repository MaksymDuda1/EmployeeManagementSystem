import { Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { RegisrationComponent } from './regisration/regisration.component';
import { HomeComponent } from './home/home.component';
import { LandingComponent } from './landing/landing.component';

export const routes: Routes = [
    {path:"landing", component: LandingComponent},
    {path: "login", component: LoginComponent},
    {path: "registration", component: RegisrationComponent},
    {path: "home", component: HomeComponent},
    {path: "**", redirectTo: "/landing"}
];
