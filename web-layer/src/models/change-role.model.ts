import { Role } from "../enums/role.enum";

export class ChangeRoleModel{
    userId: string = "";
    userRole: Role = Role.Initial;
}