using System.Collections.Generic;
public class ClaimRepository
{    //create method
    private Queue<InsClaim> _claimQueue = new Queue<InsClaim>();
    public void AddToQueue(InsClaim insClaim)
    {
        _claimQueue.Enqueue(insClaim);
    }
    //read method -->array for all; 
    public InsClaim CheckKIClaim()
    {
        return _claimQueue.Peek();

    }
    //update method - or in absence, things we want to do
    public ICollection<InsClaim> GetAllClaims()
    {
        return _claimQueue.ToArray<InsClaim>();
    }
    //delete method
    public InsClaim RemoveFromQueue()
    {
        int aburdity = _claimQueue.Count;//need to handle empty queue arose 2x in ProgramUI
        if (aburdity != 0)
        {
        return _claimQueue.Dequeue();
        }
        else 
        {
            return _claimQueue.Peek();
        }
    
    }   
}

