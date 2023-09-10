using SampleHierarchies.Data;
using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Services;
using SampleHierarchies.Services;
using SampleHierarchies.Services.Tests;

namespace SampleHierarchies.Gui;

/// <summary>
/// Application main screen.
/// </summary>
public sealed class MainScreen : Screen
{
    #region Properties And Ctor

    /// <summary>
    /// Data service.
    /// </summary>
    private IDataService _dataService;

    /// <summary>
    /// Animals screen.
    /// </summary>
    private AnimalsScreen _animalsScreen;

    /// <summary>
    /// Colors screen.
    /// </summary>
    //private ColorScreen _colorScreen;

    /// <summary>
    /// Setings service.
    /// </summary>
    private ISettingsService _settingsService;

    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="dataService">Data service reference</param>
    /// <param name="animalsScreen">Animals screen</param>
    /// <param name="colorScreen">Colors screen</param>
    /// <param name="settingsService">Data service screen</param>

    public MainScreen(
        IDataService dataService,
        AnimalsScreen animalsScreen,
        //ColorScreen colorScreen,
        ISettingsService settingsService)

    {
        _dataService = dataService;
        _animalsScreen = animalsScreen;
        //_colorScreen = colorScreen;
        _settingsService = settingsService;
    }

    public new string ScreenDefinitionJson = "MainScreenDefinition.json";

    #endregion Properties And Ctor

    #region Public Methods

    /// <inheritdoc/>
    public override void Show()
    {
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

                MainScreenChoices choice = (MainScreenChoices)Int32.Parse(choiceAsString);
                switch (choice)
                {
                    case MainScreenChoices.Animals:
                        _animalsScreen.Show();
                        break;

                    /*case MainScreenChoices.Settings:
                        _colorScreen.Show();        
                        break;
                    */
                    case MainScreenChoices.Exit:
                        Console.WriteLine("Goodbye.");
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

    #region Private methods

    #endregion //Private methods
}