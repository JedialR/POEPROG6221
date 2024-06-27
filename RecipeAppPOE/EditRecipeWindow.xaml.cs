using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace RecipeAppPOE
{
    public partial class EditRecipeWindow : Window
    {
        private Recipe recipe; // The recipe being edited
        private List<string> foodGroups; // List of food groups
        private List<Ingredient> temporaryIngredients; // Temporary list of ingredients for editing

        // Constructor initializes the EditRecipeWindow with the provided recipe and food groups
        public EditRecipeWindow(Recipe recipe, List<string> foodGroups)
        {
            InitializeComponent();

            this.recipe = recipe;
            this.foodGroups = foodGroups;
            temporaryIngredients = new List<Ingredient>(recipe.Ingredients);

            RecipeNameTextBox.Text = recipe.Name;
            StepsTextBox.Text = string.Join("\n", recipe.Steps);

            IngredientsDataGrid.ItemsSource = temporaryIngredients;
            IngredientFoodGroupComboBox.ItemsSource = foodGroups;
        }

        // Event handler for adding an ingredient
        private void AddIngredientButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
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

        // Event handler for removing an ingredient
        private void RemoveIngredientButton_Click(object sender, RoutedEventArgs e)
        {
            var ingredient = (sender as Button).DataContext as Ingredient;
            temporaryIngredients.Remove(ingredient);
            IngredientsDataGrid.Items.Refresh();
        }

        // Event handler for saving the changes to the recipe
        private void SaveChangesButton_Click(object sender, RoutedEventArgs e)
        {
            recipe.Name = RecipeNameTextBox.Text;
            recipe.Ingredients = new List<Ingredient>(temporaryIngredients);
            recipe.Steps = StepsTextBox.Text.Split('\n').ToList();

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

