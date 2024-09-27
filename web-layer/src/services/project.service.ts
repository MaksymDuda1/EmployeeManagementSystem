import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { ProjectModel } from "../models/project.model";

@Injectable({providedIn: "root"})
export class ProjectService{
    private path: string = "api/project/";

    constructor(private client: HttpClient){}

    getAll(): Observable<ProjectModel[]>{
        return this.client.get<ProjectModel[]>(this.path);
    }

    getById(id: string): Observable<ProjectModel>{
        return this.client.get<ProjectModel>(this.path + id)
    }

    add(projectModel: ProjectModel): Observable<any>{
        return this.client.post<ProjectModel>(this.path, projectModel);
    }

    update(projectModel: ProjectModel): Observable<any>{
        return this.client.put<ProjectModel>(this.path, projectModel);
    }
}