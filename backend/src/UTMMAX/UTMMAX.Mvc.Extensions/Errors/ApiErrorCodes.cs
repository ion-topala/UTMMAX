namespace UTMMAX.Mvc.Extensions.Errors;

public static class ApiErrorCodes
{
    public const  string Forbidden                  = "forbidden";
    public const  string Unauthorized               = "unauthorized";
    public static string IdentityNotFound           = "user_not_found";
    public static string InternalServerError        = "internal_server_error";
    public static string InvalidData                = "invalid_data";
    public static string NewPasswordMustBeDifferent = "new_password_must_be_different";

    public static class Register
    {
        public static string UserAlreadyExists = "user_already_exists";
        public const  string UserDisabled      = "user_disabled";
    }

    public static class Authentication
    {
        public static string InvalidEmailOrPassword            = "invalid_email_or_password";
        public static string InvalidFirstNameOrLastNameOrPhone = "invalid_firstname_or_lastname_or_phone";
        public static string InvalidRefreshToken               = "invalid_refresh_token";
    }
}