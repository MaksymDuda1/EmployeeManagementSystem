import { Inject, Injectable } from "@angular/core";
import { BehaviorSubject, Observable } from "rxjs";
import { StatisticModel } from "../models/statistic.model";
import { HttpClient } from "@angular/common/http";

@Injectable({"providedIn": "root"})
export class StatisticService{
    private path: string = "api/admin/";


    public lockedUsers$ = new BehaviorSubject(0);
    public lockedUsers: number = 0;

    constructor(private client: HttpClient){}

    getStatistics():Observable<StatisticModel>{
        return this.client.get<StatisticModel>(this.path);
    }

    lockedUsersAmountChage(){
        
    }
}