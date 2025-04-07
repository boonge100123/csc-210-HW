# Reading Tracker Console App

This is a program that has three main capabilities.

---

## 1. Personal Library Manager

The first capability is that it will allow you to create a personal library of books. The intention was to give users a way to:

- Keep track of the books they own
- See the total cost of their collection
- View how many books they have

---

## 2. Reading Goal Tracker

The second capability lets you set reading or listening goals.

When creating a goal, you will be asked:

1. What type of goal you want:
   - Daily
   - Weekly
   - Monthly
   - Yearly

2. What unit you want to track:
   - Pages
   - Chapters
   - Books
   - Hours

You’ll then enter a target amount, like:
- “I want to read 100 pages today.”
- “I want to finish 10 books this year.”

Goals can be updated later, and the system will show percentage progress (e.g., 10/20 pages = 50%).

---

## 3. Wishlist Manager

The third functionality is a wishlist manager. This works similarly to the personal library manager, but instead of books you own, it tracks books you would like to buy and their prices.

You can also transfer a book from your wishlist directly into your library once it’s been purchased.

---

## Data Persistence

The program uses JSON files to save and load data. Because of this, some fields are marked `public` so that the JSON serializer can access them. That said, private and protected fields are still used where appropriate to meet encapsulation requirements.

Files used:
- `personal_library.json` – stores books in your library
- `wishlist.json` – stores books in your wishlist
- `goals.json` – stores reading goals

All data is saved and loaded automatically. You don’t have to manage the files manually unless you want to back them up or reset them.

---

## How to Use

- This is a console-based C# program.
- When you run it, you'll see a main menu with numbered options.
- Type the number and press Enter to choose an option.
- Submenus will walk you through each action (like adding a book or creating a goal).

---

## Notes

- I’ve included basic error handling for invalid input, but if you run into bugs or crashes, feel free to report them.
- The program structure was designed with object-oriented principles like encapsulation and abstraction in mind, while also being JSON-compatible.

---
