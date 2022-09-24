namespace UTMMAX.Mvc.Extensions.Errors;

public static class ApiErrorMessage
{
    public const string AccessDenied                      = "Not enough permisions to perform this action, please contact your administrator";
    public const string InvalidData                       = "Please insert valid data";
    public const string EmailOrPasswordInvalid            = "Your email or password is invalid";
    public const string UserAlreadyExists                 = "This user already exists";
    public const string FirstNameOrLastNameOrPhoneInvalid = "Your first name, time zone, last name or phone is invalid";
    public const string AccountNotExists                  = "This account does not exist. Enter a different account or create one, if you don't have it";
    public const string NewPasswordMustBeDifferent        = "New password must be different from current password";
    public const string IncorrectPassword                 = "Please introduce the correct password";
    public const string UserDisabled                      = "Account has been disabled, please contact your administrator";
}