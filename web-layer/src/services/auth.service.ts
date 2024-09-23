import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { LoginModel } from "../models/login.model";
import { RegistrationModel } from "../models/registration.model";

@Injectable({ providedIn: "root" })
export class AuthService {
    constructor(private client: HttpClient) {

    }

    private path: string = "api/auth";


    login(loginModel: LoginModel): Observable<any> {
        return this.client.post<any>(`${this.path}/login`, loginModel);
    }

    registration(registrationModel: RegistrationModel): Observable<any> {
        return this.client.post<any>(`${this.path}/registration`, registrationModel);
    }
}