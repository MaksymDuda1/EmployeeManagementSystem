import { Injectable } from "@angular/core";
import { TaskModel } from "../models/task.model";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";

@Injectable({ providedIn: "root" })
export class MangerService {
    private path: string = "api/task/";

    constructor(private client: HttpClient) { }

    getAll(): Observable<TaskModel[]> {
        return this.client.get<TaskModel[]>(this.path);
    }

    getById(id: string): Observable<TaskModel> {
        return this.client.get<TaskModel>(this.path + id)
    }

    add(taskModel: TaskModel): Observable<any> {
        return this.client.post<TaskModel>(this.path, taskModel);
    }

    update(taskModel: TaskModel): Observable<any> {
        return this.client.put<TaskModel>(this.path, taskModel);
    }
}