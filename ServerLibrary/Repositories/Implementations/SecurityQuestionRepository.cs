

using BaseLibrary.DTOs;
using BaseLibrary.Entities;
using BaseLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implementations
{
    public class SecurityQuestionRepository(AppDbContext _appDbContext) : ISecurityQuestion
    {
        

        public async Task<GeneralResponse> CreateAsync(BaseLibrary.DTOs.SecurityQuestion securityQuestion)
        {
            if (securityQuestion == null)
            {
                return new GeneralResponse(false, "Model is empty");
            }

            var checkSecurityQuestion = await CheckIfSecurityQuestionAlreadyExist(securityQuestion.Question!);
            if (checkSecurityQuestion != null) 
            {
                return new GeneralResponse(false, "Access Denied: Question already exist!. Please try different one.");
            }

            var securityQuestionAddToDB = await AddToDatabase(new BaseLibrary.Entities.SecurityQuestion()
            {
               Question = securityQuestion.Question
            });

            return new GeneralResponse(true, "A new security question have been added into the system successfully!");

        }

        private async Task<BaseLibrary.Entities.SecurityQuestion> CheckIfSecurityQuestionAlreadyExist(string question)
        {
            return await _appDbContext.SecurityQuestions.FirstOrDefaultAsync(x => x.Question!.ToLower()!.Equals(question.ToLower()!));
        }

        private async Task<T> AddToDatabase<T>(T model)
        {
            var result = _appDbContext.Add(model!);
            await _appDbContext.SaveChangesAsync();
            return (T)result.Entity;
        }
    }
}
