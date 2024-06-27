using System.Collections.Generic;
using System.Windows;

namespace RecipeAppPOE
{
    public partial class ScaleRecipeWindow : Window
    {
        private Recipe recipe; // The recipe to be scaled
        private List<Ingredient> originalIngredients; // List to store the original ingredient quantities

        // Constructor initializes the ScaleRecipeWindow with the provided recipe
        public ScaleRecipeWindow(Recipe recipe)
        {
            InitializeComponent();

            this.recipe = recipe;
            originalIngredients = new List<Ingredient>();

            foreach (var ingredient in recipe.Ingredients)
            {
                originalIngredients.Add(new Ingredient(ingredient.Name, ingredient.Quantity, ingredient.Unit, ingredient.Calories, ingredient.FoodGroup));
            }

            IngredientsListBox.ItemsSource = recipe.Ingredients;
        }

        // Event handler for scaling the recipe ingredients
        private void Scale_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(ScaleFactorTextBox.Text, out double scaleFactor))
            {
                foreach (var ingredient in recipe.Ingredients)
                {
                    ingredient.Scale(scaleFactor);
                }

                IngredientsListBox.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Please enter a valid scale factor.", "Invalid Scale Factor", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Event handler for resetting the recipe ingredients to their original quantities
        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            // Reset each ingredient in the recipe to its original quantity
            foreach (var ingredient in recipe.Ingredients)
            {
                ingredient.Reset();
            }

            // Refresh the ListBox to display the original ingredient quantities
            IngredientsListBox.Items.Refresh();
        }
    }
}
