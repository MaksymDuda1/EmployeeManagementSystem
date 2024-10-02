import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { EmployeeModel } from "../models/employee.model";

@Injectable({providedIn: "root"})
export class EmployeeService{
    private path: string = "api/employee/";

    constructor(private client: HttpClient){}

    getAll(): Observable<EmployeeModel[]>{
        return this.client.get<EmployeeModel[]>(this.path);
    }

    getById(id: string): Observable<EmployeeModel>{
        return this.client.get<EmployeeModel>(this.path + id)
    } 

    add(employeeModel: EmployeeModel): Observable<any>{
        return this.client.post<EmployeeModel>(this.path, employeeModel);
    }

    update(employeeModel: EmployeeModel): Observable<any>{
        return this.client.put<EmployeeModel>(this.path, employeeModel);
    }
}