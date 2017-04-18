using System.Linq;
using EverydayJournal.Data;
using EverydayJournal.Models;

namespace EverydayJournal.Client
{
    public static class UserUtility
    {
        public static Person GetCurrentLoggedUser(EverydayJournalContext context)
        {
            using (context)
            {
                // if userName doesn't work, try replace it with - Environment.UserName
                var userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                var user = context.People.FirstOrDefault(p => p.Name == userName);

                return user;
            }        
        }   
    }
}