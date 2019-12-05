namespace DotNetCourse.Day3.LinqAndLamdaExpressions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    class Program
    {
        public static void Main()
        {
            List<User> allUsers = ReadUsers("users.json");
            List<Post> allPosts = ReadPosts("posts.json");

            #region Demo

            // 1 - find all users having email ending with ".net".
            var users1 = from user in allUsers
                         where user.Email.EndsWith(".net")
                         select user;

            var users11 = allUsers.Where(user => user.Email.EndsWith(".net"));

            IEnumerable<string> userNames = from user in allUsers
                                            select user.Name;

            var userNames2 = allUsers.Select(user => user.Name);

            foreach (var value in userNames2)
            {
                Console.WriteLine(value);
            }

            IEnumerable<Company> allCompanies = from user in allUsers
                                                select user.Company;

            var users2 = from user in allUsers
                         orderby user.Email
                         select user;

            var netUser = allUsers.First(user => user.Email.Contains(".net"));
            Console.WriteLine(netUser.Username);

            #endregion

            // 2 - find all posts for users having email ending with ".net".
            IEnumerable<int> usersIdsWithDotNetMails = from user in allUsers
                                                       where user.Email.EndsWith(".net")
                                                       select user.Id;

            IEnumerable<Post> posts = from post in allPosts
                                      where usersIdsWithDotNetMails.Contains(post.UserId)
                                      select post;

            foreach (var post in posts)
            {
                Console.WriteLine(post.Id + " " + "user: " + post.UserId);
            }

            // 3 - print number of posts for each user.
			var noOfPosts = from post in allPosts
										 group post by post.UserId into g
										 select new { 
											sum = g.Count(), 
											userid = g.Key
											};

			foreach (var tmp in noOfPosts)
			{
				Console.WriteLine(tmp.userid + " " + tmp.sum);
			}

			var noOfPosts2 = allPosts.GroupBy(post => post.UserId).Select(g => new { 
											sum = g.Count(), 
											id = g.Key });


			foreach (var tmp in noOfPosts)
			{
				Console.WriteLine(tmp.userid + " " + tmp.sum);
			}



			// 4 - find all users that have lat and long negative.
			var users = allUsers.Where(g => g.Address.Geo.Lat < 0 && g.Address.Geo.Lng < 0).Select(g => new { id = g.Id, name = g.Name });
			foreach (var user in users)
			{
				Console.WriteLine(user.id + " " + user.name);
			}

			// 5 - find the post with longest body.

			var post2 = allPosts.OrderByDescending(p => p.Body.Length).FirstOrDefault();
			Console.WriteLine(post2.Title + " " + post2.Id);

			// 6 - print the name of the employee that have post with longest body.
			var employee = (
					from user in allUsers join post in allPosts on user.Id equals post.Id 
					let c = (int)post.Body.Length
					orderby c descending
					select user
					).FirstOrDefault();

			Console.WriteLine("name of the employee that have post with longest body " + employee.Name);

			// 7 - select all addresses in a new List<Address>. print the list.


			List<Address> listAddress = new List<Address>(from user in allUsers select user.Address);
			foreach (var a in listAddress)
			{
				Console.WriteLine(a.Street);
			}

			// 8 - print the user with min lat
			var minLatUser = (from user in allUsers orderby user.Address.Geo.Lat descending select user).FirstOrDefault();
			Console.WriteLine("user with min lat " + minLatUser.Name);


			// 9 - print the user with max long
			var maxLatUser = (from user in allUsers orderby user.Address.Geo.Lng descending select user).FirstOrDefault();
			Console.WriteLine("user with max lng " + minLatUser.Name);


			// 10 - create a new class: public class UserPosts { public User User {get; set}; public List<Post> Posts {get; set} }
			//    - create a new list: List<UserPosts>
			//    - insert in this list each user with his posts only
			List<UserPosts> userPosts = new List<UserPosts>();
			var all = (from user in allUsers join post in allPosts on user.Id equals post.UserId into g select new { User = user, Posts = from p in g select p });
			foreach (var a in all)
			{
				var u = new UserPosts();
				u.User = a.User;
				u.Posts = new List<Post>(a.Posts);
			}

			foreach (var u in all)
			{
				Console.WriteLine("-----User "+ u.User.Name + " has the following posts:");
				foreach (var p in u.Posts)
				{
					Console.WriteLine(p.Title);

				}
				Console.WriteLine("-----");
			}



			// 11 - order users by zip code
			var ordered = from user in allUsers orderby user.Address.Zipcode select user;
			foreach (var a in ordered)
			{
				Console.WriteLine(a.Name);
			}


			// 12 - order users by number of posts
			
			var usersByPosts2 = from user in allUsers join
								post in allPosts on user.Id equals post.UserId into allg
								orderby allg.Count()
								select new { user, c = allg.Count()};

			foreach (var u in usersByPosts2)
			{
				Console.WriteLine( u.user.Name + " has " + u.c + " posts");
			}
		}

		private static List<Post> ReadPosts(string file)
        {
            return ReadData.ReadFrom<Post>(file);
        }

        private static List<User> ReadUsers(string file)
        {
            return ReadData.ReadFrom<User>(file);
        }
    }
	public class UserPosts { 
		  public User User { get; set; }
		  public List<Post> Posts { get; set; } 
	 }
}
