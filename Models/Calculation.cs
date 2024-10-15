using System.ComponentModel.DataAnnotations;

namespace St10375622Part2.Models
{
    public class Calculation
    {
        [Key]
        public int CalculationId { get; set; }

        [Required(ErrorMessage = "Hours Worked are Required")]
        [Range(1, 1000, ErrorMessage = "Hours Worked must be between 1 and 1000")]
        public int HoursWorked { get; set; }
        [Required(ErrorMessage = "Hourly Rate is required")]
        [Range(20, 1000, ErrorMessage = "Hourly Rate must be between 20 and 1000")]
        public int HourlyRate { get; set; }

        public int IntrestEarned { get; set; }

        //preform the calculation of the total payment
        public int TotalPayment { get; set; }

        public void CalculateTotalPayment()
        {
            // Base payment is simply hours worked times hourly rate
            int basePayment = HoursWorked * HourlyRate;

            // Determine the interest rate based on hours worked
            int interestRate = 0;

            if (HoursWorked <= 100)
            {
                interestRate = (int)0.01m; // 1% interest for <= 100 hours
            }
            else if (HoursWorked <= 500)
            {
                interestRate = (int)0.02m; // 2% interest for <= 500 hours
            }
            else
            {
                interestRate = (int)0.03m; // 3% interest for > 500 hours
            }

            // Calculate the interest earned
            IntrestEarned = basePayment * interestRate;

            // Total payment is the base payment plus interest earned
            TotalPayment = basePayment + IntrestEarned;
        }


    }
}
