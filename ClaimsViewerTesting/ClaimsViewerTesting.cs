using _InsClaim;

namespace ClaimRepository;

[TestMethod]
public class ClaimsViewerTesting

{

    [TestMethod]

    public void TestMethod1()
    {
        InsClaim insClaim = new InsClaim();

        insClaim.IDForClaim = 45983;
        int expected = 45983;
        string actual = insClaim.IDForClaim;
        Assert.AreEqual(expected, actual);
    }
}


[TestClass]

public class ClaimRepos_Tests
{
    private ClaimsRepos_Testing _repos;
    private InsClaims _claims;

    [TestIntialize]
    
    public void Arrange()
    {
        _repos = new ClaimsRepos_Testing();
        _claims = new InsClaims((10002, "Home", 10093.32m, new DateTime(2019, 01, 01), new DateTime(2025, 05, 01)));
        _repos.AddToQueue(_claims);
    }

    [TestMethod]
    public void AddToQueue_ShouldGetNotNull()
    {
        //Arrange -->Setting up the playinf field
        InsClaims claims = new InsClaims();
        claims.IDForClaim = "49539";
        ClaimsRepos_Testing = repos = new ClaimsRepos_Testing();
        //Act --> Get/run code we want to test
        _repos.AddToQueue(claims);
        InsClaims insClaimFromIDK = _repos.AddToQueue;
        //Assert --> Usee the assert class to verify the expected outcome
        Assert.IsNotNull(insClaimFromIDK);
    }
}