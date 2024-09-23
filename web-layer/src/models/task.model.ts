import { Status } from "../enums/status.enum";
import { EmployeeModel } from "./employee.model";
import { ProjectModel } from "./project.model";

export class TaskModel {
    id: string = "";
    name: string = "";
    description: string | null = null;
    deadlineDate: Date = new Date();
    status: Status = Status.Pending;
    projectId : string = "";
    employeeId: string = "";
    employee: EmployeeModel = new EmployeeModel();
    project: ProjectModel = new ProjectModel();
}