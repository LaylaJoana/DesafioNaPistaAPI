namespace Infra.CrossCutting.Pagamento
{
    public static class Util
    {
        public static bool ValidarNumeroCartao(string numeroCartao)
        {
            int length = numeroCartao.Length;
            if (length < 13) 
                return false;
            int totalDigitos = 0;
            int offset = length % 2;
            byte[] digits = new System.Text.ASCIIEncoding().GetBytes(numeroCartao);

            for (int i = 0; i < length; i++)
            {
                digits[i] -= 48;
                if (((i + offset) % 2) == 0)
                    digits[i] *= 2;

                totalDigitos += (digits[i] > 9) ? digits[i] - 9 : digits[i];
            }
            return ((totalDigitos % 10) == 0);
        }
    }
}
