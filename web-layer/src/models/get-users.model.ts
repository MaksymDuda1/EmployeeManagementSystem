import { Role } from "../enums/role.enum";

export class GetUsersModel{
    secondName : string | null = null; 
    role: string | null = null;
    minRegistrationDate: string | null = null;
    maxRegistrationDate: string | null = null;
    isLocked: boolean | null = null;
    hasNextPage: boolean = false;
    hasPreviousPage: boolean = false;
    page: number = 1;
    pageSize: number = 5;
    }