using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Skietbaan_T2.Models {
    public interface IMockModelsContext {
        IEnumerable<User> Get();
        User Get(int id);
        string Post([FromBody] User user);
        void Put([FromBody] User user);
        void Delete(User user);
    }
}
