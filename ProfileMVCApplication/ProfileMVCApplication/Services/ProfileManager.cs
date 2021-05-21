using Microsoft.Extensions.Logging;
using ProfileMVCApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileMVCApplication.Services
{
    public class ProfileManager : IRepo<Profile>
    {
        ProfileContext _context;
        ILogger<ProfileManager> _Logger;

        public ProfileManager(ProfileContext context, ILogger<ProfileManager> logger)
        {
            _context = context;
            _Logger = logger;
        }

        public void Add(Profile t)
        {
            try
            {
                _context.profiles.Add(t);
                _context.SaveChanges();

            }
            catch (Exception e)
            {

                _Logger.LogDebug(e.Message);
            }
        }

        public void Delete(Profile t)
        {
            try
            {
                _context.profiles.Remove(t);
                _context.SaveChanges();

            }
            catch (Exception e)
            {

                _Logger.LogDebug(e.Message);
            }
        }

        public Profile Get(int id)
        {
            try
            {
                Profile p = _context.profiles.FirstOrDefault(i => i.Id == id);
                return p;
            }
            catch (Exception e)
            {
                _Logger.LogDebug(e.Message);
            }
            return null;
        }

        public IEnumerable<Profile> GetAll()
        {
            try
            {
                if(_context.profiles.Count()==0)
                {
                    return null;
                }
                return _context.profiles.ToList();

            }
            catch (Exception e)
            {
                _Logger.LogDebug(e.Message);
            }
            return null;
        }

        public void Update(int id, Profile t)
        {
            Profile p = Get(id);
            if(p!= null)
            {
                p.Name = t.Name;
                p.Age = t.Age;
                p.IsEmployeed = t.IsEmployeed;
                p.Qualification = t.Qualification;
                p.NoticePeriod = t.NoticePeriod;
                p.CurrentCTC = t.CurrentCTC;
            }
            _context.SaveChanges();
        }
    }
}
