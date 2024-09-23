import { ProjectModel } from "./project.model";
import { TaskModel } from "./task.model";
import { UserModel } from "./user.model";

export class EmployeeModel {
    id: string = "";
    position: string = "";
    hireDate: Date = new Date();
    userId: string = "";
    user: UserModel = new UserModel();
    tasks: TaskModel[] = [];
    projects: ProjectModel[] = [];
}