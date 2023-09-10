using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Services;
using SampleHierarchies.Data;
using SampleHierarchies.Services;
using SampleHierarchies.Data.Mammals;
using SampleHierarchies.Interfaces.Data.Mammals;
using SampleHierarchies.Services.Tests;

namespace SampleHierarchies.Gui

{
    public sealed class ColorScreen : Screen
    {
        #region Properties And Ctor
        /// <summary>
        /// Setting service.
        /// </summary>
        public ISettingsService _settingsService;

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="settingsService">Data service reference</param>
        public ColorScreen(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        public new string ScreenDefinitionJson = "ColorScreenDefinition.Json";

        #endregion //Properties And Ctor

        #region Public methods
        public override void Show()
        {
            Console.Clear();

            while (true)
            {
                ScreenDefinionService.Load(ScreenDefinitionJson);

                string? choiceAsString = Console.ReadLine();

                // Validate choice
                try
                {
                    if (choiceAsString is null)
                    {
                        throw new ArgumentNullException(nameof(choiceAsString));
                    }

                    ColorScreenChoices choice = (ColorScreenChoices)Int32.Parse(choiceAsString);
                    switch (choice)
                    {
                        case ColorScreenChoices.Main:
                            AddSettings(ColorScreenChoices.Main);
                            break;
                        case ColorScreenChoices.Animals:
                            AddSettings(ColorScreenChoices.Animals);
                            break;
                        case ColorScreenChoices.Mammals:
                            AddSettings(ColorScreenChoices.Mammals);
                            break;
                        case ColorScreenChoices.Dogs:
                            AddSettings(ColorScreenChoices.Dogs);
                            break;
                        case ColorScreenChoices.List_Colors:
                            List_Colors();
                            break;
                        case ColorScreenChoices.Read:
                            ReadFromFile();
                            break;

                        case ColorScreenChoices.Save:
                            SaveToFile();
                            break;

                        case ColorScreenChoices.Exit:
                            Console.Clear();
                            return;
                    }
                }
                catch
                {
                    Console.WriteLine("Invalid choice. Try again.");
                }
            }
        }

        public void AddSettings(ColorScreenChoices screenNum)
        {
            try
            {
                Settings settings = AddEditSettings(screenNum);
                _settingsService?.Settings?.Setting.RemoveAll(x => x.ScreenNumber == settings.ScreenNumber);
                _settingsService?.Settings?.Setting.Add(settings);
            }
            catch
            {
                Console.WriteLine("Invalid input.");
            }
        }

        public Settings AddEditSettings(ColorScreenChoices screenNum)
        {
            Console.Write("0 - "); Console.Write(ConsoleColor.Black);
            Console.Write(", 1 - "); Console.Write(ConsoleColor.DarkBlue);
            Console.Write(", 2 - "); Console.Write(ConsoleColor.DarkGreen);
            Console.Write(", 3 - "); Console.WriteLine(ConsoleColor.DarkCyan);
            Console.Write("4 - "); Console.Write(ConsoleColor.DarkRed);
            Console.Write(", 5 - "); Console.Write(ConsoleColor.DarkMagenta);
            Console.Write(", 6 - "); Console.Write(ConsoleColor.DarkYellow);
            Console.Write(", 7 - "); Console.WriteLine(ConsoleColor.Gray);
            Console.Write("8 - "); Console.Write(ConsoleColor.DarkGray);
            Console.Write(", 9 - "); Console.Write(ConsoleColor.Blue);
            Console.Write(", 10 - "); Console.Write(ConsoleColor.Green);
            Console.Write(", 11 - "); Console.WriteLine(ConsoleColor.Cyan);
            Console.Write("12 - "); Console.Write(ConsoleColor.Red);
            Console.Write(", 13 - "); Console.Write(ConsoleColor.Magenta);
            Console.Write(", 14 - "); Console.Write(ConsoleColor.Yellow);
            Console.Write(", 15 - "); Console.WriteLine(ConsoleColor.White);
            Console.Write("Assign the Foreground color of the {0} screen (0-15):", screenNum);
            string? text = Console.ReadLine();
            Console.Write("Assign the Background color of the {0} screen (0-15):", screenNum);
            string? background = Console.ReadLine();


            if (text is null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            if (background is null)
            {
                throw new ArgumentNullException(nameof(background));
            }

            Settings curSetting = new Settings(
                System.Convert.ToInt16(screenNum),
                (ConsoleColor)Enum.Parse(typeof(ConsoleColor), text, true),
                (ConsoleColor)Enum.Parse(typeof(ConsoleColor), background, true)
                );

            return curSetting;
        }

        #endregion //Public methods

        #region Private methods

        private void List_Colors()
        {
            Console.WriteLine();
            if (_settingsService?.Settings?.Setting is not null &&
                _settingsService?.Settings?.Setting.Count > 0)
            {
                Console.WriteLine("Here's a color settings:");
                int i = 0;
                foreach (Settings settings in _settingsService?.Settings?.Setting)
                {
                    settings.Display(settings.ScreenNumber);
                    i++;
                }
            }
            else
            {
                Console.WriteLine("The list of color settings is empty");
            }
        }

        /// <summary>
        /// Save to file.
        /// </summary>
        private void SaveToFile()
        {
            try
            {
                Console.Write("Save data to file: ");
                var fileName = Console.ReadLine();
                if (fileName is null)
                {
                    throw new ArgumentNullException(nameof(fileName));
                }
                _settingsService.Write(fileName);
                Console.WriteLine("Settings saving to: '{0}' was successful.", fileName);
            }
            catch
            {
                Console.WriteLine("Settings saving was not successful.");
            }
        }

        /// <summary>
        /// Read settings from file.
        /// </summary>
        private void ReadFromFile()
        {
            try
            {
                Console.Write("Read settings from file: ");
                var fileName = Console.ReadLine();
                if (fileName is null)
                {
                    throw new ArgumentNullException(nameof(fileName));
                }
                _settingsService.Read(fileName);
                Console.WriteLine("Settings reading from: '{0}' was successful.", fileName);
            }
            catch
            {
                Console.WriteLine("Settings reading from was not successful.");
            }
        }

        #endregion //Private methods
    }
}

