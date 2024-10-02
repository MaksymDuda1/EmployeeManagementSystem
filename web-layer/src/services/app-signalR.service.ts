import { Injectable } from "@angular/core";
import * as signalR from '@microsoft/signalr';
import { BehaviorSubject } from "rxjs";


@Injectable({
    providedIn: 'root'
})
export class AppSignalrService {
    public hubConnection = new signalR.HubConnectionBuilder()
        .withUrl(`http://localhost:8000/api/active-admins`)
        .configureLogging(signalR.LogLevel.Information)
        .build();

    public activeAdmins$ = new BehaviorSubject(0);
    public activeAdmins: number = 0;

    constructor() {
        this.onUpdateActiveAdmins();
    }

    onUpdateActiveAdmins() {
        this.hubConnection.on("UpdateActiveAdmins", (activeUsers: number) => {
            this.activeAdmins = activeUsers;
            console.log(activeUsers);
            this.activeAdmins$.next(this.activeAdmins);
        })
    }

    public async startConnection() {
        try {
            await this.hubConnection.start();
        } catch (error) {
            console.log(error);
        }
    }

    public async join(id: string) {
        await this.hubConnection.start()
        return this.hubConnection.invoke("JoinChat", id);
    }

    public async leave() {
        return this.hubConnection.stop();
    }
}