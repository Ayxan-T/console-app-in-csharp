using System.Runtime.CompilerServices;

namespace ATM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            void chooseOption (string name, string surname)
            {
                Console.WriteLine($"{name} {surname}'s bank account.");
                Console.WriteLine("Choose action to take on card.");
                Console.WriteLine("1. Show Balance");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Exit");
            }

            void deposit(cardHolder currentUser)
            {
                Console.WriteLine("How much to deposit? \nEnter the amount : ");
                double deposit = Convert.ToDouble(Console.ReadLine());
                currentUser.Balance += deposit;
                Console.WriteLine("Money added! Current balance : " + currentUser.Balance);
            }

            void withdraw(cardHolder currentUser)
            {
                Console.WriteLine("How much to withdraw? \nEnter the amount : ");
                double withdraw = Convert.ToDouble(Console.ReadLine());
                if (currentUser.Balance < withdraw)
                {
                    Console.WriteLine("Insuffiecient Balance! Withdraw cannot be done.");
                }
                else
                {
                    currentUser.Balance -= withdraw;
                    Console.WriteLine("Withdraw successfully done!");
                }
            }

            void balance(cardHolder currentUser)
            {
                Console.WriteLine("Current Balance : " + currentUser.Balance + "\n");
            }

            List<cardHolder> cardHolders = new List<cardHolder>();
            cardHolders.Add(new cardHolder("Aykhan", "Taghiyev", "12345678", "1404", 34.55));
            cardHolders.Add(new cardHolder("Aghakhan", "Taghiyev", "87654321", "1601", 44.25));
            cardHolders.Add(new cardHolder("Melek", "Taghiyeva", "12348765", "2301", 6.70));

            Console.WriteLine("Welcome to simpleBank!");
            Console.WriteLine("Please enter your card number : ");

            string cardNum = "";
            cardHolder currentUser;

            while (true)
            {
                try
                {
                    cardNum = Console.ReadLine();
                    currentUser = cardHolders.FirstOrDefault(a => a.getCardNumber() == cardNum);
                    if (currentUser != null) { break; }
                    else { Console.WriteLine("Card not recognized. Please try again. "); }
                } catch { Console.WriteLine("Card not regocnized. Please try again. "); }
            }

            Console.WriteLine("Please enter your pin : ");
            string pin = "";
            while (true)
            {
                try
                {
                    pin = Console.ReadLine();
                    if (String.Equals(pin, currentUser.getPin())) { break; }
                    else { Console.WriteLine("Incorrect pin. Please try again. "); }
                }
                catch { Console.WriteLine("Incorrect pin. Please try again. "); }
            }

            int option = 0;
            do
            {
                try
                {
                    chooseOption(currentUser.getFirstName(), currentUser.getLastName());
                    option = int.Parse(Console.ReadLine());
                    switch (option)
                    {
                        case 1:
                            {
                                balance(currentUser);
                                break;
                            }
                        case 2:
                            {
                                deposit(currentUser);
                                break;
                            }
                        case 3:
                            {
                                withdraw(currentUser);
                                break;
                            }
                        case 4:
                            {
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Wrong input. Enter 1, 2, 3 or 4");
                                break;
                            }
                    }
                } catch { Console.WriteLine("Wrong input. Enter 1, 2, 3 or 4"); }

            } while (option != 4);

            Console.WriteLine($"Signed out. Have a nice day {currentUser.getFirstName()}! :)");

        }

        class cardHolder
        {
            private string firstName; 
            private string lastName;
            private string cardNumber;
            private string pin;
            private double balance = 0.0;

            public cardHolder (string firstName, string lastName, string cardNumber, string pin, double balance)
            {
                this.firstName = firstName;
                this.lastName = lastName;
                this.cardNumber = cardNumber;
                this.pin = pin;
                this.balance = balance;
            }

            public string getFirstName() { return firstName; }
            public string getLastName() { return lastName; }
            public string getCardNumber() {  return cardNumber; }
            public string getPin() {  return pin; }

            public double Balance
            {
                get { return balance; }
                set { balance = value; }
            }
        }


    }
}
