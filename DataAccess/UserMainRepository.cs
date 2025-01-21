using Domain;
using SecurityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UserMainRepository
    {
        AppDbContext ctx;

        public UserMainRepository(AppDbContext ctx)
        {
            this.ctx = ctx;
        }

        public List<RecoveryQuestionEntity> GetRecoveryQuestions()
        {
            List<RecoveryQuestionEntity> questions = ctx.RecoveryQuestions.ToList();

            return questions;
        }

        public RecoveryQuestionEntity GetRecoveryQuestionById(Guid id)
        {
            RecoveryQuestionEntity questionEntity = ctx.RecoveryQuestions.FirstOrDefault(r => r.Id == id);

            return questionEntity;
        }

        public UserMainEntity UserLogin(string email, string password)
        {
           UserMainEntity userData = ctx.UserMainData.FirstOrDefault(u => u.Email == email);
           if (userData == null)
            {
                return null;
            }
           CSecurity security = new CSecurity();
           password = security.GenerateHash(password, userData.Salt);
            
            if (password == userData.PasswordHash)
            {
                return userData;
            }

            return null;
        }
    }
}
