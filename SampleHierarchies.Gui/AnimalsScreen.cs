using SampleHierarchies.Data;
using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Services;
using SampleHierarchies.Services;
using SampleHierarchies.Services.Tests;

namespace SampleHierarchies.Gui;

/// <summary>
/// Animals main screen.
/// </summary>
public sealed class AnimalsScreen : Screen
{
    #region Properties And Ctor

    /// <summary>
    /// Data service.
    /// </summary>
    private IDataService _dataService;

    /// <summary>
    /// Settings service.
    /// </summary>
    private ISettingsService _settingsService;

    /// <summary>
    /// Animals screen.
    /// </summary>
    private MammalsScreen _mammalsScreen;

    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="dataService">Data service reference</param>
    /// <param name="settingsService">Data service reference</param>
    /// <param name="mammalsScreen">Animals screen</param>
    public AnimalsScreen(
        IDataService dataService,
        ISettingsService settingsService,
        MammalsScreen mammalsScreen)
    {
        _dataService = dataService;
        _settingsService = settingsService;
        _mammalsScreen = mammalsScreen;
    }

    public new string ScreenDefinitionJson = "AnimalsScreenDefinition.Json";

    #endregion Properties And Ctor

    #region Public Methods

    /// <inheritdoc/>
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

                AnimalsScreenChoices choice = (AnimalsScreenChoices)Int32.Parse(choiceAsString);
                switch (choice)
                {
                    case AnimalsScreenChoices.Mammals:
                        _mammalsScreen.Show();
                        break;

                    case AnimalsScreenChoices.Read:
                        ReadFromFile();
                        break;

                    case AnimalsScreenChoices.Save:
                        SaveToFile();
                        break;

                    case AnimalsScreenChoices.Exit:
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

    #endregion // Public Methods

    #region Private Methods

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
            _dataService.Write(fileName);
            Console.WriteLine("Data saving to: '{0}' was successful.", fileName);
        }
        catch
        {
            Console.WriteLine("Data saving was not successful.");
        }
    }

    /// <summary>
    /// Read data from file.
    /// </summary>
    private void ReadFromFile()
    {
        try
        {
            Console.Write("Read data from file: ");
            var fileName = Console.ReadLine();
            if (fileName is null)
            {
                throw new ArgumentNullException(nameof(fileName));
            }
            _dataService.Read(fileName);
            Console.WriteLine("Data reading from: '{0}' was successful.", fileName);
        }
        catch
        {
            Console.WriteLine("Data reading from was not successful.");
        }
    }

    #endregion // Private Methods
}
