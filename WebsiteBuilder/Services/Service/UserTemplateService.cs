using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsiteBuilder.Core.Repositories;
using WebsiteBuilder.Data;
using WebsiteBuilder.Helper;
using WebsiteBuilder.Models.UserTemplateModel.CreateUserTemplate;
using WebsiteBuilder.Services.IService;

namespace WebsiteBuilder.Services.Service
{
    public class UserTemplateService : InterfaceUserTemplate
    {
        private UnitOfWork _unitOfWork;
        public UserTemplateService(MyDBContext context)
        {
            _unitOfWork = new UnitOfWork(context);
        }
        public async Task<BaseObjectSetResponse<CreateUserTemplateResponse>> CreateUserTemplateInterface(CreateUserTemplateRequest request)
        {
            string[] subs = request.UserName.Split(" ");
           
            TemplateModel userTemplate = new TemplateModel
            {
                DomainName = subs[0],
                HeaderType = request.HeaderType,
                PrimaryColor = request.PrimaryColor,
                SecondaryColor = request.SecondaryColor,
                TextColor = request.TextColor,
                HeaderContent = request.HeaderContent,
                BodyType = request.BodyType,
                BodyContaint = request.BodyContaint,
                WebsiteInformation = request.WebsiteInformation,
                FaceBook=request.FaceBook,
                YouTube = request.YouTube,
                Instagram = request.Instagram,
                Twitter = request.Twitter
            };

            var res = await  _unitOfWork.TemplateRepository.Add(userTemplate);

            IList<TemplateModel> findTemplateId =await _unitOfWork.TemplateRepository.All(data => data.Id == res.Id);
            var foundTemplateId = findTemplateId.FirstOrDefault();
            foundTemplateId.DomainName = subs[0] + foundTemplateId.Id;

            var getDomain = await _unitOfWork.TemplateRepository.Update(foundTemplateId);


            CreateUserTemplateModel saveUserData = new CreateUserTemplateModel
            {
                UserName = request.UserName,
                UserEmail = request.UserEmail,
                UserPhone  = request.UserPhone,
                TemplateId = res.Id
            };

            await _unitOfWork.UserRepository.Add(saveUserData);

            return new BaseObjectSetResponse<CreateUserTemplateResponse>
            {
                Data = getDomain.DomainName,
                IsSuccess = true,
            };
        }

        public async Task<BaseObjectSetResponse<CreateUserTemplateResponse>> GetUserTemplateInterface(string user)
        {
            IList<TemplateModel> findUserTemplate =await _unitOfWork.TemplateRepository.All(data => data.DomainName==user);
            if(findUserTemplate.Count() == 0)
            {
                return new BaseObjectSetResponse<CreateUserTemplateResponse>
                {
                    Data = null,
                    IsSuccess = true,
                };
            }
            else
            {
                var foundUserTemplate = findUserTemplate.FirstOrDefault();
                IList<CreateUserTemplateModel> findUser = await _unitOfWork.UserRepository.All(data => data.TemplateId == foundUserTemplate.Id);
                var foundUser = findUser.FirstOrDefault();

                Dictionary<string, Object> UserDataResponse = new Dictionary<string, Object>();
                UserDataResponse.Add("UserData", foundUser);
                UserDataResponse.Add("TemplateData", foundUserTemplate);


                return new BaseObjectSetResponse<CreateUserTemplateResponse>
                {
                    Data = UserDataResponse,
                    IsSuccess = true,
                };
            }
            
        }
    }
}
