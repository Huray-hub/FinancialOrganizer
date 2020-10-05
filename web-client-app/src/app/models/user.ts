export interface IUser {
    username: string;
    token: string;
}

export interface IUserFormValues {
    firstName?: string;
    lastName?: string;
    dataOfBirth?: Date;
    country?: string;
    email: string;
    password: string;
}

