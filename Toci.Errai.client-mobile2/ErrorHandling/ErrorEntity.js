export default class ErrorEntity 
{

    IsError = false;
    ErrorMessage = "";
    ErrorCode = 0
    

    constructor(IsError, ErrorMessage, ErrorCode) {
        this.IsError = IsError;
        this.ErrorMessage = ErrorMessage;
        this.ErrorCode = ErrorCode;
    }

    /*GetErrorStatus()
    {
        const arrayX = [{id: 1, nameX: "dupa", age: 23 }];
        const dupa = arrayX[0].name;
        //[id, nameX, age] = arrayX[0];
        //console.log(age);
        return this.Err.IsError;
    }

    GetErrorMessage()
    {
        return this.Err.ErrorMessage;
    }*/
}
