select * from Recipe

select * from Ingredient

select * from RecipeIngredient

select a.Name from Ingredient a 
inner join RecipeIngredient b on a.id=b.IngredientId
where b.RecipeId=1