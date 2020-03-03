using CaWorkshop.WebUI.Models;
using System.Collections.Generic;
using System.Linq;

namespace CaWorkshop.WebUI.Data
{
    public static class ApplicationDbContextSeeder
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (context.TodoLists.Any())
            {
                return;
            }

            var list = new TodoList
            {
                Title = "Death List Five"
            };

            list.Items.Add(new TodoItem
            {
                Title = "O-Ren Ishii",
                Done = true
            });

            list.Items.Add(
                        new TodoItem
                        {
                            Title = "Vernita Green",
                            Done = true
                        });

            list.Items.Add(
                        new TodoItem
                        {
                            Title = "Budd",
                            Done = true
                        });

            list.Items.Add(
                        new TodoItem
                        {
                            Title = "Ellie Driver"
                        }
                        );

            list.Items.Add(new TodoItem
            {
                Title = "Bill"
            });

            context.TodoLists.Add(list);

            context.SaveChanges();
        }
    }
}