# Source:

http://iamnotmyself.com/2011/02/14/refactor-this-the-gilded-rose-kata/

## Objective

Refactor the code following the guidelines set in the next section.
There are no limits or constraints regarding the refactored finished code whatsoever.
The only limitation is that the code must behave as it already does, prior any refactoring.
Focus on the structure of your code following the SRP and the Newspaper analogy.
The application logic should be well encapsulated in a way than later, when you change the application UI, the business core logic does not become affected by this change.

Some questions to help you think over the design
- What part of the code deals with the updates? 
- What part of the code deals with the output?
- Can you render your application as a web page or a win forms?
- If you'd have to add a new feature to remove the Aged Brie from the items list, what part(s) of your application change(s) ?
	- Can you develop this?
- If the update rules change for a material, like either Sulfuras or Backstage Passes, how many parts of yor application change?
- If we need to create files with the output of each run, named: YYYY-MM-DD HH-mm-SS.txt, how many parts of your application change?

## Problem Description:

Hi and welcome to team Gilded Rose. As you know, we are a small inn with a prime location in a
prominent city ran by a friendly innkeeper named Allison. We also buy and sell only the finest goods.
Unfortunately, our goods are constantly degrading in quality as they approach their sell by date. We
have a system in place that updates our inventory for us. It was developed by a no-nonsense type named
Leeroy, who has moved on to new adventures. Your task is to add the new feature to our system so that
we can begin selling a new category of items. First an introduction to our system:

	- All items have a SellIn value which denotes the number of days we have to sell the item
	- All items have a Quality value which denotes how valuable the item is
	- At the end of each day our system lowers both values for every item

Pretty simple, right? Well this is where it gets interesting:

	- Once the sell by date has passed, Quality degrades twice as fast
	- The Quality of an item is never negative
	- "Aged Brie" actually increases in Quality the older it gets
	- The Quality of an item is never more than 50
	- "Sulfuras", being a legendary item, never has to be sold or decreases in Quality
	- "Backstage passes", like aged brie, increases in Quality as its SellIn value approaches;
	Quality increases by 2 when there are 10 days or less and by 3 when there are 5 days or less but
	Quality drops to 0 after the concert

We have recently signed a supplier of conjured items. This requires an update to our system:

	- "Conjured" items degrade in Quality twice as fast as normal items

Feel free to make any changes to the UpdateQuality method and add any new code as long as everything
still works correctly.

Just for clarification, an item can never have its Quality increase above 50, however "Sulfuras" is a
legendary item and as such its Quality is 80 and it never alters.

## Other's Solutions:
Emily Bache's:
https://github.com/emilybache/GildedRose-Refactoring-Kata

## NOTE: look out for branches in this repo to checkout solutions for this