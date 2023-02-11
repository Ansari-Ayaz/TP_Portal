using System.Collections.Generic;
using TP_API.Models;
using TP_API.Models.DBModels;
using TP_API.Models.TransectionModels;

namespace TP_API.Repository
{
    public interface ITP
    {
        Response SaveTest(TestDetail testData);
        Response UpdateTest(TestDetail testData);
        List<TestDetail> ViewAllTests();
        Response DeleteTest(int Id);
        Response SaveQuesAns(TestQuesData qoData);
        Response ViewTestById(long Id);
        Response UpdateQuesAns(TestQuesData qoData);
        Response GetQuesOptByTestId(int Id);
        Response SaveUser(User user);
        List<User> GetAllUsers();
        Response CheckLogin(LoginDetail uDetail);
        Response SaveSchCandDetail(SchCandData SCData);
        Response UpdateUser(User uDteail);
        List<Schedule> GetAllSchedules();
        Response CheckCandidateLogin(CandData candData);
        Response GetCandQOByTestId(int Id);
        Response SaveCandTest(CandTestSubmit candData);
        List<ViewCandResult> GetAllCandResults();
    }
}
