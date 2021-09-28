using System;

namespace Assignment1
{
    /** Program was made following the rubrics needed for the points and not meant to be refactored
     Contains 3 loops, 2 if conditions, 1 enum and 1 switch*/
    class Program
    {
        decimal numberOfTickets = 0;
        decimal totalNumberTix = 0;
        decimal totalSpent = 0;
        bool keepRunning = true;

        enum TicketChoices
        {
            purple = 50, 
            green = 80, 
            blue = 100
        }

        static void Main(string[] args)
        {
            Program program = new();
            program.Go();
        }

        private void Go()
        {
            int i = 0;
            //Format exception catcher
            try
            {
                //program will run until user stops it
                while (keepRunning)
                {
                    var values = Enum.GetValues(typeof(TicketChoices));
                    foreach (TicketChoices ticket in values)
                    {
                        Console.Write($"How many {ticket} ticket bought? ");
                        numberOfTickets = int.Parse(Console.ReadLine());
                        AssignValues(ticket, numberOfTickets);
                    }
                    decimal averageSpent = totalSpent / totalNumberTix;
                    Console.WriteLine($"Joe spent a total of ${totalSpent}. His average price of watching the games is ${averageSpent:#.##}");


                    //Checking input using while loop and two if conditions
                    String answer = String.Empty;
                    bool isCorrect = false;

                    while (!isCorrect)
                    {
                        Console.Write("Do you want to try again (y/n)? ");
                        answer = Console.ReadLine();
                        if ((answer.Equals("n", StringComparison.OrdinalIgnoreCase)) || (answer.Equals("y", StringComparison.OrdinalIgnoreCase)))
                        {
                            isCorrect = true;
                        }
                        else
                        {
                            Console.WriteLine("Please input (y/n) only");
                        }
                    }

                    //if wants to try again, refresh all counters. If not exit program
                    if (answer.Equals("n", StringComparison.OrdinalIgnoreCase))
                    {
                        keepRunning = false;
                    }
                    else
                    {
                        numberOfTickets = 0;
                        totalNumberTix = 0;
                        totalSpent = 0;
                    }
                    i++;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Input should be numeric only");
            }
        }

        //Assigning values using switch
        private void AssignValues(TicketChoices ticket, decimal numberOfTicket)
        {
            switch (ticket) 
            {
                case TicketChoices.purple:
                    totalNumberTix += numberOfTicket;
                    totalSpent += numberOfTicket * (decimal)TicketChoices.purple;
                    break;
                case TicketChoices.green:
                    totalNumberTix += numberOfTicket;
                    totalSpent += numberOfTicket * (decimal)TicketChoices.green;
                    break;
                case TicketChoices.blue:
                    totalNumberTix += numberOfTicket;
                    totalSpent += numberOfTicket * (decimal)TicketChoices.blue;
                    break;
                default:
                    break;
            }
        }
    }
}
