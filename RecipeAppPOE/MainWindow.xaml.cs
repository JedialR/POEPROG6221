using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace RecipeAppPOE
{
    public partial class MainWindow : Window
    {
        // Properties to hold the list of recipes and food groups
        public List<Recipe> Recipes { get; set; }
        public List<string> FoodGroups { get; set; }
        public string SelectedFoodGroup { get; set; }

        // Constructor initializes the main window and its components
        public MainWindow()
        {
            InitializeComponent();

            // Initialize the lists
            Recipes = new List<Recipe>();
            FoodGroups = new List<string> { "Carbohydrates", "Protein", "Dairy", "Fruit and vegetables", "Fats and sugars" };

            DataContext = this; // Setting DataContext

            RecipeDataGrid.ItemsSource = Recipes;
            FoodGroupComboBox.ItemsSource = FoodGroups;
        }

        // Event handler for adding a new recipe
        private void AddNewRecipe_Click(object sender, RoutedEventArgs e)
        {
            var addRecipeWindow = new AddRecipeWindow(Recipes, FoodGroups);
            addRecipeWindow.ShowDialog();
            RecipeDataGrid.Items.Refresh();
        }

        // Event handler for exiting the application
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        // Event handler for filtering recipes
        private void FilterRecipes_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Get the filter text, selected food group, and max calories
                string filterText = FilterTextBox.Text.ToLower();
                string selectedFoodGroup = FoodGroupComboBox.SelectedItem?.ToString();
                int maxCalories;
                int.TryParse(MaxCaloriesTextBox.Text, out maxCalories);

                // Filter the recipes based on the criteria
                var filteredRecipes = Recipes.Where(r =>
                    (string.IsNullOrEmpty(filterText) || r.Ingredients.Any(i => i.Name.ToLower().Contains(filterText) || i.FoodGroup.ToLower().Contains(filterText))) &&
                    (string.IsNullOrEmpty(selectedFoodGroup) || r.Ingredients.Any(i => i.FoodGroup == selectedFoodGroup)) &&
                    (maxCalories == 0 || r.TotalCalories <= maxCalories)).ToList();

                RecipeDataGrid.ItemsSource = filteredRecipes;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error filtering recipes: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Event handler for resetting filters
        private void ResetFilters_Click(object sender, RoutedEventArgs e)
        {
            FilterTextBox.Clear();
            FoodGroupComboBox.SelectedIndex = -1;
            MaxCaloriesTextBox.Clear();
            RecipeDataGrid.ItemsSource = Recipes;
        }

        // Event handler for scaling a recipe
        private void ScaleRecipe_Click(object sender, RoutedEventArgs e)
        {
            if (RecipeDataGrid.SelectedItem != null)
            {
                var selectedRecipe = RecipeDataGrid.SelectedItem as Recipe;
                var scaleRecipeWindow = new ScaleRecipeWindow(selectedRecipe);
                scaleRecipeWindow.ShowDialog();
                RecipeDataGrid.Items.Refresh();
            }
        }

        // Event handler for editing a recipe
        private void EditRecipe_Click(object sender, RoutedEventArgs e)
        {
            if (RecipeDataGrid.SelectedItem != null)
            {
                var selectedRecipe = RecipeDataGrid.SelectedItem as Recipe;
                var editRecipeWindow = new EditRecipeWindow(selectedRecipe, FoodGroups);
                editRecipeWindow.ShowDialog();
                RecipeDataGrid.Items.Refresh();
            }
        }

        // Event handler for loading the FoodGroupComboBox
        private void FoodGroupComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            if (FoodGroupComboBox.SelectedItem == null)
            {
                FoodGroupComboBox.Text = "Select food group";
            }
        }

        // Event handler for changing the selection in the FoodGroupComboBox

        private void FoodGroupComboBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            // Handle selection changed event here
        }
    }
}
