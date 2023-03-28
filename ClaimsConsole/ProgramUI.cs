using System.Collections.Generic;
public class ProgramUI
{
    private ClaimRepository _claimRepos = new ClaimRepository();
    public void Run()
    {
        SeedClaims();
        Menu();
    }
    public void Menu()
    {
        bool keepRunning = true;
        while (keepRunning)
        {
            Console.Clear();

            System.Console.WriteLine("••••Komodo Insurance Claims Viewer••••\nFrom here you can:\n" +
            " 1. See All Current Claims\n" +
            " 2. Show the Next Claim\n" + 
            " 3. Add a New Claim\n" +
            " 4. Exit Claims Viewer\n");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.Clear();
                    CurrentClaimsViewer();
                    break;
                case "2": //DisplayThe
                    Console.Clear();
                    ClaimPeeker();
                    break;
                case "3": //Add New Claim
                    Console.Clear();
                    NewClaimPrompter();
                    break;
                case "4": //Exit
                    Console.Clear();
                    System.Console.WriteLine("••••Exiting Komodo Insurance Claims Viewer••••");
                    keepRunning = false;
                    break;
                default:
                    Console.Clear();
                    System.Console.WriteLine("Options 1, 2, 3 and 4 exist. Please choose from them.");
                    break;
            }
            System.Console.WriteLine("Press return for Fortune cookie......\n\nGoodbye for now.");
            Console.ReadKey();
            Console.Clear();
            keepRunning = false;
        }
    }


    private void CurrentClaimsViewer()
    {
        Console.Clear();
        System.Console.WriteLine("•Komodo Insurance Claims Viewer: CURRENT CLAIMS•\n");//this has been retitled as it no longer shows ALL, but EACH
        List<InsClaim> listOfClaims = _claimRepos.GetAllClaims().ToList();
        int numberOfClaims = listOfClaims.Count;
        if (numberOfClaims == 0)
        {
            System.Console.WriteLine("The queue is empty.");
            System.Console.WriteLine("Hit Return for Menu.");
            Console.ReadKey();
            Menu();
        }
        else
        {
            System.Console.WriteLine($"There are {numberOfClaims} in the queue.\n");
            foreach (InsClaim insClaim in listOfClaims)
            {
                SingleClaimViewer(insClaim);
                //AskRemoveClaim(insClaim); //moved to end of SingleClaimViewer bc lost here
            }
        }
    }


    private void ClaimPeeker()
    {
        Console.Clear();
        System.Console.WriteLine("••Komodo Insurance Claims Viewer: NEXT CLAIM••");
        SingleClaimViewer(_claimRepos.CheckKIClaim());

    }
    private void SingleClaimViewer(InsClaim insClaim)
    {
        //Later: Perhaps list spot in queue? \nQueue Spot: {insClaim.[0]}?
        System.Console.WriteLine($"\nClaim ID: {insClaim.IDForClaim}\nClaim Type: {insClaim.TypeClaim}\tClaim Amount: {insClaim.ClaimAmount}\nIncident on: {insClaim.IncidentDate.ToString("MM/dd/yyyy")}\tClaim on: {insClaim.ClaimDate.ToString("MM/dd/yyyy")}\t");
        // one would want to return to whichever method called for this or move on to next thing; 
        AskRemoveClaim(insClaim);
        // }
            //System.Console.WriteLine("\nHit Return to Continue.");
            //Console.ReadKey();
            
    }

    private void AskRemoveClaim(InsClaim insClaim)
    {
        System.Console.WriteLine("If filed more than 30 days from incident, claims are invalid. This looks invalid. \nDo you agree (Please type yes or no)?\t");
        string answer = Console.ReadLine();
        string answerLittle  = answer.ToLower();
        if (answerLittle == "yes")
        {
            ClaimRemover();
        }
        else
        {
            answer = "no";
            System.Console.WriteLine("It will stay in the queue.");
            Console.ReadKey();
            //CurrentClaimsViewer();
        }
    }

    private void ClaimRemover()
    {
        Console.Clear();
        _claimRepos.RemoveFromQueue();
        System.Console.WriteLine("!!Komodo Insurance Claims Viewer: CLAIM REMOVED!!\n");
        System.Console.WriteLine("Hit Return for the •CURRENT CLAIMS• Viewer.");
        Console.ReadKey();
        CurrentClaimsViewer();

    }

    private void NewClaimPrompter()
    {
        Console.Clear();
        System.Console.WriteLine("•••Komodo Insurance Claims Viewer: NEW CLAIM•••");
        InsClaim claimToAdd = new InsClaim();
        Random r = new Random(); //sets up random  5-digit#
        int idNumberNew = r.Next(32333, 99999);
        claimToAdd.IDForClaim = idNumberNew;
        System.Console.WriteLine($"***Komodo Insurance Claims Viewer: NEW CLAIM***\n\nThe New Claim will have the ID number:{idNumberNew}.\n");
        System.Console.WriteLine("What's the New Claim Type (1, 2 or 3) ?\t" +
        " (1) Car\t" +
        " (2) Home\t" +
        " (3) Theft");
        string chooseType = Console.ReadLine();
        switch (chooseType)
        {
            case "1":
                claimToAdd.TypeClaim = "Car";
                break;
            case "2": //DisplayThe
                claimToAdd.TypeClaim = "Home";
                break;
            case "3": //Add New Claim
                claimToAdd.TypeClaim = "Theft";
                break;
            default:
                System.Console.WriteLine("Options 1, 2 and 3 exist. Please choose from them.");
                break;
        }
        System.Console.WriteLine("What\'s the year, month and day the incident occurred? (yyyy/mm/dd)\t");
        string incidentDate = Console.ReadLine();
        DateTime incidentDated = Convert.ToDateTime(incidentDate);
        claimToAdd.IncidentDate = incidentDated;
        DateTime claimEntered = DateTime.Today;
        claimToAdd.ClaimDate = claimEntered;
        System.Console.WriteLine("What is the Claim Amount?");
        decimal claimWanted = decimal.Parse(Console.ReadLine());
        claimToAdd.ClaimAmount = claimWanted;
        _claimRepos.AddToQueue(claimToAdd);
        System.Console.WriteLine("***New Claim Added***\n");
        System.Console.WriteLine("Hit Return for the Main Menu.");
        Console.ReadKey();
        Menu();

    }
    public void SeedClaims()
    {
        _claimRepos.AddToQueue(new InsClaim(89822, "Car", 3453.23m, new DateTime(2023, 01, 01), new DateTime(2023, 03, 21)));
        _claimRepos.AddToQueue(new InsClaim(45983, "Theft", 153.63m, new DateTime(2023, 02, 28), new DateTime(2023, 03, 02)));
        _claimRepos.AddToQueue(new InsClaim(33990, "Home", 736.38m, new DateTime(2023, 03, 01), new DateTime(2023, 03, 02)));
        _claimRepos.AddToQueue(new InsClaim(10012, "Car", 1153.93m, new DateTime(2023, 01, 01), new DateTime(2023, 03, 17)));
        _claimRepos.AddToQueue(new InsClaim(10002, "Home", 10093.32m, new DateTime(2023, 02, 28), new DateTime(2023, 03, 24)));
    }
}