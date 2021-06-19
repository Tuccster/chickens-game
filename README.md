# chickens-game
 An Idle/Inventory Management game based on chickens and eggs.
 
# Premise
 It's been a long time since I worked on this game, but the idea from what I remember was similar to other idle games, like [Cookie Clicker](https://orteil.dashnet.org/cookieclicker/), where you are constantantly trying to get more and more of *something*, in this game's case — eggs and money.

Essentially, your Inventory starts with a single Golden Egg, which when hatched has a 100% chance of hatching a chicken. The chickens will lay normal eggs every so often, which can then be hatched for a chance to get another chicken or sold for money. You could assign jobs to the chickens to have them collect new resources, allowing you to create new items.

# Inventory
The inventory is a grid of slots, each capable of holding a single type of item.

![image](https://user-images.githubusercontent.com/44419210/122652849-e572c100-d0f5-11eb-9eb9-c7a8abdc5034.png)

Double-clicking on an item opens a window, displaying the details and operations available for that item.

![image](https://user-images.githubusercontent.com/44419210/122652920-55814700-d0f6-11eb-820a-bf052dcf7e07.png)

Scriptable Objects were used to easily create new items and specify what options where available for that item's info window.

![image](https://user-images.githubusercontent.com/44419210/122652984-9711f200-d0f6-11eb-9433-95702b8ea696.png)
 
# Items
![egg_golden](https://user-images.githubusercontent.com/44419210/122652558-53b68400-d0f4-11eb-9312-12f3cf4c379d.png) Golden Egg: *100% chance of hatching a chicken.*

![egg](https://user-images.githubusercontent.com/44419210/122652496-194ce700-d0f4-11eb-8e6d-f4c30ea09e5e.png) Egg: *Has a small chance of hatching a chicken.*

![chicken](https://user-images.githubusercontent.com/44419210/122652580-6630bd80-d0f4-11eb-826c-8f55f0671844.png) Chicken: *Periodically lays regular eggs, with a very small chance of laying a Golden Egg.*

![chicken_lumberjack](https://user-images.githubusercontent.com/44419210/122652606-8bbdc700-d0f4-11eb-9a8d-610d45c75f05.png) Chicken (Lumberjack): *Periodically adds wood to the inventory.*

![chicken_miner](https://user-images.githubusercontent.com/44419210/122652634-a728d200-d0f4-11eb-9e3a-265c8e94f7b5.png) Chicken (Miner): *Periodically adds stone to the inventory.*

![chicken_explorer](https://user-images.githubusercontent.com/44419210/122652665-c45da080-d0f4-11eb-91a7-75f4bd6078a6.png) Chicken (Explorer): *Can be sent out on expeditions, which can either lead to the the chicken bringing back a random item, or dying in the process.*

![chicken_builder](https://user-images.githubusercontent.com/44419210/122652715-fa028980-d0f4-11eb-9609-9f1e644aa652.png) Chicken (Builder): *Can be tasked with building new structures. Each builder can only build one thing at a time.*

![wood](https://user-images.githubusercontent.com/44419210/122652741-2a4a2800-d0f5-11eb-9d85-b458aa18f53b.png) Wood: *A basic material used in creating buildings or crafting new items.*

![stone](https://user-images.githubusercontent.com/44419210/122652752-4057e880-d0f5-11eb-8d78-e05c1775f480.png) Stone: *A basic material used in creating buildings or crafting new items.*

![researchcenter](https://user-images.githubusercontent.com/44419210/122652766-5f567a80-d0f5-11eb-8e21-5cbfc5eb7a11.png) Research Center: *Used to discover new items to craft.*

![barn](https://user-images.githubusercontent.com/44419210/122652777-7006f080-d0f5-11eb-9975-b4b52053556c.png) Barn: *Used as additional storage to house more chickens than what the inventory can hold on its own.*









