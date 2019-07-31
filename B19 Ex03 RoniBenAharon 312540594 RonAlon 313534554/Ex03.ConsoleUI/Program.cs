namespace Ex03.ConsoleUI
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Ex03.GarageLogic;

    // $G$ SFN-999 (-10) The program does not allow to inset new vehicle into garage

    public class Program
    {
        public static void Main()
        {
            MenuManager menuManager = new MenuManager();
            menuManager.StartProgram();
        }
    }
}
