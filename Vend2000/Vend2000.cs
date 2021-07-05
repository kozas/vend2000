using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;

namespace Vend2000
{
    public class Vend2000
    {
        private readonly ICoinValidator coinValidator;
        private readonly IGumDispenser gumDispenser;
        private readonly ICoinStorage coinStorage;

        string logo = @"
   _    __               _____   ____  ____  ____ 
  | |  / /__  ____  ____/ /__ \ / __ \/ __ \/ __ \
  | | / / _ \/ __ \/ __  /__/ // / / / / / / / / /
  | |/ /  __/ / / / /_/ // __// /_/ / /_/ / /_/ / 
  |___/\___/_/ /_/\__,_//____/\____/\____/\____/  
          ";

        public Vend2000(ICoinValidator coinValidator, IGumDispenser gumDispenser, ICoinStorage coinStorage)
        {
            this.coinValidator = coinValidator;
            this.gumDispenser = gumDispenser;
            this.coinStorage = coinStorage;
        }

        public void Run() {

            Log(logo);

            if (ModulesAreMissing())
            {
                LineFeed();
                Separator();
                Log("Please install missing modules.");
                Separator();
                return;
            }

            Log("=== Welcome to the Vend2000 gum dispenser ===");

            while (true)
            {
                LineFeed();
                Separator();
                Log("Please enter one GOLD coin:");
                Separator();

                Log("1. GOLD   coin");
                Log("2. SILVER coin");
                Log("3. BRONZE coin");

                var input = ReadKey();

                if (input == "\u001b") 
                {
                    break;
                }

                if (input == "/")
                {
                    EnterMaintenanceMode();
                    ClearScreen();
                    continue;
                }

                var coin = GenerateCoin(input);
                if (coin is null)
                {
                    continue;
                }

                var coinValidatorResult = coinValidator.Validate(coin, CoinType.Gold);
                if (coinValidatorResult.IsFail)
                {
                    Log(coinValidatorResult.Message);
                    ReturnCoin();
                    continue;
                }

                var gumDispenserResult = gumDispenser.Dispense();
                if (gumDispenserResult.IsFail)
                {
                    Log(gumDispenserResult.Message);
                    ReturnCoin();
                    continue;
                }

                coinStorage.Add(coin);

                var gumPacket = gumDispenserResult.Data;
                DispenseGum(gumPacket);

                Separator();
            }
        }

        private void DispenseGum(GumPacket gumPacket)
        {
            Log("Gum packet dispensed");
        }

        private void ReturnCoin()
        {
            Log("Coin returned");
        }

        private void EnterMaintenanceMode()
        {
            ClearScreen();
            Heading("Maintenance Mode");

            while (true)
            {
                Log("Enter Password or E to Exit:");
                var password = ReadPassword('*');

                if (password.ToLower() == "e")
                {
                    return;
                }

                if (password?.Trim() == "123")
                {
                    Log("Password accepted");
                    LineFeed();

                    break;
                }

                Log("Password incorrect");
                LineFeed();
            }
            
            while (true)
            {
                Log("1. Load Gum packet");
                Log("2. Dispense Gum packet");
                Log("3. Empty coin storage");
                Log("4. Exit Maintenance Mode");

                var input = ReadNumberedInput();

                if (input == 4)
                {
                    break;
                }

                switch (input)
                {
                    case 1: gumDispenser.Load(new GumPacket());
                        break; 
                    case 2: gumDispenser.Dispense();
                        break; 
                    case 3: coinStorage.Empty();
                        break; 
                }
            }
        }
        
        
        public static string ReadPassword(char mask)
        {
            const int ENTER = 13, BACKSP = 8, CTRLBACKSP = 127;
            int[] FILTERED = { 0, 27, 9, 10 /*, 32 space, if you care */ }; // const

            var pass = new Stack<char>();
            char chr = (char)0;

            while ((chr = System.Console.ReadKey(true).KeyChar) != ENTER)
            {
                if (chr == BACKSP)
                {
                    if (pass.Count > 0)
                    {
                        System.Console.Write("\b \b");
                        pass.Pop();
                    }
                }
                else if (chr == CTRLBACKSP)
                {
                    while (pass.Count > 0)
                    {
                        System.Console.Write("\b \b");
                        pass.Pop();
                    }
                }
                else if (FILTERED.Count(x => chr == x) > 0) { }
                else
                {
                    pass.Push((char)chr);
                    System.Console.Write(mask);
                }
            }

            System.Console.WriteLine();

            return new string(pass.Reverse().ToArray());
        }

    private ICoin GenerateCoin(string input)
    {
        var key = ReadNumberedInput(input);

            switch (key)
            {
                case 1: return new GoldCoin();
                case 2: return new SilverCoin();
                case 3: return new BronzeCoin();
            }

            return null;
        }

        private bool ModulesAreMissing()
        {
            if (coinValidator == null)
            {
                Log("Coin Validator module is not installed", true);
            }

            if (gumDispenser == null)
            {
                Log("Gum Dispenser module is not installed ", true);
            }

            if (coinStorage == null)
            {
                Log("Coin Storage module is not installed  ", true);
            }

            var modulesAreMissing = coinValidator == null || gumDispenser == null || coinStorage == null;
            return modulesAreMissing;
        }

        #region Helpers

        private void Heading(string heading)
        {
            Separator();
            Log(heading?.ToUpper());
            Separator();
            LineFeed();
        }

        private void Log(string message = "", bool important = false)
        {
            if (important)
            {
                message = $"*** {message} ***";
            }

            Console.WriteLine(message);
        }

        private void LineFeed()
        {
            Console.WriteLine("");
        }

        private void Separator()
        {
            Console.WriteLine("-----------------------------------------------------------------------------------");
        }

        private void ClearScreen()
        {
            Console.Clear();
        }


        private int ReadNumberedInput()
        {
            var input = Console.ReadKey(true);
            return ReadNumberedInput(input.KeyChar.ToString());
        }

        private int ReadNumberedInput(string input)
        {
            int.TryParse(input, out var key);

            return (key < 11) ? key : key - 48;
        }


        private string ReadKey()
        {
            var input = Console.ReadKey(true);
            return input.KeyChar.ToString();
        }

        #endregion
    }
}
