namespace TestesAPIAutomacao
{
    public static class Endpoints
    {
        public const string BASE_URL = "https://reqres.in/api";
        public const string USERS = "/users";
        public const string LOGIN = "/login";
        public const string PROTECTED_RESOURCE = "/unknown"; // Simulando um recurso protegido
        public const string PUBLIC_RESOURCE = "/users/2"; // Simulando um recurso público que precisa de token
    }
}
