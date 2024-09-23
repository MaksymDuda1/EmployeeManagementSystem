import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { ManagerModel } from "../models/manager.model";

@Injectable({providedIn: "root"})
export class MangerService{
    private path: string = "api/manager/";

    constructor(private client: HttpClient){}

    getAll(): Observable<ManagerModel[]>{
        return this.client.get<ManagerModel[]>(this.path);
    }

    getById(id: string): Observable<ManagerModel>{
        return this.client.get<ManagerModel>(this.path + id)
    }

    add(managerModel: ManagerModel): Observable<any>{
        return this.client.post<ManagerModel>(this.path, managerModel);
    }

    update(managerModel: ManagerModel): Observable<any>{
        return this.client.put<ManagerModel>(this.path, managerModel);
    }
}