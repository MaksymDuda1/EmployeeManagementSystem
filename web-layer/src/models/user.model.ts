export class UserModel{
    id: string = "";
    username: string = "";
    firstName: string = "";
    role: string | null = null;
    secondName: string = "";
    registrationDate: Date = new Date();
    LockoutEnd: Date = new Date();
    email: string = "";
}

export const PAGE_SIZE_OPTIONS = [5, 10, 20];
