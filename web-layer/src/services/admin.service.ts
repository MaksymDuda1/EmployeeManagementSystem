import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ChangeRoleModel } from "../models/change-role.model";
import { BehaviorSubject, Observable } from "rxjs";
import { UserModel } from "../models/user.model";
import { StatisticModel } from "../models/statistic.model";

@Injectable({providedIn: "root"})
export class AdminService{
    private path: string = "api/admin/";

    constructor(private client: HttpClient){}

    getUsersWithoutRoles() : Observable<UserModel[]>{
        return this.client.get<UserModel[]>(this.path);
    }

    changeUserRole(changeRoleModel: ChangeRoleModel) : Observable<any>{
        console.log(changeRoleModel)
        return this.client.put<ChangeRoleModel>(this.path, changeRoleModel);
    }
}