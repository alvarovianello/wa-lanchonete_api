namespace Application.Contracts.Request
{
    public class CustomerPutRequest
    {
        public string Name { get; set; } = null!;

        public string Cpf { get; set; } = null!;

        public string? Cellphone { get; set; }

        public string? Email { get; set; }

        public DateTime? Birthdate { get; set; }
    }
}
