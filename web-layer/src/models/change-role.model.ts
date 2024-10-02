import { UpdateRoleEmloyeeModel } from "./update-role.employee.model";
import { UpdateRoleManagerModel } from "./update-role.manager.model";

export class ChangeRoleModel{
    userId: string = "";
    manager: UpdateRoleManagerModel | null = null;
    employee: UpdateRoleEmloyeeModel | null = null;
    role: string = "";
} 