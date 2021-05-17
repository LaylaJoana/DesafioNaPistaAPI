namespace Infrastructure.Pagamento
{
    public static class Util
    {
        public static bool ValidarNumeroCartao(string numeroCartao)
        {
            return !string.IsNullOrWhiteSpace(numeroCartao);
        }
    }
}
