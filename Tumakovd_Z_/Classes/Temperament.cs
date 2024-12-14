using System;

namespace TumakovSB
{
    struct Temperament
    {
        #region Field
        public int scandalousness;
        public int intelligence;
        #endregion
        #region Contructors
        public Temperament(int scandalousness, int intelligence)
        {
            if (scandalousness < 0 || scandalousness > 10 || intelligence > 10 || intelligence < 0)
            {
                throw new ArgumentException("Аргументы должны принимать значения от 0 до 10");
            }
            this.scandalousness = scandalousness;
            this.intelligence = intelligence;
        }
        #endregion
        #region Methods
        public void PrintTemperament()
        {
            Console.WriteLine($"Скандальность: {scandalousness}\nИнтеллект: {intelligence}");
        }
        #endregion
    }
}