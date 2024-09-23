import { Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { RegisrationComponent } from './regisration/regisration.component';

export const routes: Routes = [
    {path: "login", component: LoginComponent},
    {path: "registration", component: RegisrationComponent},
    {path: "**", redirectTo: "/login"}

];
