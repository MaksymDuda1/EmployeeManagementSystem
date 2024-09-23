import { ProjectModel } from "./project.model";
import { UserModel } from "./user.model";

export class ManagerModel{
    id: string = "";
    department: string = "";
    userId: string = "";
    user: UserModel = new UserModel();
    projects: ProjectModel[] = [];
}