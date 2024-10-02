import { HttpClient, HttpParams } from "@angular/common/http";
import { Observable } from "rxjs"; 
import { Injectable } from "@angular/core";
import { PagedList } from "../models/pagedList.model";
import { GetUsersModel } from "../models/get-users.model";
import { UserModel } from "../models/user.model";

@Injectable({ providedIn: "root" })
export class UserService {
    private path: string = "api/user/";

    constructor(private client: HttpClient) {  }

    getAll(getUsersModel: GetUsersModel): Observable<PagedList> {
        let params = new HttpParams();

        if (getUsersModel.secondName != null)
            params = params.append("secondName", getUsersModel.secondName);
        if (getUsersModel.role != null)
            params = params.append("role", getUsersModel.role);
        if (getUsersModel.minRegistrationDate != null)
            params = params.append("minRegistrationDate", getUsersModel.minRegistrationDate);
        if (getUsersModel.maxRegistrationDate != null)
            params = params.append("maxRegistrationDate", getUsersModel.maxRegistrationDate);
        if (getUsersModel.isLocked != null)
            params = params.append("isLocked", getUsersModel.isLocked);
        params = params.append("page", getUsersModel.page);
        params = params.append("pageSize", getUsersModel.pageSize);

        return this.client.get<any>(this.path, { params })
    }

    getById(id: string): Observable<UserModel>{
        return this.client.get<UserModel>(this.path + id);
    }

    lock(id: string): Observable<any> {
        return this.client.put<void>(`${this.path}lock/${id}`, {});
    }

    
    unlock(id: string): Observable<any> {
        return this.client.put<void>(`${this.path}unlock/${id}`, {});
    }

    delete(id: string): Observable<any>{
        return this.client.delete(this.path + id);
    }
}