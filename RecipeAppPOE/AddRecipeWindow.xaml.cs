using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace RecipeAppPOE
{
    public partial class AddRecipeWindow : Window
    {
        private List<Recipe> recipes; // List to hold the existing recipes
        private List<string> foodGroups; // List to hold the available food groups
        private List<Ingredient> temporaryIngredients; // Temporary list to hold ingredients being added

        // Constructor initializes the AddRecipeWindow with the provided recipes and food groups
        public AddRecipeWindow(List<Recipe> recipes, List<string> foodGroups)
        {
            InitializeComponent();
            this.recipes = recipes;
            this.foodGroups = foodGroups;
            temporaryIngredients = new List<Ingredient>();

            IngredientsDataGrid.ItemsSource = temporaryIngredients;
            IngredientFoodGroupComboBox.ItemsSource = foodGroups; // Set the ComboBox ItemsSource
        }

        // Event handler for adding an ingredient
        private void AddIngredientButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Create a new Ingredient object from the input fields
                var ingredient = new Ingredient(
                    IngredientNameTextBox.Text,
                    double.Parse(IngredientQuantityTextBox.Text),
                    IngredientUnitTextBox.Text,
                    int.Parse(IngredientCaloriesTextBox.Text),
                    IngredientFoodGroupComboBox.SelectedItem.ToString());

                temporaryIngredients.Add(ingredient);
                IngredientsDataGrid.Items.Refresh();
                ClearIngredientInputs();
            }
            catch
            {
                MessageBox.Show("Please enter valid ingredient details.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Event handler for adding a new recipe
        private void AddRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            var recipe = new Recipe
            {
                Name = RecipeNameTextBox.Text,
                Ingredients = new List<Ingredient>(temporaryIngredients),
                Steps = StepsTextBox.Text.Split('\n').ToList()
            };

            recipes.Add(recipe);
            Close();
        }

        // Method to clear the input fields for ingredient details
        private void ClearIngredientInputs()
        {
            IngredientNameTextBox.Clear();
            IngredientQuantityTextBox.Clear();
            IngredientUnitTextBox.Clear();
            IngredientCaloriesTextBox.Clear();
            IngredientFoodGroupComboBox.SelectedIndex = -1; // Clear the ComboBox selection
        }
    }
}

