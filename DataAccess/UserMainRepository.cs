using Domain;
using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UserMainRepository
    {
        private AppDbContext ctx;
        private SecurityHelpers security = new SecurityHelpers();
        private CoreHelpers coreHelpers = new CoreHelpers();

        public UserMainRepository(AppDbContext dbContext)
        {
            ctx = dbContext;
        }

        public List<RecoveryQuestionEntity> GetRecoveryQuestions()
        {
            List<RecoveryQuestionEntity> questions = ctx.RecoveryQuestions.ToList();

            return questions;
        }

        public RecoveryQuestionEntity GetRecoveryQuestionByEmail(string email)
        {
            email = security.EncryptString(email);

            Guid id = ctx.UserMainData.FirstOrDefault(u => u.Email == email).RecoveryId;
            RecoveryQuestionEntity questionEntity = ctx.RecoveryQuestions.FirstOrDefault(r => r.Id == id);

            return questionEntity;
        }

        public UserMainEntity UserLogin(string email, string password)
        {
            email = security.EncryptString(email);
           UserMainEntity userData = ctx.UserMainData.FirstOrDefault(u => u.Email == email);
           if (userData == null)
            {
                return null;
            }

           password = security.GenerateHash(password, userData.Salt);
            
            if (password == userData.PasswordHash)
            {
                userData.FirstName = security.DecryptString(userData.FirstName);
                userData.Email = security.DecryptString(userData.Email);
                return userData;
            }

            return null;
        }

        public bool CheckForExistingUser(string email)
        {
            email = security.EncryptString(email);
            if (ctx.UserMainData.Any(u => u.Email == email))
            {
                return true;
            }

            return false;
        }

        public bool CreateNewUser(UserMainEntity newUserMain, UserFitnessEntity newUserFitness)
        {
            newUserMain.Id = coreHelpers.GenerateId();
            newUserMain.Email = security.EncryptString(newUserMain.Email);
            newUserMain.FirstName = security.EncryptString(newUserMain.FirstName);
            newUserMain.Salt = security.GenerateSalt();
            newUserMain.PasswordHash = security.GenerateHash(newUserMain.PasswordHash, newUserMain.Salt);
            newUserMain.PremiumUnlock = false;

            ctx.UserMainData.Add(newUserMain);
            int successIndicator = ctx.SaveChanges();

            if (successIndicator <= 0)
            {
                return false;
            }
            successIndicator = 0;

            ctx.UserFitnessData.Add(newUserFitness);
            successIndicator = ctx.SaveChanges();

            if (successIndicator <= 0)
            {
                return false;
            }

            return true;
        }

        public UserMainEntity ValidateRecoveryAns(string inputAns, string email)
        {
            UserMainEntity user = new UserMainEntity();

            string recoveryAnswer = ctx.UserMainData.FirstOrDefault(r  => r.Email == email).RecoveryAns;
            inputAns = security.EncryptString(inputAns);

            if (recoveryAnswer != null && recoveryAnswer == inputAns)
            {
                return null;
            }

            user = ctx.UserMainData.FirstOrDefault(u => u.Email == email);

            user.FirstName = security.DecryptString(user.FirstName);
            user.Email = security.DecryptString(user.Email);

            return user;
        }

        public UserMainEntity TokenLoginAttempt()
        {
            string currentToken = security.GenerateLoginToken();

            Guid userId = ctx.UserTokenData.FirstOrDefault(t => t.TokenEnc == currentToken)?.UserId ?? Guid.Empty;

            if (userId == Guid.Empty)
            {
                return null;
            }

            UserMainEntity user = ctx.UserMainData.FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return null;
            }

            user.FirstName = security.DecryptString(user.FirstName);
            user.Email = security.DecryptString(user.Email);

            return user;
        }

        public void AddToken(Guid userId)
        {
            string currentToken = security.GenerateLoginToken();
            UserTokenEntity token = new UserTokenEntity()
            {
                UserId = userId,
                TokenEnc = currentToken
            };
            ctx.UserTokenData.Add(token);
            ctx.SaveChanges();
        }

        public void RemoveToken(Guid userId)
        {
            string currentToken = security.GenerateLoginToken();

            UserTokenEntity token = ctx.UserTokenData.FirstOrDefault(c => c.UserId == userId && c.TokenEnc == currentToken);
            ctx.UserTokenData.Remove(token);
            ctx.SaveChanges();
        }

        public bool UpdateUser(UserMainEntity user)
        {
            UserMainEntity updateUser = ctx.UserMainData.FirstOrDefault(u => u.Id == user.Id);
            updateUser.Email = security.EncryptString(user.Email);
            updateUser.FirstName = security.EncryptString(user.FirstName);
            updateUser.PasswordHash = security.GenerateHash(user.FirstName, user.Salt);
            updateUser.PremiumUnlock = user.PremiumUnlock;

            int status = ctx.SaveChanges();
            if (status <= 0)
            {
                return false;
            }

            return true;
        }
    }
}
