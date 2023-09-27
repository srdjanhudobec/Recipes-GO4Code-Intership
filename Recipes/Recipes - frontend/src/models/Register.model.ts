export class Register{
    email: string;
    username: string;
    password: string
    

    constructor(Email: string,Username: string,Password: string){
        this.email = Email;
        this.username = Username;
        this.password = Password;
    }
}