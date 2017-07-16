INSERT INTO Recipe (Name,PrepTime,Instructions)
 VALUES('Chocolate Cake', '45 Minutes', 'Add eggs, flour, chocolate to pan. Bake at 350 for 1 hour');

delete from  Recipe
where Id='7';
truncate table RecipeIngredient;

delete from Ingredient
where Id>1 and Id<18;

 INSERT INTO Recipe (Name,PrepTime,Instructions)
 VALUES('Chicken Biryani', '60 Minutes', 'Beat the plain yogurt well. Marinate chicken with the plain yogurt , ginger paste, garlic paste, turmeric powder, coriander powder, cumin powder, chilli powders, and salt. Let it marinate for about one hour.
Meanwhile, slice onions very thin, and deep fry in oil mixed with ¼ cup of clarified butter or cooking oil until crisp. Clean and wash the rice, drain, and set aside.
Clean and chop the mint leaves and coriander leaves. In the same oil, fry the chopped cashew nuts and raisins until golden brown, drain and set aside. Slit green chillies, and mix into the marinated chicken. Put chicken and marinade into a kadai or pot in which the onions and cashew nuts were fried. Add a little water, cover and cook until the chicken is half done. Remove the chicken pieces with a slotted spoon and measure the stock. Add enough water to make it six cups.
Put the rice into a rice cooker, add the whole spices, arrange the chicken pieces on top, sprinkle three-quarters of the fried onions and all the chopped coriander/cilantro and mint leaves. Pour in the measured stock into which the garam masala powder has been added. Pour the remaining quarter cup of clarified butter or oil over the whole mixture. Cover and cook until well done.
Meanwhile, hard-boil and shell the eggs. Soak the saffron in milk (if using it). When the biryani is done, open the rice cooker, and sprinkle the saffron-soaked milk on top. Mix carefully and cover and leave on very low heat for a few minutes.
Just before serving, mix in the juice of half a lime or lemon. Arrange on a serving dish and garnish with the remaining fried onions, cashew nuts, raisins, and boiled eggs.');

INSERT INTO Ingredient (name) VALUES('Chicken'), ('Rice'), ('Green Chillies'), ('Shan Biryani Masala'), ('Oil'), ('Lemon Juice');

INSERT INTO RecipeIngredient (RecipeId,IngredientId)  VALUES (7,11);
INSERT INTO RecipeIngredient (RecipeId,IngredientId)  VALUES (7,12);
INSERT INTO RecipeIngredient (RecipeId,IngredientId)  VALUES (7,13);
INSERT INTO RecipeIngredient (RecipeId,IngredientId)  VALUES (7,14);
INSERT INTO RecipeIngredient (RecipeId,IngredientId)  VALUES (7,15);
INSERT INTO RecipeIngredient (RecipeId,IngredientId)  VALUES (7,16);

select * from Ingredient;
select * from Recipe;
select * from RecipeIngredient;

SELECT  r.Name AS ' Recipe Name' ,
	r.PrepTime AS 'Prep Time',
	r.Instructions AS 'Instructions'
	FROM Recipe r 
 JOIN  RecipeIngredient ri on r.Id=ri.RecipeId
 JOIN Ingredient i on i.Id=ri.IngredientId;