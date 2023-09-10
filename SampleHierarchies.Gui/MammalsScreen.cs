using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Services;
using SampleHierarchies.Services.Tests;

namespace SampleHierarchies.Gui;

/// <summary>
/// Mammals main screen.
/// </summary>
public sealed class MammalsScreen : Screen
{
    #region Properties And Ctor

    /// <summary>
    /// Animals screen.
    /// </summary>
    private DogsScreen _dogsScreen;

    /// <summary>
    /// Animals screen.
    /// </summary>
    private BearsScreen _bearsScreen;  // KeDi

    /// <summary>
    /// Animals screen.
    /// </summary>
    private LionsScreen _lionsScreen;  // KeDi

    /// <summary>
    /// Animals screen.
    /// </summary>
    private WolvesScreen _wolvesScreen;  // KeDi

    /// <summary>
    /// Settings service.
    /// </summary>
    private ISettingsService _settingsService; //KeDi

    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="dataService">Data service reference</param>
    /// <param name="dogsScreen">Dogs screen</param>
    /// <param name="bearsScreen">Bears screen</param>  // KeDi
    /// <param name="lionsScreen">Lions screen</param>  // KeDi
    /// <param name="wolvesScreen">Lions screen</param>  // KeDi
    /// <param name="settingsService">Data service reference</param>  // KeDi

    public MammalsScreen(DogsScreen dogsScreen, BearsScreen bearsScreen,
        WolvesScreen wolvesScreen, LionsScreen lionsScreen, ISettingsService settingsService) // KeDi
    {
        _dogsScreen = dogsScreen;
        _bearsScreen = bearsScreen;  // KeDi
        _lionsScreen = lionsScreen;  // KeDi
        _wolvesScreen = wolvesScreen;  // KeDi
        _settingsService = settingsService; //KeDi
    }

    public new string ScreenDefinitionJson = "MammalsScreenDefinition.Json";

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

                MammalsScreenChoices choice = (MammalsScreenChoices)Int32.Parse(choiceAsString);
                switch (choice)
                {
                    case MammalsScreenChoices.Dogs:
                        _dogsScreen.Show();
                        break;

                    // KeDi
                    case MammalsScreenChoices.Bears:
                        _bearsScreen.Show();
                        break;

                    case MammalsScreenChoices.Lions:
                        _lionsScreen.Show();
                        break;

                    case MammalsScreenChoices.Wolves:
                        _wolvesScreen.Show();
                        break;
                    // KeDi

                    case MammalsScreenChoices.Exit:
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
}
