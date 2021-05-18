namespace Domain.Dtos
{
    public class PagamentoRequestDto
    {
        public double Valor { get; set; }
        public CartaoDto Cartao { get; set; }
    }
}
