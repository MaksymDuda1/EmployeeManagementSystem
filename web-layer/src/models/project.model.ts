import { EmployeeModel } from "./employee.model";
import { ManagerModel } from "./manager.model";
import { TaskModel } from "./task.model";

export class ProjectModel {
    id : string = '';
    name : string = '';
    customer : string = '';
    startDate : Date = new Date();
    endDate : Date = new Date();
    tasks : TaskModel[] = [];
    managers : ManagerModel[] = [];
    employees : EmployeeModel[] = [];
}