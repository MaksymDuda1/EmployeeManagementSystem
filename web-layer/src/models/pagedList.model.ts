import { UserModel } from "./user.model";

export class PagedList{
    items = [];
    page: number = 0;
    pageSize: number = 0;
    totalCount: number = 0;
    hasNextPage: boolean = false;
    hasPreviousPage: boolean = false;
}