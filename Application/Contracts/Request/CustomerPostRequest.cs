namespace Application.Contracts.Request
{
    public class CustomerPostRequest
    {
        public string Name { get; set; } = null!;

        public string Cpf { get; set; } = null!;

        public string? Cellphone { get; set; }

        public string? Email { get; set; }

        public DateOnly? Birthdate { get; set; }
    }
}
