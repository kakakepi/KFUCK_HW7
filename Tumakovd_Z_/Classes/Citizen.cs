namespace TumakovSB
{
    enum Problem {
        Отопление,
        Оплата,
        Другое
    }
    class Citizen
    {
        #region Field
        public string name;
        Random random = new Random();
        static HashSet<long> uniqueNumbers = new HashSet<long>();
        public Problem problem;
        long passportNumber;
        public Temperament temperament;
        int scandalousness;
        int intelligence;
        #endregion
        #region Constructors
        public Citizen(string name, Problem problem,int intelligence, int scandalousness) {
            this.name = name;
            passportNumber = MakeRandom();
            this.problem = problem;
            temperament = new Temperament(scandalousness, intelligence);
        }
        public Citizen(){
            passportNumber = MakeRandom();
        }
        #endregion
        #region Methods
        long MakeRandom()
        {
            Random rnd = new Random();
            long number = rnd.Next(1000000000, int.MaxValue);
            if (!uniqueNumbers.Contains(number))
            {
                uniqueNumbers.Add(number);
                return number;
            }
            else
            {
                while (uniqueNumbers.Contains(number))
                {
                    number = rnd.Next(1000000000, int.MaxValue);
                }
                uniqueNumbers.Add(number);
                return number;
            }
        }
        public void PrintInfo()
        {
            Console.WriteLine($"Имя: {name}\nНомер паспорта: {passportNumber}\nПроблема: \"{problem}\"\nПроблемы: {problem}");
            temperament.PrintTemperament();
        }
        #endregion
    }
}