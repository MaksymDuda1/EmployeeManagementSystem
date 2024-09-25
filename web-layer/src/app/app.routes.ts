import { Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { RegistrationComponent } from './registration/regisration.component';
import { HomeComponent } from './home/home.component';
import { LandingComponent } from './landing/landing.component';
import { WaitingRoomComponent } from './waiting-room/waiting-room.component';
import { TopMenuComponent } from './top-menu/top-menu.component';
import { RoleBasedComponent } from './role-based/role-based.component';

export const routes: Routes = [
    {path: "",
        component: TopMenuComponent,
        children: [
            {path: "sign-in", component: LoginComponent},
            {path: "sign-up", component: RegistrationComponent},
            {path: "waiting-room", component: WaitingRoomComponent},
            {path: "role-based", component: RoleBasedComponent},
        ]
    },
    {path:"landing", component: LandingComponent},
    {path: "home", component: HomeComponent},
    {path: "**", redirectTo: "/landing"}
];
