using Twittter_C_;

User u1 = new User("HSYN2005", "horucov148@gmail.com", "1234");
User u2 = new User("Ali2007", "ali123@gmail.com", "0000");
List<User> users = new List<User>();
users.Add(u1);
users.Add(u2);

Admin admin = new Admin("Cavid1997", "cavidatamoghlanov@gmail.com", "1997");

string[] start_menu = { "Enter as Admin","Enter as User" };
int choice_start_menu = 0;
string[] admin_start_menu = {"Add Post","View Posts","Notifications"};
int choice_admin_start_menu = 0;
void AdminStart()
{
    int currentpost = 0;

    do
    {
        Console.Clear();

        Console.WriteLine();
        for (int i = 0; i < admin_start_menu.Length; i++)
        {
            if (choice_admin_start_menu == i)
            {
                Console.Write("                                                        ");
                Console.Write("-> ");
            }
            else
            {
                Console.Write("                                                        ");
                Console.Write("   ");
            }

            Console.WriteLine(admin_start_menu[i]); ;
        }

        ConsoleKeyInfo choice_admin = Console.ReadKey();

        switch (choice_admin.Key)
        {
            case ConsoleKey.UpArrow:
                if (choice_admin_start_menu == 0)
                    choice_admin_start_menu = 2;
                else
                    --choice_admin_start_menu;
                break;

            case ConsoleKey.DownArrow:
                if (choice_admin_start_menu == 2)
                    choice_admin_start_menu = 0;
                else
                    ++choice_admin_start_menu;
                break;

            case ConsoleKey.Enter:
                Console.Clear();
                if (choice_admin_start_menu == 0)
                {
                    Console.Write("Enter content of the post: ");
                    string? content = Console.ReadLine();
                    Console.Write("Enter text of the post: ");
                    string? text = Console.ReadLine();
                    Post post = new Post(content!, text!);
                    admin.Posts.Add(post);
                    Console.Clear() ;
                    Console.WriteLine("Post successfully added");
                    Console.WriteLine("Press any button for continue...");
                    Console.ReadKey();

                }
                else if(choice_admin_start_menu == 1)
                {
                    Console.Clear();
                    foreach (var item in admin.Posts)
                    {
                        Console.WriteLine($"Post ID: {item.Id}");
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.Write("Write ID of Post to view: ");
                    string? id = Console.ReadLine();
                    bool Check = false;
                    for (int i = 0; i < admin.Posts.Count; i++)
                    {
                        if(id == Convert.ToString(admin.Posts[i].Id))
                        {
                            currentpost = i;
                            Check = true;
                            break;
                        }
                    }
                    if(Check == true)
                    {
                        Console.Clear();
                        Console.WriteLine($"Content: {admin.Posts[currentpost].Content}");
                        Console.WriteLine($"Text: {admin.Posts[currentpost].Text}");
                        Console.WriteLine($"ViewCount: {admin.Posts[currentpost].ViewCount}");
                        Console.WriteLine($"LikeCount: {admin.Posts[currentpost].LikeCount}");
                        admin.Posts[currentpost].ViewCount++;
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.Write("Do you want like this post ? ([y]-> yes/[n]-> no): ");
                        string? choice = Console.ReadLine();
                        if (choice == "y")
                        {
                            admin.Posts[currentpost].LikeCount++;
                            Console.WriteLine("Post successfully liked");
                        }

                        else if (choice == "n")
                        {
                            admin.Posts[currentpost].LikeCount++;
                            Console.WriteLine("OK...");
                        }

                        else
                            Console.WriteLine("Wrong choice!!!");
                        Console.WriteLine("Press any button for continue...");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("There is not any post for this ID");
                        Console.WriteLine("Press any button for continue...");
                        Console.ReadKey();
                    }
                }
                else if(choice_admin_start_menu == 2)
                {
                    Console.Clear();

                    foreach(var item in admin.Notifications)
                    {
                        Console.WriteLine($"Notification ID: {item.Id}");
                        Console.WriteLine($"DateTime: {item.date_time}");
                        Console.WriteLine(item.Text);
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Press any button for continue...");
                    Console.ReadKey();
                }
                break;
        }
        if (choice_admin.Key == ConsoleKey.Escape)
            break;


    } while (true);
}

do
{
    Console.Clear();

    Console.WriteLine();
    for (int i = 0; i < start_menu.Length; i++)
    {
        if (choice_start_menu == i)
        {
            Console.Write("                                                        ");
            Console.Write("-> ");
        }
        else
        {
            Console.Write("                                                        ");
            Console.Write("   ");
        }

        Console.WriteLine(start_menu[i]); ;
    }

    ConsoleKeyInfo choice = Console.ReadKey();

    switch (choice.Key)
    {
        case ConsoleKey.UpArrow:
            if (choice_start_menu == 0)
                choice_start_menu = 1;
            else
                --choice_start_menu;
            break;

        case ConsoleKey.DownArrow:
            if (choice_start_menu == 1)
                choice_start_menu = 0;
            else
                ++choice_start_menu;
            break;

        case ConsoleKey.Enter:
            Console.Clear();
            if (choice_start_menu == 0)
            {
                Console.Write("                                                        ");
                Console.Write("Enter adminname: ");
                string? adminname = Console.ReadLine();
                Console.Write("                                                        ");
                Console.Write("Enter password: ");
                string? password = Console.ReadLine();
                Console.Clear();
                if (adminname == admin.Username && password == admin.Password)
                    AdminStart();

                else
                {
                    Console.Write("                                    ");
                    Console.WriteLine("Bu adminname ve ya passworda uygun admin yoxdur!!!");
                    Console.WriteLine("Press any button for continue...");
                    Console.ReadKey();
                }
            }
            break;



    }
    if (choice.Key == ConsoleKey.Escape)
        break;


} while (true);
