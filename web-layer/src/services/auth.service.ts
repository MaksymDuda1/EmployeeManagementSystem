import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { LoginModel } from "../models/login.model";
import { RegistrationModel } from "../models/registration.model";
import { ApiTokenModel } from "../models/api-token.model";

@Injectable({ providedIn: "root" })
export class AuthService {
    constructor(private client: HttpClient) {

    }

    private path: string = "api/auth";


    login(loginForm: any): Observable<ApiTokenModel> {
        return this.client.post<any>(`${this.path}/login`, loginForm);
    }

    registration(registrationForm: any): Observable<ApiTokenModel> {
        return this.client.post<any>(`${this.path}/registration`, registrationForm);
    }
}