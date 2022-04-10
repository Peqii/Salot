using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalotAPI.EF
{
    public static class ModelCreator
    {
        public static Human CreateHumanFromAPI(Salot.Data.Human apiHuman)
        {
            Human human = new Human();
            human.Name = apiHuman.Name;
            human.Age = apiHuman.Age;
            human.ModifiedOn = DateTime.Now;
            return human;
        }     
        public static Website CreateWebsite(Salot.Data.Website apiWebsite)
        {
            Website website = new Website();
            website.Address = apiWebsite.Address;
            website.Lunch = apiWebsite.Lunch;
            website.UserId = apiWebsite.UserId;
            return website;
        }
        public static User CreateUser(Salot.Data.User apiUser)
        {
            User user = new User();
            user.Email = apiUser.Email;
            user.Password = apiUser.Password;
            user.Phone = apiUser.Phone;
            return user;
        }
        public static Salot.Data.Website CreateModelWebsite(Website website)
        {
            Salot.Data.Website modelWebsite = new Salot.Data.Website();
            modelWebsite.Address = website.Address;
            modelWebsite.UserId = website.UserId;
            modelWebsite.ID = website.Id;
            modelWebsite.Lunch = website.Lunch;
            modelWebsite.CreatedOn = website.CreatedOn ?? DateTime.MinValue;
            modelWebsite.ModifiedOn = website.ModifiedOn ?? DateTime.MinValue;
            return modelWebsite;
        }
    }
}
