namespace Customer.Domain.Helpers
{
    public class Utils
    {
        public static bool CpfIsValid(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                return false;

            cpf = new string(cpf.Where(char.IsDigit).ToArray());

            if (cpf.Length != 11)
                return false;

            if (cpf.Distinct().Count() == 1)
                return false;

            int[] numbers = cpf.Select(c => c - '0').ToArray();

            int firstDigit = CalculateDigit(numbers, 9);
            int secondDigit = CalculateDigit(numbers, 10);

            return numbers[9] == firstDigit &&
                   numbers[10] == secondDigit;
        }

        private static int CalculateDigit(int[] numbers, int position)
        {
            int sum = 0;
            int weight = position + 1;

            for (int i = 0; i < position; i++)
            {
                sum += numbers[i] * weight;
                weight--;
            }

            int remainder = sum % 11;

            return remainder < 2 ? 0 : 11 - remainder;
        }
    }
}
