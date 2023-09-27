export class LogInResponse{
    token: string;
    expiration: string;
    roles: string []
    

    constructor(token: string,expiration: string,roles: string[]){
        this.token = token;
        this.expiration = expiration;
        this.roles = roles;
    }
}