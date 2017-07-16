select * from Recipe

select * from Ingredient

select * from RecipeIngredient

select a.Name from Ingredient a 
inner join RecipeIngredient b on a.id=b.IngredientId
where b.RecipeId=1

update Recipe 
SET Name= 'Classic Salad'
where Id=6;

delete from Recipe 
where Id=7;

insert into Recipe 
values ('4','Classic Salad','15','Adding sugar and salt too :P');