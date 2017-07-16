using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace CookBook
{
    public partial class frmMain : Form
    {
        SqlConnection connection;
        string connectionstring;
        public frmMain()
        {
            InitializeComponent();
            connectionstring = ConfigurationManager.ConnectionStrings["CookBook.Properties.Settings.CookBookConnectionString"].ConnectionString;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            PopulateRecipe();
            PopulateAllIngredients();
          
        }

        private void PopulateRecipe()
        {// using statement opens the connection no need to close
            // but sqldataapter no need to even open it does that for you
           
           using ( connection = new SqlConnection(connectionstring))
           using (SqlDataAdapter adapter=new SqlDataAdapter("SELECT * FROM Recipe",connection))
           { 
               DataTable recipeTable = new DataTable();
               adapter.Fill(recipeTable);
               
               //listRecipes.DisplayMember = "Name";
               //listRecipes.DisplayMember = "PrepTime";
              // listRecipes.Items.Add(recipeTable.Rows[0][0].ToString());
               
               listRecipes.ValueMember = "Id";
               listRecipes.DataSource = recipeTable;
              listRecipes.DisplayMember = "Name";
              
           }
       
        }
        private void PopulateAllIngredients()
        {// using statement opens the connection no need to close
            // but sqldataapter no need to even open it does that for you

            using (connection = new SqlConnection(connectionstring))
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Ingredient", connection))
            {
                DataTable ingredientTable = new DataTable();
                adapter.Fill(ingredientTable);
                listAllIngredients.DisplayMember = "Name";
                listAllIngredients.ValueMember = "Id";
                listAllIngredients.DataSource = ingredientTable;

            }

        }

        private void PopulateIngredients()
        {// using statement opens the connection no need to close
            // but sqldataapter no need to even open it does that for you
            string query= @"select a.Name from Ingredient a 
                            inner join RecipeIngredient b on a.id=b.IngredientId
                            where b.RecipeId=@RecipeId";
            using (connection = new SqlConnection(connectionstring))
            using (SqlCommand command=new SqlCommand (query,connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                command.Parameters.AddWithValue("@RecipeId", listRecipes.SelectedValue);

                DataTable ingredientTable = new DataTable();
                adapter.Fill(ingredientTable);

                listIngredients.DisplayMember = "Name";
                listIngredients.ValueMember = "Id";
                listIngredients.DataSource = ingredientTable;

            }


        }

        private void listRecipes_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(listRecipes.SelectedValue.ToString());
            PopulateIngredients();
            
         
            
        }

        private void btnaddrecipe_Click(object sender, EventArgs e)
        {
            string query = @" INSERT INTO Recipe 
                            VALUES (@RecipeName,80,'Add salt and sugar too')";
            using (connection = new SqlConnection(connectionstring))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@RecipeName", txtRecipeName.Text);

                command.ExecuteNonQuery();

            }

            PopulateRecipe();

        }

        private void btnUpdateRecipeName_Click(object sender, EventArgs e)
        {

            string query = @" UPDATE Recipe SET Name = @RecipeName
                               WHERE Id=@RecipeId ";
            using (connection = new SqlConnection(connectionstring))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@RecipeName", txtRecipeName.Text);
                command.Parameters.AddWithValue("@RecipeId", listRecipes.SelectedValue);

                command.ExecuteNonQuery();

            }

            PopulateRecipe();

        }

        private void btnAddToRecipe_Click(object sender, EventArgs e)
        {
            string query = @" INSERT INTO RecipeIngredient 
                            VALUES (@RecipeId,@IngredientId)";
            using (connection = new SqlConnection(connectionstring))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@RecipeId", listRecipes.SelectedValue);
                command.Parameters.AddWithValue("@IngredientId", listAllIngredients.SelectedValue);

                command.ExecuteNonQuery();

            }

            PopulateRecipe();
        }
    }
}
