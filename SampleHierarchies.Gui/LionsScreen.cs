﻿// KeDi

using SampleHierarchies.Data.Mammals;
using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Services;
using SampleHierarchies.Services.Tests;

namespace SampleHierarchies.Gui;

/// <summary>
/// Mammals main screen.
/// </summary>
public sealed class LionsScreen : Screen
{
    #region Properties And Ctor

    /// <summary>
    /// Data service.
    /// </summary>
    public IDataService _dataService;

    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="dataService">Data service reference</param>
    public LionsScreen(IDataService dataService)
    {
        _dataService = dataService;
    }

    public new string ScreenDefinitionJson = "LionsScreenDefinition.Json";

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

                LionsScreenChoices choice = (LionsScreenChoices)Int32.Parse(choiceAsString);
                switch (choice)
                {
                    case LionsScreenChoices.List:
                        ListLions();
                        break;

                    case LionsScreenChoices.Create:
                        AddLion(); break;

                    case LionsScreenChoices.Delete:
                        DeleteLion();
                        break;

                    case LionsScreenChoices.Modify:
                        EditLionMain();
                        break;

                    case LionsScreenChoices.Exit:
                        Console.WriteLine("Going back to previous menu.");
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
    /// List all lions.
    /// </summary>
    private void ListLions()
    {
        Console.WriteLine();
        if (_dataService?.Animals?.Mammals?.Lions is not null &&
            _dataService.Animals.Mammals.Lions.Count > 0)
        {
            Console.WriteLine("Here's a list of Lions:");
            int i = 1;
            foreach (Lion lion in _dataService.Animals.Mammals.Lions)
            {
                Console.Write($"Lion number {i}, ");
                lion.Display();
                i++;
            }
        }
        else
        {
            Console.WriteLine("The list of lions is empty.");
        }
    }

    /// <summary>
    /// Add a lion.
    /// </summary>
    private void AddLion()
    {
        try
        {
            Lion lion = AddEditLion();
            _dataService?.Animals?.Mammals?.Lions?.Add(lion);
            Console.WriteLine("Lion with name: {0} has been added to a list of lions", lion.Name);
        }
        catch
        {
            Console.WriteLine("Invalid input.");
        }
    }

    /// <summary>
    /// Deletes a lion.
    /// </summary>
    private void DeleteLion()
    {
        try
        {
            Console.Write("What is the name of the lion you want to delete? ");
            string? name = Console.ReadLine();
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            Lion? lion = (Lion?)(_dataService?.Animals?.Mammals?.Lions
                ?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
            if (lion is not null)
            {
                _dataService?.Animals?.Mammals?.Lions?.Remove(lion);
                Console.WriteLine("Lion with name: {0} has been deleted from a list of lions", lion.Name);
            }
            else
            {
                Console.WriteLine("Lion not found.");
            }
        }
        catch
        {
            Console.WriteLine("Invalid input.");
        }
    }

    /// <summary>
    /// Edits an existing lion after choice made.
    /// </summary>
    private void EditLionMain()
    {
        try
        {
            Console.Write("What is the name of the lion you want to edit? ");
            string? name = Console.ReadLine();
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            Lion? lion = (Lion?)(_dataService?.Animals?.Mammals?.Lions
                ?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
            if (lion is not null)
            {
                Lion lionEdited = AddEditLion();
                lion.Copy(lionEdited);
                Console.Write("Lion after edit:");
                lion.Display();
            }
            else
            {
                Console.WriteLine("Lion not found.");
            }
        }
        catch
        {
            Console.WriteLine("Invalid input. Try again.");
        }
    }

    /// <summary>
    /// Adds/edit specific lion.
    /// </summary>
    /// <exception cref="ArgumentNullException"></exception>
    private static Lion AddEditLion()
    {
        Console.Write("What name of the lion? ");
        string? name = Console.ReadLine();
        Console.Write("What is the lion's age? ");
        string? ageAsString = Console.ReadLine();
        Console.Write("What is the lion's breed? ");
        string? breed = Console.ReadLine();

        if (name is null)
        {
            throw new ArgumentNullException(nameof(name));
        }
        if (ageAsString is null)
        {
            throw new ArgumentNullException(nameof(ageAsString));
        }
        if (breed is null)
        {
            throw new ArgumentNullException(nameof(breed));
        }
        int age = Int32.Parse(ageAsString);
        Lion lion = new Lion(name, age, breed);

        return lion;
    }

    #endregion // Private Methods
}

// KeDi